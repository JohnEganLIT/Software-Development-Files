namespace PenaltyPoints {
    partial class Frame {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.dashBoard = new MetroFramework.Controls.MetroPanel();
            this.LeftNav = new MetroFramework.Controls.MetroPanel();
            this.metroPanel1 = new MetroFramework.Controls.MetroPanel();
            this.WorkSpace = new MetroFramework.Controls.MetroTabControl();
            this.StartTab = new MetroFramework.Controls.MetroTabPage();
            this.ReportsTab = new MetroFramework.Controls.MetroTabPage();
            this.ConfigTab = new MetroFramework.Controls.MetroTabPage();
            this.ConfigReset = new MetroFramework.Controls.MetroButton();
            this.ConfigSave = new MetroFramework.Controls.MetroButton();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.ConfigStyle = new MetroFramework.Controls.MetroComboBox();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.ConfigTitle = new MetroFramework.Controls.MetroLabel();
            this.ConfigTheme = new MetroFramework.Controls.MetroComboBox();
            this.RegulationTab = new MetroFramework.Controls.MetroTabPage();
            this.OffencesTab = new MetroFramework.Controls.MetroTabPage();
            this.WorkSpace.SuspendLayout();
            this.ConfigTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // dashBoard
            // 
            this.dashBoard.Dock = System.Windows.Forms.DockStyle.Left;
            this.dashBoard.HorizontalScrollbarBarColor = true;
            this.dashBoard.HorizontalScrollbarHighlightOnWheel = false;
            this.dashBoard.HorizontalScrollbarSize = 10;
            this.dashBoard.Location = new System.Drawing.Point(20, 60);
            this.dashBoard.Name = "dashBoard";
            this.dashBoard.Size = new System.Drawing.Size(320, 600);
            this.dashBoard.TabIndex = 0;
            this.dashBoard.VerticalScrollbarBarColor = true;
            this.dashBoard.VerticalScrollbarHighlightOnWheel = false;
            this.dashBoard.VerticalScrollbarSize = 10;
            // 
            // LeftNav
            // 
            this.LeftNav.Dock = System.Windows.Forms.DockStyle.Left;
            this.LeftNav.HorizontalScrollbarBarColor = true;
            this.LeftNav.HorizontalScrollbarHighlightOnWheel = false;
            this.LeftNav.HorizontalScrollbarSize = 10;
            this.LeftNav.Location = new System.Drawing.Point(340, 60);
            this.LeftNav.Name = "LeftNav";
            this.LeftNav.Size = new System.Drawing.Size(32, 600);
            this.LeftNav.TabIndex = 1;
            this.LeftNav.VerticalScrollbarBarColor = true;
            this.LeftNav.VerticalScrollbarHighlightOnWheel = false;
            this.LeftNav.VerticalScrollbarSize = 10;
            // 
            // metroPanel1
            // 
            this.metroPanel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.metroPanel1.HorizontalScrollbarBarColor = true;
            this.metroPanel1.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel1.HorizontalScrollbarSize = 10;
            this.metroPanel1.Location = new System.Drawing.Point(1088, 60);
            this.metroPanel1.Name = "metroPanel1";
            this.metroPanel1.Size = new System.Drawing.Size(32, 600);
            this.metroPanel1.TabIndex = 2;
            this.metroPanel1.VerticalScrollbarBarColor = true;
            this.metroPanel1.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel1.VerticalScrollbarSize = 10;
            // 
            // WorkSpace
            // 
            this.WorkSpace.Controls.Add(this.StartTab);
            this.WorkSpace.Controls.Add(this.ReportsTab);
            this.WorkSpace.Controls.Add(this.ConfigTab);
            this.WorkSpace.Controls.Add(this.RegulationTab);
            this.WorkSpace.Controls.Add(this.OffencesTab);
            this.WorkSpace.Dock = System.Windows.Forms.DockStyle.Fill;
            this.WorkSpace.FontSize = MetroFramework.Drawing.MetroFontSize.Large;
            this.WorkSpace.FontWeight = MetroFramework.Drawing.MetroFontWeight.Regular;
            this.WorkSpace.ItemSize = new System.Drawing.Size(160, 64);
            this.WorkSpace.Location = new System.Drawing.Point(372, 60);
            this.WorkSpace.Name = "WorkSpace";
            this.WorkSpace.SelectedIndex = 2;
            this.WorkSpace.ShowToolTips = true;
            this.WorkSpace.Size = new System.Drawing.Size(716, 600);
            this.WorkSpace.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.WorkSpace.TabIndex = 3;
            // 
            // StartTab
            // 
            this.StartTab.HorizontalScrollbarBarColor = true;
            this.StartTab.Location = new System.Drawing.Point(4, 68);
            this.StartTab.Name = "StartTab";
            this.StartTab.Size = new System.Drawing.Size(708, 528);
            this.StartTab.TabIndex = 0;
            this.StartTab.Text = "Start";
            this.StartTab.VerticalScrollbarBarColor = true;
            // 
            // ReportsTab
            // 
            this.ReportsTab.HorizontalScrollbarBarColor = true;
            this.ReportsTab.Location = new System.Drawing.Point(4, 68);
            this.ReportsTab.Name = "ReportsTab";
            this.ReportsTab.Size = new System.Drawing.Size(708, 528);
            this.ReportsTab.TabIndex = 3;
            this.ReportsTab.Text = "Reports";
            this.ReportsTab.VerticalScrollbarBarColor = true;
            // 
            // ConfigTab
            // 
            this.ConfigTab.Controls.Add(this.ConfigReset);
            this.ConfigTab.Controls.Add(this.ConfigSave);
            this.ConfigTab.Controls.Add(this.metroLabel3);
            this.ConfigTab.Controls.Add(this.ConfigStyle);
            this.ConfigTab.Controls.Add(this.metroLabel2);
            this.ConfigTab.Controls.Add(this.ConfigTitle);
            this.ConfigTab.Controls.Add(this.ConfigTheme);
            this.ConfigTab.HorizontalScrollbarBarColor = true;
            this.ConfigTab.Location = new System.Drawing.Point(4, 68);
            this.ConfigTab.Name = "ConfigTab";
            this.ConfigTab.Size = new System.Drawing.Size(708, 528);
            this.ConfigTab.TabIndex = 4;
            this.ConfigTab.Text = "Config";
            this.ConfigTab.VerticalScrollbarBarColor = true;
            // 
            // ConfigReset
            // 
            this.ConfigReset.Location = new System.Drawing.Point(292, 458);
            this.ConfigReset.Name = "ConfigReset";
            this.ConfigReset.Size = new System.Drawing.Size(128, 32);
            this.ConfigReset.TabIndex = 8;
            this.ConfigReset.Text = "Reset";
            this.ConfigReset.Click += new System.EventHandler(this.OnConfigResetClick);
            // 
            // ConfigSave
            // 
            this.ConfigSave.Location = new System.Drawing.Point(555, 458);
            this.ConfigSave.Name = "ConfigSave";
            this.ConfigSave.Size = new System.Drawing.Size(128, 32);
            this.ConfigSave.TabIndex = 7;
            this.ConfigSave.Text = "Save";
            this.ConfigSave.Click += new System.EventHandler(this.OnConfigSaveClick);
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.FontSize = MetroFramework.Drawing.MetroFontSize.Large;
            this.metroLabel3.Location = new System.Drawing.Point(470, 149);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(47, 25);
            this.metroLabel3.TabIndex = 6;
            this.metroLabel3.Text = "Style";
            // 
            // ConfigStyle
            // 
            this.ConfigStyle.FormattingEnabled = true;
            this.ConfigStyle.ItemHeight = 23;
            this.ConfigStyle.Location = new System.Drawing.Point(555, 145);
            this.ConfigStyle.Name = "ConfigStyle";
            this.ConfigStyle.Size = new System.Drawing.Size(128, 29);
            this.ConfigStyle.TabIndex = 5;
            this.ConfigStyle.SelectedIndexChanged += new System.EventHandler(this.OnConfigStyleChanged);
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.FontSize = MetroFramework.Drawing.MetroFontSize.Large;
            this.metroLabel2.Location = new System.Drawing.Point(470, 103);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(64, 25);
            this.metroLabel2.TabIndex = 4;
            this.metroLabel2.Text = "Theme";
            // 
            // ConfigTitle
            // 
            this.ConfigTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.ConfigTitle.FontSize = MetroFramework.Drawing.MetroFontSize.Large;
            this.ConfigTitle.FontWeight = MetroFramework.Drawing.MetroFontWeight.Regular;
            this.ConfigTitle.Location = new System.Drawing.Point(0, 0);
            this.ConfigTitle.Name = "ConfigTitle";
            this.ConfigTitle.Size = new System.Drawing.Size(708, 88);
            this.ConfigTitle.TabIndex = 3;
            this.ConfigTitle.Text = "User Preferences Configuration";
            this.ConfigTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ConfigTheme
            // 
            this.ConfigTheme.FormattingEnabled = true;
            this.ConfigTheme.ItemHeight = 23;
            this.ConfigTheme.Location = new System.Drawing.Point(555, 99);
            this.ConfigTheme.Name = "ConfigTheme";
            this.ConfigTheme.Size = new System.Drawing.Size(128, 29);
            this.ConfigTheme.TabIndex = 2;
            this.ConfigTheme.SelectedIndexChanged += new System.EventHandler(this.OnConfigThemeChanged);
            // 
            // RegulationTab
            // 
            this.RegulationTab.HorizontalScrollbarBarColor = true;
            this.RegulationTab.Location = new System.Drawing.Point(4, 68);
            this.RegulationTab.Name = "RegulationTab";
            this.RegulationTab.Size = new System.Drawing.Size(708, 528);
            this.RegulationTab.TabIndex = 2;
            this.RegulationTab.Text = "Regulations";
            this.RegulationTab.VerticalScrollbarBarColor = true;
            // 
            // OffencesTab
            // 
            this.OffencesTab.HorizontalScrollbarBarColor = true;
            this.OffencesTab.Location = new System.Drawing.Point(4, 68);
            this.OffencesTab.Name = "OffencesTab";
            this.OffencesTab.Size = new System.Drawing.Size(708, 528);
            this.OffencesTab.TabIndex = 1;
            this.OffencesTab.Text = "Offences";
            this.OffencesTab.VerticalScrollbarBarColor = true;
            // 
            // Frame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1140, 680);
            this.Controls.Add(this.WorkSpace);
            this.Controls.Add(this.metroPanel1);
            this.Controls.Add(this.LeftNav);
            this.Controls.Add(this.dashBoard);
            this.Name = "Frame";
            this.Text = "Penalty Points Bureau";
            this.WorkSpace.ResumeLayout(false);
            this.ConfigTab.ResumeLayout(false);
            this.ConfigTab.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        public MetroFramework.Controls.MetroPanel dashBoard;
        private MetroFramework.Controls.MetroPanel LeftNav;
        private MetroFramework.Controls.MetroPanel metroPanel1;
        private MetroFramework.Controls.MetroTabControl WorkSpace;
        private MetroFramework.Controls.MetroTabPage StartTab;
        private MetroFramework.Controls.MetroTabPage OffencesTab;
        private MetroFramework.Controls.MetroTabPage RegulationTab;
        private MetroFramework.Controls.MetroTabPage ReportsTab;
        private MetroFramework.Controls.MetroTabPage ConfigTab;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroLabel ConfigTitle;
        private MetroFramework.Controls.MetroComboBox ConfigTheme;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroComboBox ConfigStyle;
        private MetroFramework.Controls.MetroButton ConfigReset;
        private MetroFramework.Controls.MetroButton ConfigSave;
    }
}