using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace Limerick_Game_Library
{
    public partial class mainForm : Form
    {
       
        public int selectedCust = 0; //Selected customer
        static List<Customer> custList = new List<Customer>(); //List to store customer info

        /*==================================================*/
        /*<-------------- 2. CUSTOMER TAB ----------------->*/
        /*==================================================*/ 
        
        private void intializeCustForm()
        {
            custReadFromFile();

            custDisplayValues();

            custRecordNumTxtBox.Text = Convert.ToString(1); //Sets Record Number Text Box
        }

        private void custReadFromFile() //Reads from file to custList
        {
            try
            {
                string line;
                custList.Clear();

                using (StreamReader reader = new StreamReader("customers.txt")) //Opens file containing Customer info
                {
                    while (true)
                    {
                        line = reader.ReadLine();

                        if (String.IsNullOrEmpty(line)) //Breaks while loop at end of file
                        {
                            break;
                        }

                        string[] values = line.Split('|'); //Reads values into array

                        Customer cust = new Customer();

                        cust.custID = values[0];
                        cust.name = values[1];
                        cust.address1 = values[2];
                        cust.address2 = values[3];
                        cust.city = values[4];
                        cust.county = values[5];
                        cust.email = values[6];

                        custList.Add(cust); //Adds Customer to custList
                    }
                }

                //Outputs custList to textbox 
                int counter = 0;

                custDisplayTxtBox.Text = "";
                custDisplayTxtBox.AppendText("custID\tName\tAddress\t\t\t\tEmail\n");
                custDisplayTxtBox.AppendText("---------------------------------------------------------------------------------------------------------------------------------------------------\n");

                foreach (Customer cust in custList)
                {
                    counter++;
                    custDisplayTxtBox.AppendText(string.Format("{0}:   {1}  {2}  {3}  {4}  {5}  {6}  {7}\n", counter, cust.custID, cust.name, cust.address1, cust.address2, cust.city, cust.county, cust.email));
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(Convert.ToString(ex));
            }

            return;
        }

        private void custWriteToFile() //Writes from custList to file
        {
            try
            {
                using (StreamWriter writer = new StreamWriter("customers.txt")) //Opens file containing Customer info
                {
                    foreach (Customer cust in custList) //Writes information from custList to file in correct format
                    {
                        string line = string.Format("{0}|{1}|{2}|{3}|{4}|{5}|{6}", cust.custID, cust.name, cust.address1, cust.address2, cust.city, cust.county, cust.email);
                        writer.WriteLine(line);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(Convert.ToString(ex));
            }

            return;
        }

        private void custDisplayValues() //Displays selected record in text boxes for editing
        {
            if (custList.Count == 0) 
            {
                custNewRecord();
            }

            else
            {
                custIDTxtBox.Text = custList[selectedCust].custID;
                custNameTxtBox.Text = custList[selectedCust].name;
                custAddr1TxtBox.Text = custList[selectedCust].address1;
                custAddr2TxtBox.Text = custList[selectedCust].address2;
                custCityTxtBox.Text = custList[selectedCust].city;
                custCountyTxtBox.Text = custList[selectedCust].county;
                custEmailTxtBox.Text = custList[selectedCust].email;
            }

            return;
        }

        private void custNewRecord() //Creates new record
        {
            try
            {
                string chars = "123456789";
                int len = 5;

                Random rnd = new Random();
                StringBuilder b = new StringBuilder(len);

                for (int i = 0; i < len; i++)
                {
                    b.Append(chars[rnd.Next(chars.Length)]);
                }

                string result = "c" + b.ToString(); //Creates random string and concatenates c to the front of it

                custIDTxtBox.Text = result;
                custNameTxtBox.Text = "";
                custAddr1TxtBox.Text = "";
                custAddr2TxtBox.Text = "";
                custCityTxtBox.Text = "";
                custCountyTxtBox.Text = "";
                custEmailTxtBox.Text = "";

                custRecordNumTxtBox.Text = Convert.ToString(custList.Count + 1); 

                return;
            }

            catch (Exception ex)
            {
                MessageBox.Show(Convert.ToString(ex));
            }
        }

        private void custSaveRecord() //Saves values to list and then writes list to file
        {
            try
            {
                if (custRecordNumTxtBox.Text == Convert.ToString(custList.Count + 1))
                {
                    Customer cust = new Customer();

                    cust.custID = custIDTxtBox.Text;
                    cust.name = custNameTxtBox.Text;
                    cust.address1 = custAddr1TxtBox.Text;
                    cust.address2 = custAddr2TxtBox.Text;
                    cust.city = custCityTxtBox.Text;
                    cust.county = custCountyTxtBox.Text;
                    cust.email = custEmailTxtBox.Text;

                    custList.Add(cust);

                    custDisplayValues();
                }

                else
                {
                    custList[selectedCust].custID = custIDTxtBox.Text;
                    custList[selectedCust].name = custNameTxtBox.Text;
                    custList[selectedCust].address1 = custAddr1TxtBox.Text;
                    custList[selectedCust].address2 = custAddr2TxtBox.Text;
                    custList[selectedCust].city = custCityTxtBox.Text;
                    custList[selectedCust].county = custCountyTxtBox.Text;
                    custList[selectedCust].email = custEmailTxtBox.Text;
                }

                custWriteToFile();
                custReadFromFile();
                custDisplayValues();

                MessageBox.Show("Saved Successfully");

            }

            catch (Exception ex)
            {
                MessageBox.Show(Convert.ToString(ex));
            }

            return;
        }

        private void custDeleteRecord()
        {
            try
            {
                if (custList.Count == 0)
                {
                    MessageBox.Show("No more records!");
                }

                else
                {
                    custList.RemoveAt(selectedCust);

                   custRecordNumTxtBox.Text = Convert.ToString(selectedCust);

                    MessageBox.Show("Record Deleted");
                }
               
                custWriteToFile();
                custReadFromFile();
                custDisplayValues();
            }

            catch (Exception ex)
            {
                MessageBox.Show(Convert.ToString(ex));
            }

            return;
        }

        private void custUpRecord()
        {
            if (selectedCust < custList.Count - 1)
            {
                selectedCust++;
                int recordNum = selectedCust + 1; //Record Number for displaying in recordNum text box
                custRecordNumTxtBox.Text = Convert.ToString(recordNum); //Sets Record Number Text Box
                custDisplayValues();
            }
        }

        private void custDownRecord()
        {
            if (selectedCust > 0)
            {
                selectedCust--;
                int recordNum = selectedCust + 1; //Record Number for displaying in recordNum text box
                custRecordNumTxtBox.Text = Convert.ToString(recordNum); //Sets Record Number Text Box
                custDisplayValues();
            }
        }

        private void custNewBtn_Click(object sender, EventArgs e)
        {
            custNewRecord();
        }

        private void custSaveBtn_Click(object sender, EventArgs e)
        {
            custSaveRecord();
        }

        private void custDeleteBtn_Click(object sender, EventArgs e)
        {
            custDeleteRecord();
        }

        private void custUpBtn_Click(object sender, EventArgs e)
        {
            custUpRecord();
        }

        private void custDownBtn_Click(object sender, EventArgs e)
        {
            custDownRecord();
        }
 
        private void custRecordNumTxtBox_TextChanged(object sender, EventArgs e)
        {
            if (custRecordNumTxtBox.Text != "")
            {
                if(int.Parse(custRecordNumTxtBox.Text) > (custList.Count + 1))
                {
                    selectedCust = custList.Count;
                    custRecordNumTxtBox.Text = Convert.ToString(custList.Count);
                }

                else if (int.Parse(custRecordNumTxtBox.Text) > 0 && int.Parse(custRecordNumTxtBox.Text) < custList.Count + 1)
                {
                    selectedCust = int.Parse(custRecordNumTxtBox.Text) - 1;
                    custDisplayValues();
                }

                else if (int.Parse(custRecordNumTxtBox.Text) == 0)
                {
                    custRecordNumTxtBox.Text = Convert.ToString(1);
                }
            }

            custRecordNumTxtBox.SelectionStart = custRecordNumTxtBox.Text.Length; // add some logic if length is 0
            custRecordNumTxtBox.SelectionLength = 0;
        }

        private void custValidation()
        {
            if (!string.IsNullOrEmpty(custIDTxtBox.Text) && !string.IsNullOrEmpty(custNameTxtBox.Text) && !string.IsNullOrEmpty(custAddr1TxtBox.Text) && !string.IsNullOrEmpty(custCityTxtBox.Text) && !string.IsNullOrEmpty(custCountyTxtBox.Text))
            {
                this.custSaveBtn.Enabled = true;
            }

            else
            {
                this.custSaveBtn.Enabled = false;
            }
        }

        private void custRecordNumTxtBox_KeyPress(object sender, KeyPressEventArgs e) //Only allows numbers in record No: text box
        {
            const char Delete = (char)8;
            e.Handled = !Char.IsDigit(e.KeyChar) && e.KeyChar != Delete;
        }

        private void custIDTxtBox_TextChanged(object sender, EventArgs e)
        {
            custValidation();
        }

        private void custNameTxtBox_TextChanged(object sender, EventArgs e)
        {
            custValidation();
        }

        private void custAddr1TxtBox_TextChanged(object sender, EventArgs e)
        {
            custValidation();
        }

        private void custCityTxtBox_TextChanged(object sender, EventArgs e)
        {
            custValidation();
        }

        private void custCountyTxtBox_TextChanged(object sender, EventArgs e)
        {
            custValidation();
        }
    }
}
