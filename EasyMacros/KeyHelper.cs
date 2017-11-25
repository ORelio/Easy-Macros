using System;
using System.Windows.Forms;

namespace EasyMacros
{
    public partial class KeyHelper : Form
    {
        public static string BoxContent = "";
        public static bool Form_Visible = false;
        public FormMain handler;
        Timer timer = new Timer();

        public KeyHelper()
        {
            InitializeComponent();

            timer.Interval = 150;
            timer.Tick += new EventHandler(timer_Tick);
            timer.Start();

            BoxContent = "";
            Form_Visible = true;
            Btn_CreateMacro.Enabled = false;
        }

        private void Btn_Vider_Click(object sender, EventArgs e)
        {
            BoxContent = "";
            Btn_CreateMacro.Enabled = false;
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            Box_Scratchpad.Text = BoxContent;
            if (BoxContent != "")
            {
                Btn_CreateMacro.Enabled = true;
            }
        }

        private void Btn_Copier_Click(object sender, EventArgs e)
        {
            System.Windows.Clipboard.SetData(DataFormats.Text, BoxContent);
        }

        private void Btn_OK_Click(object sender, EventArgs e)
        {
            Form_Visible = false;
            Close();
        }

        private void Btn_CreateMacro_Click(object sender, EventArgs e)
        {
            if (handler.Nouvelle_Macro())
            {
                string shortcut = BoxContent.Replace("\n", "+").Trim('+');
                handler.SetMacroContent("RewriteMacro " + shortcut + "\n");
                Btn_OK_Click(sender, e);
            }
        }
    }
}
