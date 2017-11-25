namespace EasyMacros
{
    partial class KeyHelper
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Box_Scratchpad = new System.Windows.Forms.RichTextBox();
            this.label_help = new System.Windows.Forms.Label();
            this.Btn_OK = new System.Windows.Forms.Button();
            this.Btn_Clear = new System.Windows.Forms.Button();
            this.Btn_Copy = new System.Windows.Forms.Button();
            this.Btn_CreateMacro = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Box_Scratchpad
            // 
            this.Box_Scratchpad.Location = new System.Drawing.Point(12, 46);
            this.Box_Scratchpad.Name = "Box_Scratchpad";
            this.Box_Scratchpad.ReadOnly = true;
            this.Box_Scratchpad.Size = new System.Drawing.Size(260, 298);
            this.Box_Scratchpad.TabIndex = 0;
            this.Box_Scratchpad.Text = "";
            // 
            // label_help
            // 
            this.label_help.AutoSize = true;
            this.label_help.Location = new System.Drawing.Point(12, 9);
            this.label_help.Name = "label_help";
            this.label_help.Size = new System.Drawing.Size(245, 26);
            this.label_help.TabIndex = 1;
            this.label_help.Text = Translations.Get("scratchpad_instructions");
            // 
            // Btn_OK
            // 
            this.Btn_OK.Location = new System.Drawing.Point(197, 354);
            this.Btn_OK.Name = "Btn_OK";
            this.Btn_OK.Size = new System.Drawing.Size(75, 23);
            this.Btn_OK.TabIndex = 2;
            this.Btn_OK.Text = Translations.Get("close");
            this.Btn_OK.UseVisualStyleBackColor = true;
            this.Btn_OK.Click += new System.EventHandler(this.Btn_OK_Click);
            // 
            // Btn_Clear
            // 
            this.Btn_Clear.Location = new System.Drawing.Point(14, 354);
            this.Btn_Clear.Name = "Btn_Clear";
            this.Btn_Clear.Size = new System.Drawing.Size(48, 23);
            this.Btn_Clear.TabIndex = 3;
            this.Btn_Clear.Text = Translations.Get("clear");
            this.Btn_Clear.UseVisualStyleBackColor = true;
            this.Btn_Clear.Click += new System.EventHandler(this.Btn_Vider_Click);
            // 
            // Btn_Copy
            // 
            this.Btn_Copy.Location = new System.Drawing.Point(68, 354);
            this.Btn_Copy.Name = "Btn_Copy";
            this.Btn_Copy.Size = new System.Drawing.Size(48, 23);
            this.Btn_Copy.TabIndex = 4;
            this.Btn_Copy.Text = Translations.Get("copy");
            this.Btn_Copy.UseVisualStyleBackColor = true;
            this.Btn_Copy.Click += new System.EventHandler(this.Btn_Copier_Click);
            // 
            // Btn_CreateMacro
            // 
            this.Btn_CreateMacro.Location = new System.Drawing.Point(122, 354);
            this.Btn_CreateMacro.Name = "Btn_CreateMacro";
            this.Btn_CreateMacro.Size = new System.Drawing.Size(48, 23);
            this.Btn_CreateMacro.TabIndex = 5;
            this.Btn_CreateMacro.Text = Translations.Get("macro");
            this.Btn_CreateMacro.UseVisualStyleBackColor = true;
            this.Btn_CreateMacro.Click += new System.EventHandler(this.Btn_CreateMacro_Click);
            // 
            // KeyHelper
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 385);
            this.Controls.Add(this.Btn_CreateMacro);
            this.Controls.Add(this.Btn_Copy);
            this.Controls.Add(this.Btn_Clear);
            this.Controls.Add(this.Btn_OK);
            this.Controls.Add(this.label_help);
            this.Controls.Add(this.Box_Scratchpad);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "KeyHelper";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = Translations.Get("scratchpad_title");
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox Box_Scratchpad;
        private System.Windows.Forms.Label label_help;
        private System.Windows.Forms.Button Btn_OK;
        private System.Windows.Forms.Button Btn_Clear;
        private System.Windows.Forms.Button Btn_Copy;
        private System.Windows.Forms.Button Btn_CreateMacro;
    }
}