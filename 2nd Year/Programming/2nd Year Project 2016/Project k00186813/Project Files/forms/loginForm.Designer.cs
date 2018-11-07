namespace Limerick_Game_Library
{
    partial class loginForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(loginForm));
            this.loginBtn = new System.Windows.Forms.Button();
            this.passwordLabel = new System.Windows.Forms.Label();
            this.employeeIDLabel = new System.Windows.Forms.Label();
            this.passTxtBox = new System.Windows.Forms.TextBox();
            this.empIDTxtBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // loginBtn
            // 
            this.loginBtn.Enabled = false;
            this.loginBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loginBtn.Location = new System.Drawing.Point(94, 160);
            this.loginBtn.Margin = new System.Windows.Forms.Padding(2);
            this.loginBtn.Name = "loginBtn";
            this.loginBtn.Size = new System.Drawing.Size(94, 45);
            this.loginBtn.TabIndex = 3;
            this.loginBtn.Text = "Login";
            this.loginBtn.UseVisualStyleBackColor = true;
            this.loginBtn.Click += new System.EventHandler(this.loginBtn_Click);
            // 
            // passwordLabel
            // 
            this.passwordLabel.AutoSize = true;
            this.passwordLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.passwordLabel.Location = new System.Drawing.Point(100, 87);
            this.passwordLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.passwordLabel.Name = "passwordLabel";
            this.passwordLabel.Size = new System.Drawing.Size(78, 20);
            this.passwordLabel.TabIndex = 2;
            this.passwordLabel.Text = "Password";
            // 
            // employeeIDLabel
            // 
            this.employeeIDLabel.AutoSize = true;
            this.employeeIDLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.employeeIDLabel.Location = new System.Drawing.Point(92, 37);
            this.employeeIDLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.employeeIDLabel.Name = "employeeIDLabel";
            this.employeeIDLabel.Size = new System.Drawing.Size(100, 20);
            this.employeeIDLabel.TabIndex = 7;
            this.employeeIDLabel.Text = "Employee ID";
            // 
            // passTxtBox
            // 
            this.passTxtBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.passTxtBox.Location = new System.Drawing.Point(40, 110);
            this.passTxtBox.Margin = new System.Windows.Forms.Padding(2);
            this.passTxtBox.MaxLength = 25;
            this.passTxtBox.Name = "passTxtBox";
            this.passTxtBox.PasswordChar = '*';
            this.passTxtBox.Size = new System.Drawing.Size(204, 26);
            this.passTxtBox.TabIndex = 2;
            this.passTxtBox.TextChanged += new System.EventHandler(this.passTxtBox_TextChanged);
            // 
            // empIDTxtBox
            // 
            this.empIDTxtBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.empIDTxtBox.Location = new System.Drawing.Point(40, 59);
            this.empIDTxtBox.Margin = new System.Windows.Forms.Padding(2);
            this.empIDTxtBox.MaxLength = 10;
            this.empIDTxtBox.Name = "empIDTxtBox";
            this.empIDTxtBox.Size = new System.Drawing.Size(204, 26);
            this.empIDTxtBox.TabIndex = 1;
            this.empIDTxtBox.TextChanged += new System.EventHandler(this.empIDTxtBox_TextChanged);
            // 
            // loginForm
            // 
            this.AcceptButton = this.loginBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(284, 241);
            this.Controls.Add(this.loginBtn);
            this.Controls.Add(this.passwordLabel);
            this.Controls.Add(this.employeeIDLabel);
            this.Controls.Add(this.passTxtBox);
            this.Controls.Add(this.empIDTxtBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximumSize = new System.Drawing.Size(300, 280);
            this.MinimumSize = new System.Drawing.Size(300, 280);
            this.Name = "loginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Limerick Games Library";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button loginBtn;
        private System.Windows.Forms.Label passwordLabel;
        private System.Windows.Forms.Label employeeIDLabel;
        private System.Windows.Forms.TextBox passTxtBox;
        private System.Windows.Forms.TextBox empIDTxtBox;
    }
}