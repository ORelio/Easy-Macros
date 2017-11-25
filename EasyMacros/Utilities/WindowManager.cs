using System;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace EasyMacros.Utilities
{
    /// <summary>
    /// Utility class for retrieving information about open windows
    /// </summary>
    public static class WindowManager
    {
        [DllImport("user32.dll")]
        static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll")]
        static extern int GetWindowText(IntPtr hWnd, StringBuilder text, int count);

        [DllImport("user32.dll")]
        public static extern IntPtr GetWindowThreadProcessId(IntPtr hWnd, out uint ProcessId);

        [DllImport("user32.dll")]
        static extern int GetWindowModuleFileName(IntPtr hWnd, StringBuilder text, int count);

        [DllImport("user32.dll")]
        private static extern bool
        GetWindowPlacement(IntPtr hWnd, ref WINDOWPLACEMENT lpwndpl);

        private struct POINTAPI
        {
            public int x;
            public int y;
        }

        private struct RECT
        {
            public int left;
            public int top;
            public int right;
            public int bottom;
        }

        private struct WINDOWPLACEMENT
        {
            public int length;
            public int flags;
            public int showCmd;
            public POINTAPI ptMinPosition;
            public POINTAPI ptMaxPosition;
            public RECT rcNormalPosition;
        }

        public static string GetActiveWindowTitle()
        {
            const int nChars = 1024;
            IntPtr handle = IntPtr.Zero;
            StringBuilder Buff = new StringBuilder(nChars);
            handle = GetForegroundWindow();

            if (GetWindowText(handle, Buff, nChars) > 0)
            {
                return Buff.ToString();
            }
            return null;
        }

        public static string GetActiveWindowExename()
        {
            try
            {
                IntPtr hwnd = GetForegroundWindow();
                uint pid;
                GetWindowThreadProcessId(hwnd, out pid);
                System.Diagnostics.Process p = System.Diagnostics.Process.GetProcessById((int)pid);
                try
                {
                    return System.IO.Path.GetFileName(p.MainModule.FileName);
                }
                catch
                {
                    return p.ProcessName + ".exe";
                }
            }
            catch
            {
                const int nChars = 1024;
                IntPtr handle = IntPtr.Zero;
                StringBuilder Buff = new StringBuilder(nChars);
                handle = GetForegroundWindow();

                if (GetWindowModuleFileName(handle, Buff, nChars) > 0)
                {
                    try
                    {
                        return System.IO.Path.GetFileName(Buff.ToString());
                    }
                    catch { return Buff.ToString(); }
                }
                return null;
            }
        }

        public static bool isFullScreenAppActive
        {
            get
            {
                IntPtr foreWindow = GetForegroundWindow();
                WINDOWPLACEMENT forePlacement = new WINDOWPLACEMENT();
                forePlacement.length = Marshal.SizeOf(forePlacement);
                GetWindowPlacement(foreWindow, ref forePlacement);

                RECT bounds = forePlacement.rcNormalPosition;
                int width = bounds.right - bounds.left;
                int height = bounds.bottom - bounds.top;
                System.Drawing.Rectangle resolution =
                    System.Windows.Forms.Screen.PrimaryScreen.Bounds;

                return (width == resolution.Width && height == resolution.Height);
            }
        }

        public static bool IsSingleInstance
        {
            get
            {
                Process currentProcess = Process.GetCurrentProcess();

                var runningProcess = (from process in Process.GetProcesses()
                                      where
                                        process.Id != currentProcess.Id &&
                                        process.ProcessName.Equals(
                                          currentProcess.ProcessName,
                                          StringComparison.Ordinal)
                                      select process).FirstOrDefault();

                if (runningProcess != null)
                {
                    return false;
                }

                return true;
            }
        }
    }
}
