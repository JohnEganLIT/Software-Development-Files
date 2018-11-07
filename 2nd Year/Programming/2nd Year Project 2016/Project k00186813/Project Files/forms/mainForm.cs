using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace Limerick_Game_Library
{
    public partial class mainForm : Form
    {
        public mainForm(string empID)
        {
            InitializeComponent();

            loginStatusTxtBox.Text = string.Format("Logged in as Manager with ID: {0}", empID);

            ((Control)this.tabGames).Enabled = false; //Disables incomplete games form
            ((Control)this.tabReport).Enabled = false; //Disables incomplete report form

            if (empID[0] == 'm') //Checks if manager is logged in
            {
                ((Control)this.tabEmployees).Enabled = true; //Enables employee form
                initializeEmpForm();
            }
            
            else
            {
                ((Control)this.tabEmployees).Enabled = false; //Disables Employee Form
                ((Control)this.empDeniedLabel).Visible = true; //Display "Managers Only" on employee form
            }

            intializeCustForm(); //Prepares customer form. Code in customerTab.cs
        }

        //Closing The Application

        private void logoutBtn_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void mainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
