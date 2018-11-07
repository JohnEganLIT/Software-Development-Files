using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GuiPrototypes {
    public partial class UserIDReset : UserControl {
        public UserIDReset() {
            InitializeComponent();
        }
        private void metroPanel7_Paint(object sender, PaintEventArgs e) {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e) {

        }

        private void metroPanel8_Paint(object sender, PaintEventArgs e) {

        }

        private void password_Click(object sender, EventArgs e) {

        }

        private void username_Click(object sender, EventArgs e) {

        }

        private void metroLabel3_Click(object sender, EventArgs e) {

        }

        private void metroLabel2_Click(object sender, EventArgs e) {

        }



        private void metroLabel1_Click(object sender, EventArgs e) {

        }

        private void metroPanel2_Paint(object sender, PaintEventArgs e) {

        }

        private void metroPanel3_Paint(object sender, PaintEventArgs e) {

        }

        private void metroPanel4_Paint(object sender, PaintEventArgs e) {

        }

        private void metroPanel5_Paint(object sender, PaintEventArgs e) {

        }

        private void metroPanel6_Paint(object sender, PaintEventArgs e) {

        }

        private void panel_Paint(object sender, PaintEventArgs e) {

        }

        private void metroPanel1_Paint(object sender, PaintEventArgs e) {

        }

        private void submit_Click(object sender, EventArgs e) {

            Frame frame = Parent as Frame;
            if (frame != null) {
                this.Hide();
                frame.loginForm.Show();
            }
        }
    }
}
