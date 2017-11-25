namespace EasyMacros
{
    partial class FormMain
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.NotificationAreaIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.NotificationAreaMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.Item_Title = new System.Windows.Forms.ToolStripMenuItem();
            this.Item_Separator = new System.Windows.Forms.ToolStripSeparator();
            this.Item_About = new System.Windows.Forms.ToolStripMenuItem();
            this.Item_MainForm = new System.Windows.Forms.ToolStripMenuItem();
            this.Item_Exit = new System.Windows.Forms.ToolStripMenuItem();
            this.Item_Separator_2 = new System.Windows.Forms.ToolStripSeparator();
            this.Item_CloseMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.List_Macros = new System.Windows.Forms.ListBox();
            this.Box_Macros = new System.Windows.Forms.GroupBox();
            this.Button_Reload = new System.Windows.Forms.Button();
            this.Button_Disable = new System.Windows.Forms.Button();
            this.Button_OpenFolder = new System.Windows.Forms.Button();
            this.Button_Delete = new System.Windows.Forms.Button();
            this.Buton_ActivateKey = new System.Windows.Forms.Button();
            this.Button_Add = new System.Windows.Forms.Button();
            this.Box_EditMacro = new System.Windows.Forms.GroupBox();
            this.Button_KeyHelper = new System.Windows.Forms.Button();
            this.Button_New = new System.Windows.Forms.Button();
            this.Button_About = new System.Windows.Forms.Button();
            this.Button_Exit = new System.Windows.Forms.Button();
            this.Button_Minimize = new System.Windows.Forms.Button();
            this.Button_Info = new System.Windows.Forms.Button();
            this.Button_Help = new System.Windows.Forms.Button();
            this.Text_MacroContent = new System.Windows.Forms.RichTextBox();
            this.Text_MacroTitle = new System.Windows.Forms.TextBox();
            this.NotificationAreaMenu.SuspendLayout();
            this.Box_Macros.SuspendLayout();
            this.Box_EditMacro.SuspendLayout();
            this.SuspendLayout();
            // 
            // NotificationAreaIcon
            // 
            this.NotificationAreaIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("TrayIcon.Icon")));
            this.NotificationAreaIcon.Text = Program.Name;
            this.NotificationAreaIcon.Visible = true;
            this.NotificationAreaIcon.MouseClick += new System.Windows.Forms.MouseEventHandler(this.TrayIcon_MouseClick);
            // 
            // TrayMenu
            // 
            this.NotificationAreaMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Item_Title,
            this.Item_Separator,
            this.Item_About,
            this.Item_MainForm,
            this.Item_Exit,
            this.Item_Separator_2,
            this.Item_CloseMenu});
            this.NotificationAreaMenu.Name = "TrayMenu";
            this.NotificationAreaMenu.Size = new System.Drawing.Size(164, 148);
            // 
            // Item_Title
            // 
            this.Item_Title.Enabled = false;
            this.Item_Title.Name = "Item_Title";
            this.Item_Title.Size = new System.Drawing.Size(175, 22);
            this.Item_Title.Text = Translations.Get("about_title");
            // 
            // Item_Separator
            // 
            this.Item_Separator.Name = "Item_Separator";
            this.Item_Separator.Size = new System.Drawing.Size(172, 6);
            // 
            // Item_About
            // 
            this.Item_About.Name = "Item_About";
            this.Item_About.Size = new System.Drawing.Size(175, 22);
            this.Item_About.Text = Translations.Get("about");
            this.Item_About.Click += new System.EventHandler(this.Item_About_Click);
            // 
            // Item_MainForm
            // 
            this.Item_MainForm.Name = "Item_MainForm";
            this.Item_MainForm.Size = new System.Drawing.Size(175, 22);
            this.Item_MainForm.Text = Translations.Get("settings");
            this.Item_MainForm.Click += new System.EventHandler(this.Item_MainForm_Click);
            // 
            // Item_Exit
            // 
            this.Item_Exit.Name = "Item_Exit";
            this.Item_Exit.Size = new System.Drawing.Size(175, 22);
            this.Item_Exit.Text = Translations.Get("exit");
            this.Item_Exit.Click += new System.EventHandler(this.Item_Exit_Click);
            // 
            // Item_Separator_2
            // 
            this.Item_Separator_2.Name = "Item_Separator_2";
            this.Item_Separator_2.Size = new System.Drawing.Size(172, 6);
            // 
            // Item_CloseMenu
            // 
            this.Item_CloseMenu.Name = "Item_CloseMenu";
            this.Item_CloseMenu.Size = new System.Drawing.Size(175, 22);
            this.Item_CloseMenu.Text = Translations.Get("close_this_menu");
            // 
            // List_Macros
            // 
            this.List_Macros.FormattingEnabled = true;
            this.List_Macros.Location = new System.Drawing.Point(13, 19);
            this.List_Macros.Name = "List_Macros";
            this.List_Macros.Size = new System.Drawing.Size(251, 108);
            this.List_Macros.TabIndex = 0;
            this.List_Macros.SelectedIndexChanged += new System.EventHandler(this.List_Macros_SelectedIndexChanged);
            // 
            // Box_Macros
            // 
            this.Box_Macros.Controls.Add(this.Button_Reload);
            this.Box_Macros.Controls.Add(this.Button_Disable);
            this.Box_Macros.Controls.Add(this.Button_OpenFolder);
            this.Box_Macros.Controls.Add(this.Button_Delete);
            this.Box_Macros.Controls.Add(this.List_Macros);
            this.Box_Macros.Location = new System.Drawing.Point(12, 12);
            this.Box_Macros.Name = "Box_Macros";
            this.Box_Macros.Size = new System.Drawing.Size(369, 139);
            this.Box_Macros.TabIndex = 2;
            this.Box_Macros.TabStop = false;
            this.Box_Macros.Text = Translations.Get("macro_definitions");
            // 
            // Button_Recharger
            // 
            this.Button_Reload.Location = new System.Drawing.Point(279, 46);
            this.Button_Reload.Name = "Button_Reload";
            this.Button_Reload.Size = new System.Drawing.Size(75, 23);
            this.Button_Reload.TabIndex = 4;
            this.Button_Reload.Text = Translations.Get("refresh");
            this.Button_Reload.UseVisualStyleBackColor = true;
            this.Button_Reload.Click += new System.EventHandler(this.Button_Recharger_Click);
            // 
            // Button_Desactiver
            // 
            this.Button_Disable.Enabled = false;
            this.Button_Disable.Location = new System.Drawing.Point(279, 75);
            this.Button_Disable.Name = "Button_Disable";
            this.Button_Disable.Size = new System.Drawing.Size(75, 23);
            this.Button_Disable.TabIndex = 3;
            this.Button_Disable.Text = Translations.Get("disable");
            this.Button_Disable.UseVisualStyleBackColor = true;
            this.Button_Disable.Click += new System.EventHandler(this.Button_Disable_Click);
            // 
            // Button_OpenFolder
            // 
            this.Button_OpenFolder.Location = new System.Drawing.Point(279, 17);
            this.Button_OpenFolder.Name = "Button_OpenFolder";
            this.Button_OpenFolder.Size = new System.Drawing.Size(75, 23);
            this.Button_OpenFolder.TabIndex = 1;
            this.Button_OpenFolder.Text = Translations.Get("explorer");
            this.Button_OpenFolder.UseVisualStyleBackColor = true;
            this.Button_OpenFolder.Click += new System.EventHandler(this.Button_OpenFolder_Click);
            // 
            // Button_Supprimer
            // 
            this.Button_Delete.Enabled = false;
            this.Button_Delete.Location = new System.Drawing.Point(279, 104);
            this.Button_Delete.Name = "Button_Delete";
            this.Button_Delete.Size = new System.Drawing.Size(75, 23);
            this.Button_Delete.TabIndex = 2;
            this.Button_Delete.Text = Translations.Get("delete");
            this.Button_Delete.UseVisualStyleBackColor = true;
            this.Button_Delete.Click += new System.EventHandler(this.Button_Delete_Click);
            // 
            // Buton_MasterKey
            // 
            this.Buton_ActivateKey.Location = new System.Drawing.Point(279, 135);
            this.Buton_ActivateKey.Name = "Buton_ActivateKey";
            this.Buton_ActivateKey.Size = new System.Drawing.Size(75, 23);
            this.Buton_ActivateKey.TabIndex = 5;
            this.Buton_ActivateKey.Text = Translations.Get("activate");
            this.Buton_ActivateKey.UseVisualStyleBackColor = true;
            this.Buton_ActivateKey.Click += new System.EventHandler(this.Buton_ActivateKey_Click);
            // 
            // Button_Ajouter
            // 
            this.Button_Add.Enabled = false;
            this.Button_Add.Location = new System.Drawing.Point(279, 48);
            this.Button_Add.Name = "Button_Add";
            this.Button_Add.Size = new System.Drawing.Size(75, 23);
            this.Button_Add.TabIndex = 3;
            this.Button_Add.Text = Translations.Get("save");
            this.Button_Add.UseVisualStyleBackColor = true;
            this.Button_Add.Click += new System.EventHandler(this.Button_Add_Click);
            // 
            // Box_EditerMacro
            // 
            this.Box_EditMacro.Controls.Add(this.Button_KeyHelper);
            this.Box_EditMacro.Controls.Add(this.Button_New);
            this.Box_EditMacro.Controls.Add(this.Button_About);
            this.Box_EditMacro.Controls.Add(this.Button_Exit);
            this.Box_EditMacro.Controls.Add(this.Button_Minimize);
            this.Box_EditMacro.Controls.Add(this.Button_Info);
            this.Box_EditMacro.Controls.Add(this.Buton_ActivateKey);
            this.Box_EditMacro.Controls.Add(this.Button_Help);
            this.Box_EditMacro.Controls.Add(this.Text_MacroContent);
            this.Box_EditMacro.Controls.Add(this.Button_Add);
            this.Box_EditMacro.Controls.Add(this.Text_MacroTitle);
            this.Box_EditMacro.Location = new System.Drawing.Point(12, 159);
            this.Box_EditMacro.Name = "Box_EditMacro";
            this.Box_EditMacro.Size = new System.Drawing.Size(369, 343);
            this.Box_EditMacro.TabIndex = 3;
            this.Box_EditMacro.TabStop = false;
            this.Box_EditMacro.Text = Translations.Get("macro_editor");
            // 
            // Button_KeyHelper
            // 
            this.Button_KeyHelper.Location = new System.Drawing.Point(279, 164);
            this.Button_KeyHelper.Name = "Button_KeyHelper";
            this.Button_KeyHelper.Size = new System.Drawing.Size(75, 23);
            this.Button_KeyHelper.TabIndex = 10;
            this.Button_KeyHelper.Text = Translations.Get("scratchpad");
            this.Button_KeyHelper.UseVisualStyleBackColor = true;
            this.Button_KeyHelper.Click += new System.EventHandler(this.Button_KeyHelper_Click);
            // 
            // Button_New
            // 
            this.Button_New.Location = new System.Drawing.Point(279, 19);
            this.Button_New.Name = "Button_New";
            this.Button_New.Size = new System.Drawing.Size(75, 23);
            this.Button_New.TabIndex = 2;
            this.Button_New.Text = Translations.Get("new");
            this.Button_New.UseVisualStyleBackColor = true;
            this.Button_New.Click += new System.EventHandler(this.Button_New_Click);
            // 
            // Button_About
            // 
            this.Button_About.Location = new System.Drawing.Point(279, 252);
            this.Button_About.Name = "Button_About";
            this.Button_About.Size = new System.Drawing.Size(75, 23);
            this.Button_About.TabIndex = 7;
            this.Button_About.Text = Translations.Get("about");
            this.Button_About.UseVisualStyleBackColor = true;
            this.Button_About.Click += new System.EventHandler(this.Button_About_Click);
            // 
            // Button_Quitter
            // 
            this.Button_Exit.Location = new System.Drawing.Point(279, 310);
            this.Button_Exit.Name = "Button_Exit";
            this.Button_Exit.Size = new System.Drawing.Size(75, 23);
            this.Button_Exit.TabIndex = 9;
            this.Button_Exit.Text = Translations.Get("exit");
            this.Button_Exit.UseVisualStyleBackColor = true;
            this.Button_Exit.Click += new System.EventHandler(this.Button_Exit_Click);
            // 
            // Button_Minimize
            // 
            this.Button_Minimize.Location = new System.Drawing.Point(279, 281);
            this.Button_Minimize.Name = "Button_Minimize";
            this.Button_Minimize.Size = new System.Drawing.Size(75, 23);
            this.Button_Minimize.TabIndex = 8;
            this.Button_Minimize.Text = Translations.Get("minimize");
            this.Button_Minimize.UseVisualStyleBackColor = true;
            this.Button_Minimize.Click += new System.EventHandler(this.Button_Minimize_Click);
            // 
            // Button_Infos
            // 
            this.Button_Info.Location = new System.Drawing.Point(279, 106);
            this.Button_Info.Name = "Button_Infos";
            this.Button_Info.Size = new System.Drawing.Size(75, 23);
            this.Button_Info.TabIndex = 4;
            this.Button_Info.Text = Translations.Get("windows");
            this.Button_Info.UseVisualStyleBackColor = true;
            this.Button_Info.Click += new System.EventHandler(this.Button_Info_Click);
            // 
            // Button_Aide
            // 
            this.Button_Help.Location = new System.Drawing.Point(279, 193);
            this.Button_Help.Name = "Button_Aide";
            this.Button_Help.Size = new System.Drawing.Size(75, 23);
            this.Button_Help.TabIndex = 6;
            this.Button_Help.Text = Translations.Get("help_file");
            this.Button_Help.UseVisualStyleBackColor = true;
            this.Button_Help.Click += new System.EventHandler(this.Button_Help_Click);
            // 
            // Text_MacroContent
            // 
            this.Text_MacroContent.DetectUrls = false;
            this.Text_MacroContent.Location = new System.Drawing.Point(13, 46);
            this.Text_MacroContent.Name = "Text_MacroContent";
            this.Text_MacroContent.Size = new System.Drawing.Size(251, 287);
            this.Text_MacroContent.TabIndex = 1;
            this.Text_MacroContent.Text = "";
            this.Text_MacroContent.WordWrap = false;
            this.Text_MacroContent.TextChanged += new System.EventHandler(this.Text_MacroContent_TextChanged);
            // 
            // Text_MacroTitle
            // 
            this.Text_MacroTitle.Location = new System.Drawing.Point(13, 19);
            this.Text_MacroTitle.Name = "Text_MacroTitle";
            this.Text_MacroTitle.Size = new System.Drawing.Size(251, 20);
            this.Text_MacroTitle.TabIndex = 0;
            this.Text_MacroTitle.Text = Translations.Get("new_macro");
            this.Text_MacroTitle.TextChanged += new System.EventHandler(this.Text_MacroTitle_TextChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(392, 511);
            this.Controls.Add(this.Box_Macros);
            this.Controls.Add(this.Box_EditMacro);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = Program.Name;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OnClose);
            this.NotificationAreaMenu.ResumeLayout(false);
            this.Box_Macros.ResumeLayout(false);
            this.Box_EditMacro.ResumeLayout(false);
            this.Box_EditMacro.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NotifyIcon NotificationAreaIcon;
        private System.Windows.Forms.ContextMenuStrip NotificationAreaMenu;
        private System.Windows.Forms.ToolStripMenuItem Item_Title;
        private System.Windows.Forms.ToolStripSeparator Item_Separator;
        private System.Windows.Forms.ToolStripMenuItem Item_About;
        private System.Windows.Forms.ToolStripMenuItem Item_Exit;
        private System.Windows.Forms.ToolStripSeparator Item_Separator_2;
        private System.Windows.Forms.ToolStripMenuItem Item_CloseMenu;
        private System.Windows.Forms.ToolStripMenuItem Item_MainForm;
        private System.Windows.Forms.ListBox List_Macros;
        private System.Windows.Forms.GroupBox Box_Macros;
        private System.Windows.Forms.GroupBox Box_EditMacro;
        private System.Windows.Forms.Button Button_Exit;
        private System.Windows.Forms.Button Button_Minimize;
        private System.Windows.Forms.Button Button_Delete;
        private System.Windows.Forms.Button Button_Add;
        private System.Windows.Forms.Button Buton_ActivateKey;
        private System.Windows.Forms.Button Button_About;
        private System.Windows.Forms.RichTextBox Text_MacroContent;
        private System.Windows.Forms.TextBox Text_MacroTitle;
        private System.Windows.Forms.Button Button_Help;
        private System.Windows.Forms.Button Button_Info;
        private System.Windows.Forms.Button Button_OpenFolder;
        private System.Windows.Forms.Button Button_New;
        private System.Windows.Forms.Button Button_KeyHelper;
        private System.Windows.Forms.Button Button_Disable;
        private System.Windows.Forms.Button Button_Reload;
    }
}

