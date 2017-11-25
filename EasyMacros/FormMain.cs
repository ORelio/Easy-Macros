using System;
using System.Text;
using System.Collections.Generic;
using System.IO;
using System.Diagnostics;
using System.Windows.Forms;
using System.Management;
using MouseKeyboardActivityMonitor.WinApi;
using MouseKeyboardActivityMonitor;
using EasyMacros.Macros;
using EasyMacros.Utilities;

namespace EasyMacros
{
    public partial class FormMain : Form
    {
        private static System.Windows.Forms.Timer timer;
        private static ManagementEventWatcher watcher;
        private static GlobalHooker Input;
        private static KeyboardHookListener KInput;
        private static MouseHookListener MInput;
        private static List<Keys> PressedKeys;
        private static MacroSet Macros = new MacroSet();
        private bool MacroActivate = false;
        private bool MacroActivateChanging = false;
        private int ActivateKey = 93;
        private bool circumflexOn = false;
        private bool circumflex = false;
        private bool shift = false;
        private bool diaeresis = false;
        private bool testing = true;
        private bool somethingToSave = false;
        private int previousindex = -1;
        private string previousMacroName = "";
        private int idletime = 0;

        public FormMain()
        {
            if (!WindowManager.IsSingleInstance)
            {
                MessageBox.Show(Translations.Get("already_running"));
                Environment.Exit(0);
            }

            PressedKeys = new List<Keys>();
            InitializeComponent();
            HideMainForm();

            this.Text = Translations.Get("about_text");
            this.Item_Title.Text = Translations.Get("about_title");

            Input = new GlobalHooker();
            KInput = new KeyboardHookListener(Input);
            MInput = new MouseHookListener(Input);
            KInput.Enabled = true; MInput.Enabled = true;
            MInput.MouseDown += new MouseEventHandler(OnUserMouseInteraction);
            MInput.MouseUp += new MouseEventHandler(OnUserMouseInteraction);
            MInput.MouseMove += new MouseEventHandler(OnUserMouseInteraction);
            MInput.MouseClick += new MouseEventHandler(OnUserMouseClick);
            KInput.KeyDown += new KeyEventHandler(OnUserKeyboardPress);
            KInput.KeyUp += new KeyEventHandler(OnUserKeyboardRelease);
            KeySender.KeyStroke(KeySender.VkKeyScan('^'));

            if (File.Exists(SettingsFile.SaveFile))
            {
                SettingsFile.Load(ref ActivateKey);
            }
            else
            {
                SettingsFile.Save(ActivateKey);
                if (MessageBox.Show(
                    String.Format(
                        "{0}\n\n{1}\n{2}\n\n{3}",
                        Translations.Get("welcome_text_1"),
                        Translations.Get("welcome_text_2"),
                        Translations.Get("welcome_text_3"),
                        Translations.Get("welcome_text_4")
                    ),
                    Translations.Get("welcome_title"),
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                ) == DialogResult.Yes)
                {
                    Button_Help_Click(new object(), EventArgs.Empty);
                }
            }

            RefreshFiles();

            WqlEventQuery query = new WqlEventQuery("Select * From __InstanceCreationEvent Within 2 Where TargetInstance Isa 'Win32_Process'");
            watcher = new ManagementEventWatcher(query);
            watcher.EventArrived += new EventArrivedEventHandler(OnWindowOpen);
            watcher.Start();

            ProceedOtherMacros(Keys.None, MacroType.Startup);

            timer = new System.Windows.Forms.Timer();
            timer.Interval = 1000;
            timer.Tick += new EventHandler(OnIDLETick);
            timer.Start();
        }

        private void OnWindowOpen(object sender, EventArrivedEventArgs e)
        {
            //ManagementBaseObject obj = (ManagementBaseObject)e.NewEvent["TargetInstance"];
            //string name = obj["Name"].ToString();
            ProceedOtherMacros(Keys.None, MacroType.WinOpen);
        }

        private void OnUserMouseInteraction(object sender, MouseEventArgs e) { idletime = 0; }

        private void OnIDLETick(object sender, EventArgs e)
        {
            idletime++;

            List<Macro> m = Macros.getMacros(Keys.None, MacroType.IDLE);
            foreach (Macro macro in m)
            {
                if (macro.idletime == idletime && !WindowManager.isFullScreenAppActive)
                {
                    macro.Run();
                }
            }
        }

        private void OnUserMouseClick(object sender, MouseEventArgs e)
        {
            Keys TriggerKey = Keys.None;

            switch (e.Button)
            {
                case MouseButtons.Left:     TriggerKey = Keys.L; break;
                case MouseButtons.Middle:   TriggerKey = Keys.M; break;
                case MouseButtons.Right:    TriggerKey = Keys.R; break;
                case MouseButtons.XButton1: TriggerKey = Keys.P; break;
                case MouseButtons.XButton2: TriggerKey = Keys.N; break;
            }

            ProceedOtherMacros(TriggerKey, MacroType.Mouse);
        }

        private bool ProceedRewriteMacros(Keys lastPress)
        {
            while (PressedKeys.Contains(Keys.None))
            {
                PressedKeys.Remove(Keys.None);
            }

            if (PressedKeys.Count <= 1)
            {
                return false;
            }

            List<Macro> lm = Macros.getMacros(Keys.None, MacroType.RewriteKeyboard);
            bool macrolaunched = false;

            foreach (Macro m in lm)
            {
                if (m.TriggerKeys.Contains(lastPress))
                {
                    //We need to check if all other keys for this macro
                    //are currently pressed, and no other key is pressed.

                    bool valid = true;

                    //Check that the "Pressed key" set is INCLUDED in "Trigger keys"

                    foreach (Keys k in m.TriggerKeys)
                    {
                        if (!PressedKeys.Contains(k))
                        {
                            valid = false;
                            break;
                        }
                    }

                    //Check that the "Trigger keys" set is INCLUDED in "Pressed keys"
                    
                    foreach (Keys k in PressedKeys)
                    {
                        if ((int)k != 91 && !m.TriggerKeys.Contains(k))
                        {
                            valid = false;
                            break;
                        }
                    }

                    //If "valid" is still equals to "true", then it means that
                    //Pk is included in Tk and Tk is included in Pk (bi-directional
                    //set inclusion). Therefore, Pk is mathematically equals to Tk.

                    if (valid)
                    {
                        //Here, we are sure all the trigger keys are pressed, and only them.
                        //Let's check if window criteria and run the macro if criteria is met.

                        if (m.targetapp == "")
                        {
                            m.Run();
                            macrolaunched = true;
                        }
                        else
                        {
                            string name = WindowManager.GetActiveWindowTitle();
                            string exe = WindowManager.GetActiveWindowExename();
                            if (name != null && name.ToLower().Contains(m.targetapp.ToLower()))
                            {
                                m.Run();
                                macrolaunched = true;
                            }
                            else
                            {
                                if (exe != null && m.targetapp.ToLower().Equals(exe.ToLower()))
                                {
                                    m.Run();
                                    macrolaunched = true;
                                }
                            }
                        }
                    }
                }
            }

            return macrolaunched;
        }

        private bool ProceedOtherMacros(Keys TriggerKey, MacroType type)
        {
            List<Macro> lm = Macros.getMacros(TriggerKey, type);
            bool hasrun = false;

            foreach (Macro m in lm)
            {
                if (MacroActivate || m.Override || type == MacroType.WinOpen || type == MacroType.Startup)
                {
                    if (m.TriggerKey != Keys.None || type == MacroType.WinOpen || type == MacroType.Startup)
                    {
                        if (m.targetapp == "")
                        {
                            m.Run();
                            hasrun = true;
                        }
                        else
                        {
                            string name = WindowManager.GetActiveWindowTitle();
                            string exe = WindowManager.GetActiveWindowExename();
                            if (name != null && name.ToLower().Contains(m.targetapp.ToLower()))
                            {
                                m.Run();
                                hasrun = true;
                            }
                            else
                            {
                                if (exe != null && m.targetapp.ToLower().Equals(exe.ToLower()))
                                {
                                    m.Run();
                                    hasrun = true;
                                }
                            }
                        }
                    }
                }
            }

            MacroActivate = false;
            return hasrun;
        }

        private void OnUserKeyboardPress(object sender, KeyEventArgs e)
        {
            idletime = 0;
            if ((int)e.KeyCode == ActivateKey)
            {
                MacroActivate = true;
                if (testing)
                {
                    string name = WindowManager.GetActiveWindowTitle();
                    string exe = WindowManager.GetActiveWindowExename();
                    TopMostMessageBox.Show(
                        String.Format(Translations.Get("window_info_result_text"), name, exe),
                        Translations.Get("window_info_result_title"));
                    testing = false;
                }
            }

            switch (e.KeyCode)
            {
                case System.Windows.Forms.Keys.LShiftKey:
                case System.Windows.Forms.Keys.RShiftKey:
                case System.Windows.Forms.Keys.Shift:
                case System.Windows.Forms.Keys.ShiftKey:
                    shift = true;
                    break;
            }

            while (PressedKeys.Contains(e.KeyCode))
            {
                PressedKeys.Remove(e.KeyCode);
            }

            PressedKeys.Add(e.KeyCode);

            if (KeyHelper.Form_Visible)
            {
                KeyHelper.BoxContent += KeyConverter.WinFormKey2Name(e.KeyCode) + "\n";
                e.Handled = true;
            }
            else if (ProceedRewriteMacros(e.KeyCode))
            {
                e.Handled = true;
            }

            //Handle french ^ and ¨ key modifiers: êâôëü
            if ((int)e.KeyCode == 221 && !circumflex)
            {
                circumflex = true;
                e.Handled = true;
                if (shift) { diaeresis = true; }
            }
            else if (circumflex && !circumflexOn)
            {
                circumflexOn = true;
                switch (e.KeyCode)
                {
                    case (System.Windows.Forms.Keys)221:
                        circumflex = false;
                        diaeresis = false;
                        if (diaeresis)
                        {
                            KeySender.KeyPress(KeyConverter.Name2Key("Shift"));
                            KeySender.KeyStroke(KeySender.VkKeyScan('^'));
                            KeySender.KeyStroke(KeySender.VkKeyScan('^'));
                            KeySender.KeyRelease(KeyConverter.Name2Key("Shift"));
                        }
                        else
                        {
                            KeySender.KeyStroke(KeySender.VkKeyScan('^'));
                            KeySender.KeyStroke(KeySender.VkKeyScan('^'));
                        }
                        break;
                    case System.Windows.Forms.Keys.A:
                    case System.Windows.Forms.Keys.E:
                    case System.Windows.Forms.Keys.I:
                    case System.Windows.Forms.Keys.O:
                    case System.Windows.Forms.Keys.U:
                    case System.Windows.Forms.Keys.Y:
                        if (diaeresis)
                        {
                            KeySender.KeyPress(KeyConverter.Name2Key("Shift"));
                            KeySender.KeyStroke(KeySender.VkKeyScan('^'));
                            KeySender.KeyRelease(KeyConverter.Name2Key("Shift"));
                        }
                        else KeySender.KeyStroke(KeySender.VkKeyScan('^'));
                        circumflex = false;
                        diaeresis = false;
                        break;
                    default:
                        circumflex = false;
                        diaeresis = false;
                        break;
                }
                circumflexOn = false;
            }
        }

        private void OnUserKeyboardRelease(object sender, KeyEventArgs e)
        {
            idletime = 0;
            if (MacroActivateChanging)
            {
                ActivateKey = (int)e.KeyCode;
                MessageBox.Show(Translations.Get("activate_key_changed"));
                SettingsFile.Save(ActivateKey);
                MacroActivateChanging = false;
            }

            switch (e.KeyCode)
            {
                case System.Windows.Forms.Keys.F5:
                    if (ShowInTaskbar) {
                        previousindex = List_Macros.SelectedIndex;
                        RefreshFiles();
                        List_Macros.SelectedIndex = previousindex;
                    } break;
                case System.Windows.Forms.Keys.LShiftKey:
                case System.Windows.Forms.Keys.RShiftKey:
                case System.Windows.Forms.Keys.Shift:
                case System.Windows.Forms.Keys.ShiftKey:
                    shift = false;
                    break;
            }

            if ((int)e.KeyCode == ActivateKey)
            {
                MacroActivate = false;
            }

            while (PressedKeys.Contains(e.KeyCode))
            {
                PressedKeys.Remove(e.KeyCode);
            }

            ProceedOtherMacros(e.KeyCode, MacroType.Keyboard);
        }

        private void TrayIcon_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                NotificationAreaMenu.Show(Cursor.Position);
            }
        }

        private void Item_Exit_Click(object sender, EventArgs e)
        {
            Exit_App();
        }

        private void Item_About_Click(object sender, EventArgs e)
        {
            MessageBox.Show(String.Format("{0}\n\n{1}\n\n{2}",
                Translations.Get("about_description"),
                Translations.Get("about_text_year"),
                Translations.Get("about_website")),
            Translations.Get("about_title_dialog"),
            MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Item_MainForm_Click(object sender, EventArgs e)
        {
            OpenMainForm();
        }

        private void Button_Exit_Click(object sender, EventArgs e)
        {
            HideMainForm();
            Exit_App();
        }

        private void Button_Minimize_Click(object sender, EventArgs e)
        {
            HideMainForm();
            RefreshFiles();
        }

        private void RefreshFiles()
        {
            List_Macros.Items.Clear();

            if (Directory.Exists(MacroFiles.MacrosDir))
            {
                string[] files = Directory.GetFiles(MacroFiles.MacrosDir, "*" + MacroFiles.MacrosExt);
                for (int i = 0; i < files.Length; i++)
                {
                    List_Macros.Items.Add(Path.GetFileNameWithoutExtension(files[i]));
                }
            }

            Macros = MacroFiles.Load();
        }
        
        private void Buton_ActivateKey_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(
                    Translations.Get("activate_key_prompt"),
                    Translations.Get("activate_key_title"),
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                if (MessageBox.Show(
                    Translations.Get("activate_key_instructions"),
                    Translations.Get("activate_key_instructions_title"),
                    MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                {
                    MacroActivateChanging = true;
                }
            }

        }

        private void Button_Add_Click(object sender, EventArgs e)
        {
            Text_MacroTitle.Text = Text_MacroTitle.Text.Replace("\\", "");
            Text_MacroTitle.Text = Text_MacroTitle.Text.Replace("\"", "");
            Text_MacroTitle.Text = Text_MacroTitle.Text.Replace("/", "");
            Text_MacroTitle.Text = Text_MacroTitle.Text.Replace(":", "");
            Text_MacroTitle.Text = Text_MacroTitle.Text.Replace("*", "");
            Text_MacroTitle.Text = Text_MacroTitle.Text.Replace("?", "");
            Text_MacroTitle.Text = Text_MacroTitle.Text.Replace("<", "");
            Text_MacroTitle.Text = Text_MacroTitle.Text.Replace(">", "");
            Text_MacroTitle.Text = Text_MacroTitle.Text.Replace("|", "");
            Text_MacroTitle.Text = Text_MacroTitle.Text.Trim();

            if (Text_MacroTitle.Text != "" && Text_MacroContent.Text != "")
            {
                somethingToSave = false;
                Button_Add.Enabled = false;
                string newname = Text_MacroTitle.Text;
                previousindex = List_Macros.SelectedIndex;
                if (!Directory.Exists(MacroFiles.MacrosDir))
                    Directory.CreateDirectory(MacroFiles.MacrosDir);
                File.WriteAllText(MacroFiles.MacrosDir + Path.DirectorySeparatorChar + Text_MacroTitle.Text + MacroFiles.MacrosExt, Text_MacroContent.Text, Encoding.UTF8);
                if (previousMacroName != "" && previousMacroName != newname)
                    File.Delete(MacroFiles.MacrosDir + Path.DirectorySeparatorChar + previousMacroName + MacroFiles.MacrosExt);
                RefreshFiles();
                SelectItem(newname);
            }
        }

        private void Button_Delete_Click(object sender, EventArgs e)
        {
            if (List_Macros.SelectedItem != null)
            {
                string name = List_Macros.SelectedItem.ToString();
                if (name != null && File.Exists(MacroFiles.MacrosDir + Path.DirectorySeparatorChar + name + MacroFiles.MacrosExt)
                    && MessageBox.Show(String.Format(Translations.Get("delete_confirm"), name + MacroFiles.MacrosExt),
                    Translations.Get("delete_title"), MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    File.Delete(MacroFiles.MacrosDir + Path.DirectorySeparatorChar + name + MacroFiles.MacrosExt);
                    Button_New_Click(sender, e);
                    RefreshFiles();
                }
            }
        }

        private void Button_Disable_Click(object sender, EventArgs e)
        {
            string newname, currentname = List_Macros.SelectedItem.ToString();

            //Rename file, then reload macro list
            if (currentname.Length >= MacroFiles.DisablePrefix.Length && currentname.Substring(0, MacroFiles.DisablePrefix.Length) == MacroFiles.DisablePrefix)
            {
                newname = currentname.Substring(MacroFiles.DisablePrefix.Length);
                File.Move(MacroFiles.MacrosDir + Path.DirectorySeparatorChar + currentname + MacroFiles.MacrosExt,
                    MacroFiles.MacrosDir + Path.DirectorySeparatorChar + newname + MacroFiles.MacrosExt);
                RefreshFiles();
            }
            else
            {
                newname = MacroFiles.DisablePrefix + currentname;
                File.Move(MacroFiles.MacrosDir + Path.DirectorySeparatorChar + currentname + MacroFiles.MacrosExt,
                    MacroFiles.MacrosDir + Path.DirectorySeparatorChar + newname + MacroFiles.MacrosExt);
                RefreshFiles();
            }
            
            //Re-select the correct list item
            SelectItem(newname);
        }

        private void SelectItem(string name)
        {
            int i = 0;
            foreach (object item in List_Macros.Items)
            {
                if (item.ToString() == name)
                {
                    previousindex = -1;
                    List_Macros.SelectedIndex = i;
                    break;
                }
                i++;
            }
        }

        private bool VerifyChanges()
        {
            if (somethingToSave && Text_MacroTitle.Text != "" && Text_MacroContent.Text != "")
            {
                DialogResult result = MessageBox.Show(
                    String.Format(
                        Translations.Get("save_confirm"),
                        Text_MacroTitle.Text + MacroFiles.MacrosExt
                    ),
                    Translations.Get("save_title"),
                    MessageBoxButtons.YesNoCancel,
                    MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    Button_Add_Click(new object(), EventArgs.Empty);
                }
                else if (result == DialogResult.Cancel)
                {
                    List_Macros.SelectedIndex = previousindex;
                    return false;
                }
            }

            return true;
        }

        private void List_Macros_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (previousindex != List_Macros.SelectedIndex && VerifyChanges())
            {
                try
                {
                    previousindex = List_Macros.SelectedIndex;
                    string name = List_Macros.SelectedItem.ToString();
                    Button_Delete.Enabled = true;
                    Text_MacroTitle.Text = name;
                    previousMacroName = name;
                    Text_MacroContent.Text = File.ReadAllText(MacroFiles.MacrosDir + Path.DirectorySeparatorChar + name + MacroFiles.MacrosExt);
                    Button_Add.Enabled = false;
                    Button_Disable.Enabled = true;
                    if (name.Length < MacroFiles.DisablePrefix.Length || name.Substring(0, MacroFiles.DisablePrefix.Length) != MacroFiles.DisablePrefix)
                    {
                        Button_Disable.Text = Translations.Get("disable");
                    }
                    else
                    {
                        Button_Disable.Text = Translations.Get("enable");
                    }
                    somethingToSave = false;
                }
                catch (NullReferenceException) { }
            }
        }

        private void Button_About_Click(object sender, EventArgs e)
        {
            Item_About_Click(sender, e);
        }

        private void Button_Help_Click(object sender, EventArgs e)
        {
            if (File.Exists(Translations.Get("about_readme_file")))
            {
                Process.Start(Translations.Get("about_readme_file"));
            }
            else
            {
                MessageBox.Show(
                    String.Format(
                        Translations.Get("about_readme_file_not_found_text"),
                        Translations.Get("about_readme_file")
                    ),
                    Translations.Get("about_readme_file_not_found_title"),
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation
                );
            }
        }

        private void Button_Info_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(Translations.Get("info_instructions"), Translations.Get("info_title"), MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                testing = true;
            }
        }

        private void Button_New_Click(object sender, EventArgs e)
        {
            Nouvelle_Macro();
        }

        public bool Nouvelle_Macro()
        {
            bool confirm = VerifyChanges();
            if (confirm)
            {
                previousMacroName = "";
                previousindex = -1;
                List_Macros.SelectedIndex = -1;
                Button_Delete.Enabled = false;
                Text_MacroTitle.Text = Translations.Get("new_macro");
                Text_MacroContent.Text = "";
                Button_Add.Enabled = false;
                Button_Disable.Enabled = false;
                somethingToSave = false;
            }
            return confirm;
        }

        public void SetMacroContent(string content)
        {
            Text_MacroContent.Text = content;
        }

        private void Button_OpenFolder_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(MacroFiles.MacrosDir))
            {
                Process.Start(MacroFiles.MacrosDir);
            }
        }

        private void Text_MacroTitle_TextChanged(object sender, EventArgs e)
        {
            Text_MacroContent_TextChanged(sender, e);
        }

        private void Text_MacroContent_TextChanged(object sender, EventArgs e)
        {
            if (Text_MacroTitle.Text != "" && Text_MacroContent.Text != "")
            {
                somethingToSave = true;
                Button_Add.Enabled = true;
            }
            else
            {
                somethingToSave = false;
                Button_Add.Enabled = false;
            }
        }

        private void Button_KeyHelper_Click(object sender, EventArgs e)
        {
            KeyHelper KH = new KeyHelper();
            KH.handler = this;
            KH.ShowDialog(this);
        }

        private void Button_Recharger_Click(object sender, EventArgs e)
        {
            RefreshFiles();
            if (previousMacroName != "")
            {
                SelectItem(previousMacroName);
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                HideMainForm();
            }
        }

        private void HideMainForm()
        {
            this.WindowState = FormWindowState.Minimized;
            this.ShowInTaskbar = false;
            this.Opacity = 0;
            testing = false;
        }

        private void OpenMainForm()
        {
            this.Opacity = 1;
            this.ShowInTaskbar = true;
            this.WindowState = FormWindowState.Normal;
            this.Focus();
        }

        private void OnClose(object sender, FormClosingEventArgs e)
        {
            SettingsFile.Save(ActivateKey);
        }

        private void Exit_App()
        {
            NotificationAreaIcon.Visible = false;

            //The GlobalEventProvider DLL has an issue causing mouse & keyboard to freeze for 5 seconds if the app exits normally
            //So the only known way to exit and release immediately mouse & keyboard input is by requesting the current process to be killed
            ProcessStartInfo P = new ProcessStartInfo("taskkill", "/f /im " + Process.GetCurrentProcess().ProcessName + ".exe");
            P.WindowStyle = ProcessWindowStyle.Hidden;
            Process.Start(P); //Kill me, please :)
        }
    }
}
