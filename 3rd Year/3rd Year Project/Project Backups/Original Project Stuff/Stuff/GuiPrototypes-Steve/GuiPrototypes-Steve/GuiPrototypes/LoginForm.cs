using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Components;
using Security;

namespace GuiPrototypes {
    public partial class LoginForm : UserControl {
        public LoginForm() {
            InitializeComponent();
        }

        private void submit_Click(object sender, EventArgs e) {
            Frame frame = Parent as Frame;

            string username = this.username.Text;
            string password = this.password.Text;

            SecureHash sha256 = new SecureHash(SecureHash.HashType.SHA256);
            string hash = sha256.Compute(username + password);
            string json = "Login:{\"Cipher\":\"" + hash + "\", \"UserName\":\"" + username + "\"}";

            frame.client.Send(json);
            string response = frame.client.Recv();

            if (response == null) {
                return;
            }

            if (!response.Contains(hash)) {
                MessageBox.Show("Incorrect Username of Password");
                return;
            }

            if (frame != null) {
                this.Hide();
                frame.dashboardForm.Show();
            }
        }

        private void cancel_Click(object sender, EventArgs e) {
            Application.Exit();
        }

        public void SetTheme(object sender, EventArgs e) {
            switch (MetroStyleManager.Default.Theme) {
            case "Dark": this.BackColor = Color.Black; break;
            case "Light": this.BackColor = Color.White; break;
            }
            //this.tableLayoutPanel1.BackColor = this.BackColor;
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e) {
        }

        private void password_Click(object sender, EventArgs e) {
        }

        private void username_Click(object sender, EventArgs e) {
        }

        private void metroLabel3_Click(object sender, EventArgs e) {
        }

        private void metroLabel2_Click(object sender, EventArgs e) {
        }

        private void forgot_Click(object sender, EventArgs e) {
            Frame frame = Parent as Frame;
            if (frame != null) {
                this.Hide();
                frame.ForgotPasswordForm.Show();
            }
        }

        private void metroLabel1_Click(object sender, EventArgs e) {
        }

        private void panel_Paint(object sender, PaintEventArgs e) {
        }
    }
}
