using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace Limerick_Game_Library
{
    public partial class loginForm : Form
    {
       
        public loginForm()
        {
            InitializeComponent();

        }

        private void loginBtn_Click(object sender, EventArgs e)
        {
            try
            {
                string line;
                string empID = null;

                using (StreamReader reader = new StreamReader("employees.txt")) //Opens file containing employee info
                {
                    while (true)
                    {
                        line = reader.ReadLine();

                        if (String.IsNullOrEmpty(line))
                        {
                            break;
                        }

                        string[] values = line.Split('|'); //Reads values into array

                        if (values[0] == empIDTxtBox.Text && values[1] == passTxtBox.Text) //Checks line for entered employeeID and password 
                        {
                            if (empIDTxtBox.Text[0] == 'm') //Checks if manager id entered
                            {
                                empID = values[0];
                            }

                            if (empIDTxtBox.Text[0] == 'e') //Checks if employee id entered
                            {
                                empID = values[0];
                            }
                        }
                    }
                }

                if(empID != null)
                {
                    mainForm mainForm = new mainForm(empID);
                    this.Hide();
                    mainForm.ShowDialog();
                }

                else
                {
                    MessageBox.Show("Incorrect Username or Password");
                } 
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }                
        }

        private void validation()
        {
            if (!string.IsNullOrEmpty(empIDTxtBox.Text) && !string.IsNullOrEmpty(passTxtBox.Text))
            {
                this.loginBtn.Enabled = true;
            }

            else
            {
                this.loginBtn.Enabled = false;
            }

            return;
        }

        private void empIDTxtBox_TextChanged(object sender, EventArgs e)
        {
            validation();
        }

        private void passTxtBox_TextChanged(object sender, EventArgs e)
        {
            validation();
        }
    }
}
