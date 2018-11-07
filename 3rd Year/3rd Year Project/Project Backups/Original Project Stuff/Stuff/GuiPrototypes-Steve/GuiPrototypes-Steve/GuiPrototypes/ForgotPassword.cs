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
    public partial class ForgotPassword : UserControl {
        public ForgotPassword() {
            InitializeComponent();
        }

        private void cancel_Click_1(object sender, EventArgs e) {
            Frame frame = Parent as Frame;
            if (frame != null) {
                this.Hide();
                frame.loginForm.Show();
            }
        }

        private void submit_Click(object sender, EventArgs e) {
            Frame frame = Parent as Frame;
            if (frame != null) {
                this.Hide();
                frame.UserIDResetForm.Show();
            }
        }
    }
}
