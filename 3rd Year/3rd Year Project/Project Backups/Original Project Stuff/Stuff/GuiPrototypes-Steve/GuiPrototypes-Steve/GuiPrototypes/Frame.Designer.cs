namespace GuiPrototypes {
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
            this.themeConfig = new MetroFramework.Controls.MetroComboBox();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.styleConfig = new MetroFramework.Controls.MetroComboBox();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.saveConfig = new System.Windows.Forms.Button();
            this.resetConfig = new System.Windows.Forms.Button();
            this.dashboardForm = new GuiPrototypes.Dashboard();
            this.loginForm = new GuiPrototypes.LoginForm();
            this.ForgotPasswordForm = new GuiPrototypes.ForgotPassword();
            this.UserIDResetForm = new GuiPrototypes.UserIDReset();
            this.SuspendLayout();
            // 
            // themeConfig
            // 
            this.themeConfig.FormattingEnabled = true;
            this.themeConfig.ItemHeight = 23;
            this.themeConfig.Location = new System.Drawing.Point(713, 16);
            this.themeConfig.Name = "themeConfig";
            this.themeConfig.Size = new System.Drawing.Size(121, 29);
            this.themeConfig.TabIndex = 2;
            this.themeConfig.SelectedIndexChanged += new System.EventHandler(this.OnThemeConfigChanged);
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.FontSize = MetroFramework.Drawing.MetroFontSize.Large;
            this.metroLabel1.Location = new System.Drawing.Point(643, 20);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(64, 25);
            this.metroLabel1.TabIndex = 3;
            this.metroLabel1.Text = "Theme";
            // 
            // styleConfig
            // 
            this.styleConfig.FormattingEnabled = true;
            this.styleConfig.ItemHeight = 23;
            this.styleConfig.Location = new System.Drawing.Point(503, 16);
            this.styleConfig.Name = "styleConfig";
            this.styleConfig.Size = new System.Drawing.Size(121, 29);
            this.styleConfig.TabIndex = 4;
            this.styleConfig.SelectedIndexChanged += new System.EventHandler(this.OnStyleConfigChanged);
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.FontSize = MetroFramework.Drawing.MetroFontSize.Large;
            this.metroLabel2.Location = new System.Drawing.Point(450, 20);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(47, 25);
            this.metroLabel2.TabIndex = 5;
            this.metroLabel2.Text = "Style";
            // 
            // saveConfig
            // 
            this.saveConfig.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveConfig.Location = new System.Drawing.Point(359, 16);
            this.saveConfig.Name = "saveConfig";
            this.saveConfig.Size = new System.Drawing.Size(75, 32);
            this.saveConfig.TabIndex = 6;
            this.saveConfig.Text = "Save";
            this.saveConfig.UseVisualStyleBackColor = true;
            this.saveConfig.Click += new System.EventHandler(this.OnConfigSaveClick);
            // 
            // resetConfig
            // 
            this.resetConfig.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.resetConfig.Location = new System.Drawing.Point(278, 16);
            this.resetConfig.Name = "resetConfig";
            this.resetConfig.Size = new System.Drawing.Size(75, 32);
            this.resetConfig.TabIndex = 7;
            this.resetConfig.Text = "Reset";
            this.resetConfig.UseVisualStyleBackColor = true;
            this.resetConfig.Click += new System.EventHandler(this.OnConfigResetClick);
            // 
            // dashboardForm
            // 
            this.dashboardForm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dashboardForm.Location = new System.Drawing.Point(20, 60);
            this.dashboardForm.Name = "dashboardForm";
            this.dashboardForm.Size = new System.Drawing.Size(874, 602);
            this.dashboardForm.TabIndex = 1;
            this.dashboardForm.Load += new System.EventHandler(this.dashboard_Load);
            // 
            // loginForm
            // 
            this.loginForm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.loginForm.Location = new System.Drawing.Point(20, 60);
            this.loginForm.Name = "loginForm";
            this.loginForm.Size = new System.Drawing.Size(874, 602);
            this.loginForm.TabIndex = 0;
            // 
            // ForgotPasswordForm
            // 
            this.ForgotPasswordForm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ForgotPasswordForm.Location = new System.Drawing.Point(20, 60);
            this.ForgotPasswordForm.Name = "ForgotPassword";
            this.ForgotPasswordForm.Size = new System.Drawing.Size(793, 681);
            this.ForgotPasswordForm.TabIndex = 0;
            // 
            // UserIDResetForm
            // 
            this.UserIDResetForm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.UserIDResetForm.Location = new System.Drawing.Point(20, 60);
            this.UserIDResetForm.Name = "UserIDReset";
            this.UserIDResetForm.Size = new System.Drawing.Size(793, 681);
            this.UserIDResetForm.TabIndex = 0;
            // 
            // Frame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(914, 682);
            this.Controls.Add(this.resetConfig);
            this.Controls.Add(this.saveConfig);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.styleConfig);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.themeConfig);
            this.Controls.Add(this.dashboardForm);
            this.Controls.Add(this.loginForm);
            this.Controls.Add(this.ForgotPasswordForm);
            this.Controls.Add(this.UserIDResetForm);
            this.Name = "Frame";
            this.Text = "Penalty Points Bureau";
            this.Load += new System.EventHandler(this.Frame_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public LoginForm loginForm;
        public Dashboard dashboardForm;
        public ForgotPassword ForgotPasswordForm;
        public UserIDReset UserIDResetForm;
        private MetroFramework.Controls.MetroComboBox themeConfig;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroComboBox styleConfig;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private System.Windows.Forms.Button saveConfig;
        private System.Windows.Forms.Button resetConfig;
    }
}

