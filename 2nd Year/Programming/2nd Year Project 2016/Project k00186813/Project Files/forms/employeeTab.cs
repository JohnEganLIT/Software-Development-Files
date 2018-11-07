using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace Limerick_Game_Library
{
    public partial class mainForm : Form
    {
        public int selectedEmp = 0; //Selected employee
        static List<Employee> empList = new List<Employee>(); //List to store employees info

        /*==================================================*/
        /*<-------------- 1. EMPLOYEE TAB ----------------->*/
        /*==================================================*/

        private void initializeEmpForm()
        {
            empReadFromFile();
            
            empDisplayValues();

            empRecordNumTxtBox.Text = Convert.ToString(1); //Sets Record Number Text Box
        }

        private void empReadFromFile() //Reads from file to empList
        {
            try
            {   
                string line;
                empList.Clear();

                using (StreamReader reader = new StreamReader("employees.txt")) //Opens file containing employee info
                {
                    while (true)
                    {
                        line = reader.ReadLine();

                        if (String.IsNullOrEmpty(line)) //Breaks while loop at end of file
                        {
                            break;
                        }

                        string[] values = line.Split('|'); //Reads values into array

                        Employee emp = new Employee();

                        emp.empID = values[0];
                        emp.password = values[1];
                        emp.name = values[2];
                        emp.salary = values[3];
                        emp.address1 = values[4];
                        emp.address2 = values[5];
                        emp.city = values[6];
                        emp.county = values[7];
                        
                        empList.Add(emp); //Adds employee to empList
                    }
                }

                //Outputs empList to textbox 
                int counter = 0;

                empDisplayTxtBox.Text = "";
                empDisplayTxtBox.AppendText("EmpID\t  Salary\tName\t\tAddress\n");
                empDisplayTxtBox.AppendText("---------------------------------------------------------------------------------------------------------------------------------------------------\n");

                foreach (Employee emp in empList) //Displays information in correct format inside display text box
                {
                    counter++;
                    empDisplayTxtBox.AppendText(string.Format("{0}:   {1}   {2}   {3} \t{4}  {5}  {6}  {7}\n", counter, emp.empID, emp.salary, emp.name, emp.address1, emp.address2, emp.city, emp.county));
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(Convert.ToString(ex));
            }

            return;
        }

        private void empWriteToFile() //Writes from empList to file
        {
            try
            {
                using (StreamWriter writer = new StreamWriter("employees.txt")) //Opens file containing employee info
                {
                    //Writes information from empList to file in correct format
                    foreach (Employee emp in empList)
                    {
                        string line = string.Format("{0}|{1}|{2}|{3}|{4}|{5}|{6}|{7}", emp.empID, emp.salary, emp.password, emp.name, emp.address1, emp.address2, emp.city, emp.county);
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

        private void empDisplayValues() //Displays selected record in text boxes for editing
        {
            if (empList.Count == 0) 
            {
                empNewRecord();
            }

            else
            {
                empIDTxtBox.Text = empList[selectedEmp].empID;
                empPassTxtBox.Text = empList[selectedEmp].password;
                empNameTxtBox.Text = empList[selectedEmp].name;
                empAddr1TxtBox.Text = empList[selectedEmp].address1;
                empAddr2TxtBox.Text = empList[selectedEmp].address2;
                empCityTxtBox.Text = empList[selectedEmp].city;
                empCountyTxtBox.Text = empList[selectedEmp].county;            
                empSalaryTxtBox.Text = empList[selectedEmp].salary;            
            }

            return;
        }

        private void empNewRecord() //Creates new record
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

                string result = "e" + b.ToString(); //Creates random string and concatenates e  to the front of it

                empIDTxtBox.Text = result;
                empSalaryTxtBox.Text = "";
                empPassTxtBox.Text = "";
                empNameTxtBox.Text = "";
                empAddr1TxtBox.Text = "";
                empAddr2TxtBox.Text = "";
                empCityTxtBox.Text = "";
                empCountyTxtBox.Text = "";
             
                empRecordNumTxtBox.Text = Convert.ToString(empList.Count + 1); 

                return;
            }

            catch (Exception ex)
            {
                MessageBox.Show(Convert.ToString(ex));
            }
        }

        private void empSaveRecord() //Saves values to list and then writes list to file
        {
            try
            {
                if (empRecordNumTxtBox.Text == Convert.ToString(empList.Count + 1)) 
                {
                    Employee emp = new Employee();

                    emp.empID = empIDTxtBox.Text;
                    
                    emp.password = empPassTxtBox.Text;
                    emp.name = empNameTxtBox.Text;
                    emp.address1 = empAddr1TxtBox.Text;
                    emp.address2 = empAddr2TxtBox.Text;
                    emp.city = empCityTxtBox.Text;
                    emp.county = empCountyTxtBox.Text;
                    emp.salary = empSalaryTxtBox.Text;

                    empList.Add(emp);

                    empDisplayValues();
                }

                else
                {
                    empList[selectedEmp].empID = empIDTxtBox.Text;
                    empList[selectedEmp].password = empPassTxtBox.Text;
                    empList[selectedEmp].name = empNameTxtBox.Text;
                    empList[selectedEmp].address1 = empAddr1TxtBox.Text;
                    empList[selectedEmp].address2 = empAddr2TxtBox.Text;
                    empList[selectedEmp].city = empCityTxtBox.Text;
                    empList[selectedEmp].county = empCountyTxtBox.Text;
                    empList[selectedEmp].salary = empSalaryTxtBox.Text;
                }

                empWriteToFile();
                empReadFromFile();
                empDisplayValues();

                MessageBox.Show("Saved Successfully");

            }

            catch (Exception ex)
            {
                MessageBox.Show(Convert.ToString(ex));
            }

            return;
        }

        private void empDeleteRecord() //Deletes record from list and writes updated list to file
        {
            try
            {
                if (empList.Count == 0)
                {
                    MessageBox.Show("No more records!");
                }

                else
                {
                    empList.RemoveAt(selectedEmp);

                   empRecordNumTxtBox.Text = Convert.ToString(selectedEmp);

                    MessageBox.Show("Record Deleted");
                }
               
                empWriteToFile();
                empReadFromFile();
                empDisplayValues();
            }

            catch (Exception ex)
            {
                MessageBox.Show(Convert.ToString(ex));
            }

            return;
        }

        private void empUpRecord() //Moves up 1 record
        {
            if (selectedEmp < empList.Count - 1)
            {
                selectedEmp++;
                int recordNum = selectedEmp + 1; //Record Number for displaying in recordNum text box
                empRecordNumTxtBox.Text = Convert.ToString(recordNum); //Sets Record Number Text Box
                empDisplayValues();
            }
        }

        private void empDownRecord() //Moves down 1 record
        {
            if (selectedEmp > 0)
            {
                selectedEmp--;
                int recordNum = selectedEmp + 1; //Record Number for displaying in recordNum text box
                empRecordNumTxtBox.Text = Convert.ToString(recordNum); //Sets Record Number Text Box
                empDisplayValues();
            }
        }

        private void empNewBtn_Click(object sender, EventArgs e)
        {
            empNewRecord();
        }

        private void empSaveBtn_Click(object sender, EventArgs e)
        {
            empSaveRecord();
        }

        private void empDeleteBtn_Click(object sender, EventArgs e)
        {
            empDeleteRecord();
        }

        private void empUpBtn_Click(object sender, EventArgs e)
        {
            empUpRecord();
        }

        private void empDownBtn_Click(object sender, EventArgs e)
        {
            empDownRecord();
        }
 
        private void empRecordNumTxtBox_TextChanged(object sender, EventArgs e) //Allows you to change selected employee by changing number in the number text box
        {
            if (empRecordNumTxtBox.Text != "")
            {
                if(int.Parse(empRecordNumTxtBox.Text) > (empList.Count + 1))
                {
                    selectedEmp = empList.Count;
                    empRecordNumTxtBox.Text = Convert.ToString(empList.Count);
                }

                else if (int.Parse(empRecordNumTxtBox.Text) > 0 && int.Parse(empRecordNumTxtBox.Text) < empList.Count + 1)
                {
                    selectedEmp = int.Parse(empRecordNumTxtBox.Text) - 1;
                    empDisplayValues();
                }

                else if (int.Parse(empRecordNumTxtBox.Text) == 0)
                {
                    empRecordNumTxtBox.Text = Convert.ToString(1);
                }
            }

            empRecordNumTxtBox.SelectionStart = empRecordNumTxtBox.Text.Length; // add some logic if length is 0
            empRecordNumTxtBox.SelectionLength = 0;
        }

        private void empValidation() //Disables save button if important fields are empty
        {
            if (!string.IsNullOrEmpty(empNameTxtBox.Text) && !string.IsNullOrEmpty(empAddr1TxtBox.Text) && !string.IsNullOrEmpty(empCityTxtBox.Text) && !string.IsNullOrEmpty(empCountyTxtBox.Text))
            {
                this.empSaveBtn.Enabled = true;
            }

            else
            {
                this.empSaveBtn.Enabled = false;
            }
        }

        private void empRecordNumTxtBox_KeyPress(object sender, KeyPressEventArgs e) //Only allows numbers in record No: text box
        {
            const char Delete = (char)8;
            e.Handled = !Char.IsDigit(e.KeyChar) && e.KeyChar != Delete;
        }

        private void empNameTxtBox_TextChanged(object sender, EventArgs e)
        {
            empValidation();
        }

        private void empAddr1TxtBox_TextChanged(object sender, EventArgs e)
        {
            empValidation();
        }

        private void empCityTxtBox_TextChanged(object sender, EventArgs e)
        {
            empValidation();
        }

        private void empCountyTxtBox_TextChanged(object sender, EventArgs e)
        {
            empValidation();
        }
    }
}
