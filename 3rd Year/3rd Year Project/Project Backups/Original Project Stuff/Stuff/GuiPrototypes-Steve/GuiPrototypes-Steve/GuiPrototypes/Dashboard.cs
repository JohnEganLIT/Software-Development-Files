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

namespace GuiPrototypes {
    public partial class Dashboard : UserControl {
        private Dictionary<string, string[]> meta;
        public AutoForm autoPage1;
        public AutoView autoList1;

        public Dashboard() {
            this.autoPage1 = new AutoForm();
            this.autoList1 = new AutoView();
            InitializeComponent();
            this.workspace.Controls.Add(this.autoPage1, 0, 1);
            this.workspace.Controls.Add(this.autoList1, 0, 1);
            // 
            // autoPage1
            // 
            this.autoPage1.BackColor = System.Drawing.Color.White;
            this.autoPage1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.autoPage1.Location = new System.Drawing.Point(3, 561);
            this.autoPage1.Name = "autoPage1";
            this.autoPage1.Size = new System.Drawing.Size(623, 14);
            this.autoPage1.TabIndex = 1;
            this.autoPage1.Title = "Please Select a Menu Item";
            // 
            // autoList1
            // 
            this.autoList1.BackColor = System.Drawing.Color.White;
            this.autoList1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.autoList1.Location = new System.Drawing.Point(3, 27);
            this.autoList1.Name = "autoList1";
            this.autoList1.Size = new System.Drawing.Size(623, 528);
            this.autoList1.TabIndex = 1;
            this.autoList1.Title = "Please Select a Menu Item";
            this.autoList1.Load += new System.EventHandler(this.autoList1_Load);

            this.autoList1.Hide();
        }

        private void logout_Click(object sender, EventArgs e) {
            Frame frame = Parent as Frame;
            if (frame != null) {
                this.Hide();
                frame.loginForm.Show();
            }
        }

        public string[] this[string name] {
            get {
                return autoPage1[name] as string[];
            }
            set {
                autoPage1[name] = value;
            }
        }

        // ***************************************************************** //
        // new API to Populate an AutoPage                                   //
        // ***************************************************************** //
        //    AutoPage autopage = new AutoPage();                            //
        //    autopage["labels"] = new string[] { "FirstName", "LastName" }; //
        //    autopage["values"] = new string[] { "John",      "Smith"    }; //
        //    autopage["inputs"] = new string[] { "TextBox",   "TextBox"  }; //
        //    autopage.Reset();                                              //
        //                                                                   //
        // ***************************************************************** //
        // (Coming Soon) new API to Get/Set values from AutoPage Inputs      //
        // ***************************************************************** //
        //    string value = autopage["FirstName"]; // get input value       //
        //    autopage["FirstName"] = "John Smith"; // set input value       //
        // ***************************************************************** //

        private void addNewRegulationToolStripMenuItem_Click(object sender, EventArgs e) {
            autoPage1.Title = "Add New Regulation";
            autoPage1["labels"] = new string[] { "Description", "Publishing Date", "Effective Date", "Points On Payment", "Points On Conviction", "Fine", "Fine On Conviction", "Mandatory Court Appearance" };
            autoPage1["values"] = new string[] { "", DateTime.Now.ToString(), DateTime.Now.ToString(), "2", "4", "80", "120", "false" };
            autoPage1["inputs"] = new string[] { "TextBox", "DateTimePicker", "DateTimePicker", "TextBox", "TextBox", "TextBox", "TextBox", "CheckBox" };
            autoPage1.submit.Text = "Submit";
            autoPage1.cancel.Text = "Cancel";
            autoPage1.Reset();
            this.autoList1.Hide();
            this.autoPage1.Show();
        }

        private void AddNewUserController(object sender, EventArgs e) {
            Frame frame = this.Parent as Frame;

            string txt = this.autoPage1.Field("UserName") as string;

            string json = "AddUser:{"
                        + string.Format("\"UserName\":\"{0}\", ",       this.autoPage1.Field("UserName") as string)
                        + string.Format("\"OrganizationID\":\"{0}\", ", this.autoPage1.Field("OrganizationID") as string)
                        + string.Format("\"Position\":\"{0}\", ",       this.autoPage1.Field("Position") as string)
                        + string.Format("\"Email\":\"{0}\", ",          this.autoPage1.Field("Email") as string)
                        + string.Format("\"DateAdded\":\"{0}\"",        this.autoPage1.Field("DateAdded") as string)
                        + "}";
            MessageBox.Show(json);
            frame.client.Send(json);
            string response = frame.client.Recv();
        }

        private void addNewUserToolStripMenuItem_Click(object sender, EventArgs e) {
            autoPage1.Title = "Add New User";
            autoPage1["fields"] = new string[] { "UserName", "OrganizationID", "Position", "Email", "DateAdded" };
            autoPage1["labels"] = new string[] { "User Name", "Organization ID", "Position", "Email", "Date Added" };
            autoPage1["values"] = new string[] { "", "", "", "", DateTime.Now.ToShortDateString() };
            autoPage1["inputs"] = new string[] { "TextBox", "TextBox", "TextBox", "TextBox", "DateTimePicker" };
            autoPage1.submit.Text = "Submit";
            autoPage1.cancel.Text = "Cancel";
            autoPage1.Reset();
            autoPage1.submit.Click += AddNewUserController;

            this.autoList1.Hide();
            this.autoPage1.Show();
        }

        private void modifyBlackListRulesToolStripMenuItem_Click(object sender, EventArgs e) {
            autoPage1.Title = "Modify BlackList Rules";
            autoPage1["labels"] = new string[] { "User", "Action", "Allow? (Uncheck for Deny)" };
            autoPage1["values"] = new string[] { "PPB/Team1/Staff/j.smith", "Delete/Offences/*", "false" };
            autoPage1["inputs"] = new string[] { "TextBox", "TextBox", "CheckBox" };
            autoPage1.submit.Text = "Update";
            autoPage1.cancel.Text = "Reset";
            autoPage1.Reset();
            this.autoList1.Hide();
            this.autoPage1.Show();
        }

        private void notifyDriverOfUnsuccessfulAppealToolStripMenuItem_Click(object sender, EventArgs e) {
            autoPage1.Title = "Notify Driver Of Unsuccessful Appeal";
            autoPage1["labels"] = new string[] { "Reference No", "Time / Date", "Location", "Licence No", "Vehicle Registration" };
            autoPage1["values"] = new string[] { "40123456789", DateTime.Now.ToString(), "R415", "101", "131D123456" };
            autoPage1["inputs"] = new string[] { "TextBox", "DateTimePicker", "TextBox", "TextBox", "TextBox" };
            autoPage1.Reset();
            autoPage1.submit.Text = "Notify";
            autoPage1.cancel.Text = "Cancel";
            this.autoList1.Hide();
            this.autoPage1.Show();
        }

        private void updateUserIdentityToolStripMenuItem_Click(object sender, EventArgs e) {
            autoPage1.Title = "Update User Identity";
            autoPage1["labels"] = new string[] { "FirstName", "LastName", "Address", "City/Town", "County" };
            autoPage1["values"] = new string[] { "John", "Smith", "123 Moylish", "Limerick", "limerick" };
            autoPage1["inputs"] = new string[] { "TextBox", "TextBox", "TextBox", "TextBox", "TextBox" };
            autoPage1.Reset();
            autoPage1.submit.Text = "Update";
            autoPage1.cancel.Text = "Reset";
            this.autoList1.Hide();
            this.autoPage1.Show();
        }

        private void notifyDriverOfSummonsToolStripMenuItem_Click(object sender, EventArgs e) {
            autoPage1.Title = "Notify Driver Of Summons";
            autoPage1["labels"] = new string[] { "Reference No", "Time / Date", "Location", "Licence No", "First Name", "Surname", "Court Date" };
            autoPage1["values"] = new string[] { "40123456789", DateTime.Now.ToString(), "R415", "101", "John", "Smith", DateTime.Now.ToString() };
            autoPage1["inputs"] = new string[] { "TextBox", "DateTimePicker", "TextBox", "TextBox", "TextBox", "TextBox", "DateTimePicker" };
            autoPage1.Reset();
            autoPage1.submit.Text = "Notify";
            autoPage1.cancel.Text = "Cancel";
            this.autoList1.Hide();
            this.autoPage1.Show();
        }

        private void addNewAmendmentToolStripMenuItem_Click(object sender, EventArgs e) {
            autoPage1.Title = "Add New Amendment";
            autoPage1["labels"] = new string[] { "Description", "Previous Regulation", "Publishing Date", "Effective Date", "Points On Payment", "Points On Conviction", "Fine", "Fine On Conviction", "Mandatory Court Appearance" };
            autoPage1["values"] = new string[] { "", "", DateTime.Now.ToString(), DateTime.Now.ToString(), "2", "4", "80", "120", "false" };
            autoPage1["inputs"] = new string[] { "TextBox", "TextBox", "DateTimePicker", "DateTimePicker", "TextBox", "TextBox", "TextBox", "TextBox", "CheckBox" };
            autoPage1.Reset();
            autoPage1.submit.Text = "Submit";
            autoPage1.cancel.Text = "Cancel";
            this.autoList1.Hide();
            this.autoPage1.Show();
        }

        private void modifyUserDetailsToolStripMenuItem_Click(object sender, EventArgs e) {
            autoPage1.Title = "Modify User Details";
            autoPage1["labels"] = new string[] { "User Name", "Organization ID", "Position" };
            autoPage1["values"] = new string[] { "j.smith", "MLA", "Staff" };
            autoPage1["inputs"] = new string[] { "TextBox", "TextBox", "TextBox" };
            autoPage1.Reset();
            autoPage1.submit.Text = "Update";
            autoPage1.cancel.Text = "Reset";
            this.autoList1.Hide();
            this.autoPage1.Show();
        }

        private void gardaReportsOffenceToolStripMenuItem_Click(object sender, EventArgs e) {
            autoPage1.Title = "Garda Reports Offence";
            autoPage1["labels"] = new string[] { "Reference No", "Offence", "Time / Date", "Location", "Licence No", "Vehicle Registration" };
            autoPage1["values"] = new string[] { "40123456789", "", DateTime.Now.ToString(), "", "", "" };
            autoPage1["inputs"] = new string[] { "TextBox", "TextBox", "DateTimePicker", "TextBox", "TextBox", "TextBox" };
            autoPage1.Reset();
            autoPage1.submit.Text = "Submit";
            autoPage1.cancel.Text = "Cancel";
            this.autoList1.Hide();
            this.autoPage1.Show();
        }

        private void notifyDriverOfOffenceToolStripMenuItem_Click(object sender, EventArgs e) {
            autoPage1.Title = "Notify Driver Of Offence";
            autoPage1["labels"] = new string[] { "Reference No", "Offence", "Time / Date", "Location", "Licence No", "Vehicle Registration" };
            autoPage1["values"] = new string[] { "40123456789", "Speeding", DateTime.Now.ToString(), "R415", "101", "131D123456" };
            autoPage1["inputs"] = new string[] { "TextBox", "TextBox", "DateTimePicker", "TextBox", "TextBox", "TextBox" };
            autoPage1.Reset();
            autoPage1.submit.Text = "Notify";
            autoPage1.cancel.Text = "Cancel";
            this.autoList1.Hide();
            this.autoPage1.Show();
        }

        private void notifyDriverOfConvictionToolStripMenuItem_Click(object sender, EventArgs e) {
            autoPage1.Title = "Notify Driver Of Conviction";
            autoPage1["labels"] = new string[] { "Reference No", "Offence", "Time / Date", "Location", "Licence No", "Vehicle Registration" };
            autoPage1["values"] = new string[] { "40123456789", "Drink Driving", DateTime.Now.ToString(), "R415", "101", "131D123456" };
            autoPage1["inputs"] = new string[] { "TextBox", "TextBox", "DateTimePicker", "TextBox", "TextBox", "TextBox" };
            autoPage1.Reset();
            autoPage1.submit.Text = "Notify";
            autoPage1.cancel.Text = "Cancel";
            this.autoList1.Hide();
            this.autoPage1.Show();
        }

        private void reactivateUserAccountToolStripMenuItem_Click(object sender, EventArgs e) {
            autoPage1.Title = "Reactivate User Account";
            autoPage1["labels"] = new string[] { "User Name", "Organization ID", "Position" };
            autoPage1["values"] = new string[] { "j.smith", "MLA", "Staff" };
            autoPage1["inputs"] = new string[] { "TextBox", "TextBox", "TextBox" };
            autoPage1.Reset();
            autoPage1.submit.Text = "Reactivate";
            autoPage1.cancel.Text = "Cancel";
            this.autoList1.Hide();
            this.autoPage1.Show();
        }

        private void notifyLicenceAuthorityOfDisqualificationToolStripMenuItem_Click(object sender, EventArgs e) {
            autoPage1.Title = "Notify Licence Authority Of Disqualification";
            autoPage1["labels"] = new string[] { "Licence No", "Date of Disqualification", "Date of Expiration" };
            autoPage1["values"] = new string[] { "101", DateTime.Now.ToString(), DateTime.Now.ToString() };
            autoPage1["inputs"] = new string[] { "TextBox", "DateTimePicker", "DateTimePicker" };
            autoPage1.Reset();
            autoPage1.submit.Text = "Notify";
            autoPage1.cancel.Text = "Cancel";
            this.autoList1.Hide();
            this.autoPage1.Show();
        }

        private void printDocumentToolStripMenuItem_Click(object sender, EventArgs e) {
            autoList1.Title = "Print Document";
            autoList1["labels"] = new string[] { "Description", "Points", "Points on Conviction", "Fine", "Fine on Conviction" };
            autoList1.values = new string[][] {
                new string[] { "Speeding", "2", "4", "80", "120" },
                new string[] { "Failure to obey traffic lights", "2", "4", "80", "120" },
                new string[] { "Holding a mobile phone", "2", "4", "80", "120" },
            };
            autoList1.Reset();
            autoList1.submit.Text = "Print";
            autoList1.cancel.Text = "Cancel";
            this.autoPage1.Hide();
            this.autoList1.Show();
        }

        private void AddUserIdentityController(object sender, EventArgs e) {
            {
               

                Frame frame = this.Parent as Frame;

                string txt = this.autoPage1.Field("UserName") as string;

                string jsonAddUser = "AddUser:{"
                        + string.Format("\"UserName\":\"{0}\", ",       this.autoPage1.Field("UserName") as string)
                        + string.Format("\"OrganizationID\":\"{0}\", ", this.autoPage1.Field("OrganisationID") as string)
                        + string.Format("\"Position\":\"{0}\", ",       this.autoPage1.Field("Position") as string)
                        + string.Format("\"Email\":\"{0}\", ",          this.autoPage1.Field("Email") as string)
                        + string.Format("\"DateAdded\":\"{0}\"",        this.autoPage1.Field("DateAdded") as string)
                        + "}";
                string jsonAddIdentity = "AddIdentity:{"
                        + string.Format("\"UserName\":\"{0}\", ",      this.autoPage1.Field("UserName") as string)
                        + string.Format("\"FirstName\":\"{0}\", ",     this.autoPage1.Field("FirstName") as string)
                        + string.Format("\"LastName\":\"{0}\", ",      this.autoPage1.Field("LastName") as string)
                        + string.Format("\"StreetAddress\":\"{0}\", ", this.autoPage1.Field("Address") as string)
                        + string.Format("\"City\":\"{0}\", ",          this.autoPage1.Field("City") as string) // forgot to add comma here
                        + string.Format("\"County\":\"{0}\", ",        this.autoPage1.Field("County") as string)
                        + string.Format("\"DateOfBirth\":\"{0}\", ",   this.autoPage1.Field("DateOfBirth") as string)
                        + string.Format("\"Telephone\":\"{0}\", ",     this.autoPage1.Field("Telephone") as string)
                        + string.Format("\"Photograph\":\"{0}\"",      this.autoPage1.Field("Position") as string) // forgot to remove the comma here

                        + "}";
                MessageBox.Show(jsonAddUser);
                MessageBox.Show(jsonAddIdentity);
                frame.client.Send(jsonAddUser);                // User must go first as identity has a foreign key
                string UserResponse = frame.client.Recv();     // For every send there must be a receive (for status update)
                frame.client.Send(jsonAddIdentity);            // Identity must go second as it has a foreign key
                string IdentityResponse = frame.client.Recv(); // For every send there must be a receive (for status update)
            }
        }
        private void addUserIdentityToolStripMenuItem_Click(object sender, EventArgs e) {
            autoPage1.Title = "Add User Identity";
            autoPage1["fields"] = new string[] { "UserName", "OrganisationID", "Position", "Email", "DateAdded", "FirstName", "LastName", "Address", "City", "County", "DateOfBirth", "Telephone", "Photo" };

            autoPage1["labels"] = new string[] { "UserName", "Organisation ID", "Position", "Email", "Date Added", "First Name", "Last Name", "Address", "City/Town", "County", "Date Of Birth", "Telephone", "Photo" };
            autoPage1["values"] = new string[] { "username", "PPB", "Admin", "email", "2017-02-02", "fName", "lName", "address", "city", "county", "2017-02-02", "0873773", "img.jpg" };
            autoPage1["inputs"] = new string[] { "TextBox", "Textbox", "Textbox", "Textbox", "DateTimePicker", "TextBox", "TextBox", "TextBox", "TextBox", "TextBox", "DateTimePicker", "TextBox", "Textbox" };
            autoPage1.Reset();
            autoPage1.Reset();
            autoPage1.submit.Text = "Submit";
            autoPage1.cancel.Text = "Cancel";
            autoPage1.submit.Click += AddUserIdentityController; // submit.Click not autoPage1.Click
            this.autoList1.Hide();
            this.autoPage1.Show();
        }

        private void generateReportOfOffencesToolStripMenuItem_Click(object sender, EventArgs e) {
            autoList1.Title = "Generate Report Of Offences";
            autoList1["labels"] = new string[] { "Description", "Points", "Points on Conviction", "Fine", "Fine on Conviction" };
            autoList1.values = new string[][] {
                new string[] { "Speeding", "2", "4", "80", "120" },
                new string[] { "Failure to obey traffic lights", "2", "4", "80", "120" },
                new string[] { "Holding a mobile phone", "2", "4", "80", "120" },
            };
            autoList1.Reset();
            autoList1.submit.Text = "Print";
            autoList1.cancel.Text = "Cancel";
            this.autoPage1.Hide();
            this.autoList1.Show();
        }

        private void notifyDriverOfEndorsementToolStripMenuItem_Click(object sender, EventArgs e) {
            autoPage1.Title = "Notify Driver Of Endorsement";
            autoPage1["labels"] = new string[] { "Reference No", "Time / Date", "Location", "Licence No", "Vehicle Registration" };
            autoPage1["values"] = new string[] { "40123456789", DateTime.Now.ToString(), "R415", "101", "131D123456" };
            autoPage1["inputs"] = new string[] { "TextBox", "DateTimePicker", "TextBox", "TextBox", "TextBox" };
            autoPage1.Reset();
            autoPage1.submit.Text = "Notify";
            autoPage1.cancel.Text = "Cancel";
            this.autoList1.Hide();
            this.autoPage1.Show();
        }

        private void speedCameraReportOffenceToolStripMenuItem_Click(object sender, EventArgs e) {
            autoPage1.Title = "Speed Camera Report Offence";
            autoPage1["labels"] = new string[] { "Reference No", "Time / Date", "Location", "Licence No", "Vehicle Registration" };
            autoPage1["values"] = new string[] { "40123456789", DateTime.Now.ToString(), "R415", "101", "131D123456" };
            autoPage1["inputs"] = new string[] { "TextBox", "DateTimePicker", "TextBox", "TextBox", "TextBox" };
            autoPage1.Reset();
            autoPage1.submit.Text = "Submit";
            autoPage1.cancel.Text = "Cancel";
            this.autoList1.Hide();
            this.autoPage1.Show();
        }

        private void viewListOfRegulationsToolStripMenuItem_Click(object sender, EventArgs e) {
            autoList1.Title = "View List of Regulations";
            autoList1["labels"] = new string[] { "Description", "Publishing Date", "Effective Date", "Points On Payment", "Points On Conviction", "Fine", "Fine On Conviction", "Mandatory Court Appearance" };
            autoList1.values = new string[][] {
                new string[] { "Speeding", DateTime.Now.ToString(), DateTime.Now.ToString(), "2", "4", "80", "120", "false" },
                new string[] { "Failure to obey traffic lights", DateTime.Now.ToString(), DateTime.Now.ToString(), "2", "4", "80", "120", "false" },
                new string[] { "Holding a mobile phone", DateTime.Now.ToString(), DateTime.Now.ToString(), "2", "4", "80", "120", "false" },
            };
            autoList1.Reset();
            autoList1.submit.Text = "Search";
            autoList1.cancel.Text = "Cancel";
            this.autoList1.Show();
            this.autoPage1.Hide();
        }

        private void removeRegulationsToolStripMenuItem_Click(object sender, EventArgs e) {
            autoList1.Title = "Remove Regulations";
            autoList1["labels"] = new string[] { "Description", "Publishing Date", "Effective Date", "Points On Payment", "Points On Conviction", "Fine", "Fine On Conviction", "Mandatory Court Appearance" };
            autoList1.values = new string[][] {
                new string[] { "Speeding", DateTime.Now.ToString(), DateTime.Now.ToString(), "2", "4", "80", "120", "false" },
                new string[] { "Failure to obey traffic lights", DateTime.Now.ToString(), DateTime.Now.ToString(), "2", "4", "80", "120", "false" },
                new string[] { "Holding a mobile phone", DateTime.Now.ToString(), DateTime.Now.ToString(), "2", "4", "80", "120", "false" },
            };
            autoList1.Reset();
            autoList1.submit.Text = "Remove";
            autoList1.cancel.Text = "Cancel";
            this.autoList1.Show();
            this.autoPage1.Hide();
        }

        private void viewBlacklistRulesToolStripMenuItem_Click(object sender, EventArgs e) {
            autoList1.Title = "View Blacklist Rules";
            autoList1["labels"] = new string[] { "User", "Action", "Allow" };
            autoList1.values = new string[][] {
                new string[] { "GS/*",  "Create/Offence", "true" },
                new string[] { "GS/*",  "Delete/Offence", "false" },
                new string[] { "GS/*",  "List/Offence", "true" },
                new string[] { "GS/*",  "View/Offence", "true" },
                new string[] { "GS/*",  "Modify/Offence", "true" },
                new string[] { "MLA/*", "Delete/*", "false" },
                new string[] { "MLA/*", "Modify/*", "false" },
                new string[] { "MLA/*", "View/*", "false" },
                new string[] { "MLA/*", "List/*", "false" },
                new string[] { "MLA/*", "Create/*", "false" },
                new string[] { "MLA/*", "Create/Licence", "true" },
                new string[] { "PPB/Supervisor/*", "Delete/*", "false" },
                new string[] { "PPB/Staff/*", "Delete/*", "false" },
                new string[] { "PPB/Staff/*", "Modify/Regulations", "true" },
                new string[] { "PPB/Admin/101", "Delete/*", "true" },
            };
            autoList1.Reset();
            autoList1.submit.Text = "Search";
            autoList1.cancel.Text = "Cancel";
            this.autoList1.Show();
            this.autoPage1.Hide();
        }

        private void revokeUsersToolStripMenuItem_Click(object sender, EventArgs e) {
            autoList1.Title = "Revoke Users";
            autoList1["labels"] = new string[] { "User Name", "Organization ID", "Position", "DateAdded" };
            autoList1.values = new string[][] {
                new string[] { "j.smith", "Motor Licence Authority", "Staff", DateTime.Now.ToShortDateString() },
                new string[] { "j.smith", "Motor Licence Authority", "Staff", DateTime.Now.ToShortDateString() },
                new string[] { "j.smith", "Motor Licence Authority", "Staff", DateTime.Now.ToShortDateString() },
                new string[] { "j.smith", "Motor Licence Authority", "Staff", DateTime.Now.ToShortDateString() }
            };
            autoList1.Reset();
            autoList1.submit.Text = "Revoke";
            autoList1.cancel.Text = "Cancel";
            this.autoList1.Show();
            this.autoPage1.Hide();
        }

        private void searchAListToolStripMenuItem_Click(object sender, EventArgs e) {
            autoList1.Title = "Search A List";
            autoList1["labels"] = new string[] { "User Name", "Organization ID", "Position", "DateAdded" };
            autoList1.values = new string[][] {
                new string[] { "j.smith", "Motor Licence Authority", "Staff", DateTime.Now.ToShortDateString() },
                new string[] { "j.smith", "Motor Licence Authority", "Staff", DateTime.Now.ToShortDateString() },
                new string[] { "j.smith", "Motor Licence Authority", "Staff", DateTime.Now.ToShortDateString() },
                new string[] { "j.smith", "Motor Licence Authority", "Staff", DateTime.Now.ToShortDateString() }
            };
            autoList1.Reset();
            autoList1.submit.Text = "Search";
            autoList1.cancel.Text = "Cancel";
            this.autoList1.Show();
            this.autoPage1.Hide();
        }

        private void generatePublicNoticeOfRegulationsListToolStripMenuItem1_Click(object sender, EventArgs e) {
            autoList1.Title = "Generate Public Notice of Regulations";
            autoList1["labels"] = new string[] { "Description", "Points", "Points on Conviction", "Fine", "Fine on Conviction" };
            autoList1.values = new string[][] {
                new string[] { "Speeding", "2", "4", "80", "120" },
                new string[] { "Failure to obey traffic lights", "2", "4", "80", "120" },
                new string[] { "Holding a mobile phone", "2", "4", "80", "120" },
            };
            autoList1.Reset();
            autoList1.submit.Text = "Print";
            autoList1.cancel.Text = "Cancel";
            this.autoList1.Show();
            this.autoPage1.Hide();
        }

        private void viewUserListToolStripMenuItem_Click(object sender, EventArgs e) {
            autoList1.Title = "View User List";
            autoList1["labels"] = new string[] { "User Name", "Organization ID", "Position", "DateAdded" };
            autoList1.values = new string[][] {
                new string[] { "j.smith", "Motor Licence Authority", "Staff", DateTime.Now.ToShortDateString() },
                new string[] { "j.smith", "Motor Licence Authority", "Staff", DateTime.Now.ToShortDateString() },
                new string[] { "j.smith", "Motor Licence Authority", "Staff", DateTime.Now.ToShortDateString() },
                new string[] { "j.smith", "Motor Licence Authority", "Staff", DateTime.Now.ToShortDateString() }
            };
            autoList1.Reset();
            autoList1.submit.Text = "Search";
            autoList1.cancel.Text = "Cancel";
            this.autoList1.Show();
            this.autoPage1.Hide();
        }








        private void gardaReportsCourtSummonsToolStripMenuItem_Click(object sender, EventArgs e) {
            autoPage1.Title = "Garda Reports Court Summons";
            autoPage1["labels"] = new string[] { "Reference No", "Offence", "Court Date", "Location", "Licence No", "Vehicle Registration" };
            autoPage1["values"] = new string[] { "40123456789", "", DateTime.Now.ToString(), "", "", "" };
            autoPage1["inputs"] = new string[] { "TextBox", "TextBox", "DateTimePicker", "TextBox", "TextBox", "TextBox" };
            autoPage1.Reset();
            autoPage1.submit.Text = "Submit";
            autoPage1.cancel.Text = "Cancel";
            this.autoList1.Hide();
            this.autoPage1.Show();
        }

        private void notifyDriverOfSuccessfulAppealToolStripMenuItem_Click(object sender, EventArgs e) {
            autoPage1.Title = "Notify Driver of Successful Appeal";
            autoPage1["labels"] = new string[] { "Reference No", "Time / Date", "Location", "Licence No", "Vehicle Registration" };
            autoPage1["values"] = new string[] { "40123456789", DateTime.Now.ToString(), "R415", "101", "131D123456" };
            autoPage1["inputs"] = new string[] { "TextBox", "DateTimePicker", "TextBox", "TextBox", "TextBox" };
            autoPage1.Reset();
            autoPage1.submit.Text = "Notify";
            autoPage1.cancel.Text = "Cancel";
            this.autoList1.Hide();
            this.autoPage1.Show();
        }

        private void generateReportOfUserProductivityToolStripMenuItem_Click(object sender, EventArgs e) {
            autoPage1.Title = "Generate Report of User Productivity";
            autoPage1["labels"] = new string[] { "Reference No", "Time / Date", "Location", "Licence No", "Vehicle Registration" };
            autoPage1["values"] = new string[] { "40123456789", DateTime.Now.ToString(), "R415", "101", "131D123456" };
            autoPage1["inputs"] = new string[] { "TextBox", "DateTimePicker", "TextBox", "TextBox", "TextBox" };
            autoPage1.Reset();
            autoPage1.submit.Text = "Notify";
            autoPage1.cancel.Text = "Cancel";
            this.autoList1.Hide();
            this.autoPage1.Show();
        }

        private void editReportToolStripMenuItem_Click(object sender, EventArgs e) {
            autoPage1.Title = "Edit Report";
            autoPage1["labels"] = new string[] { "Reference No", "Time / Date", "Location", "Licence No", "Vehicle Registration" };
            autoPage1["values"] = new string[] { "40123456789", DateTime.Now.ToString(), "R415", "101", "131D123456" };
            autoPage1["inputs"] = new string[] { "TextBox", "DateTimePicker", "TextBox", "TextBox", "TextBox" };
            autoPage1.Reset();
            autoPage1.submit.Text = "Notify";
            autoPage1.cancel.Text = "Cancel";
            this.autoList1.Hide();
            this.autoPage1.Show();
        }

        private void restorePreviousDatabaseBackupToolStripMenuItem_Click(object sender, EventArgs e) {
            autoPage1.Title = "Restore Previous Database Backup";
            autoPage1["labels"] = new string[] { "Name", "Start Date", "Repeat Interval", "Specify item to backup" };
            autoPage1["values"] = new string[] { "", DateTime.Now.ToString(), "", "", "" };
            autoPage1["inputs"] = new string[] { "TextBox", "DateTimePicker", "TextBox", "TextBox" };
            autoPage1.Reset();
            autoPage1.submit.Text = "Restore";
            autoPage1.cancel.Text = "Cancel";
            this.autoList1.Hide();
            this.autoPage1.Show();
        }

        private void removingABlackListRuleToolStripMenuItem_Click(object sender, EventArgs e) {
            autoPage1.Title = "Removing a Black List Rule";
            autoPage1["labels"] = new string[] { "User", "Action", "Allow? (Uncheck for Deny)" };
            autoPage1["values"] = new string[] { "PPB/Team1/Staff/j.smith", "Delete/Offences/*", "false" };
            autoPage1["inputs"] = new string[] { "TextBox", "TextBox", "CheckBox" };
            autoPage1.submit.Text = "Delete";
            autoPage1.cancel.Text = "Reset";
            autoPage1.Reset();
            this.autoList1.Hide();
            this.autoPage1.Show();
        }


        private void remoteOrganizationRegisterUsersToBeAddedToolStripMenuItem_Click(object sender, EventArgs e) {
            autoPage1.Title = "Remote Organization Register Users to be Added";
            autoPage1["labels"] = new string[] { "User ID", "Organization ID", "DateAdded" };
            autoPage1["values"] = new string[] { "G8663322", "MLA", DateTime.Now.ToShortDateString() };
            autoPage1["inputs"] = new string[] { "TextBox", "TextBox", "DateTimePicker" };
            autoPage1.submit.Text = "Submit";
            autoPage1.cancel.Text = "Cancel";
            autoPage1.Reset();
            this.autoList1.Hide();
            this.autoPage1.Show();
        }

        //steve
        private void remoteOrganizationRegisterUsersToBeRevokedToolStripMenuItem_Click(object sender, EventArgs e) {
            autoList1.Title = "Revoke Remote Oranization Users";
            autoList1["labels"] = new string[] { "User Name", "Organization ID", "DateAdded" };
            autoList1.values = new string[][] {
                new string[] { "M973888", "Motor Licence Authority", DateTime.Now.ToShortDateString() },
                new string[] { "M937772", "Motor Licence Authority", DateTime.Now.ToShortDateString() },
                new string[] { "M774443", "Motor Licence Authority", DateTime.Now.ToShortDateString() },
                new string[] { "M", "Motor Licence Authority", DateTime.Now.ToShortDateString() }
            };
            autoList1.Reset();
            autoList1.submit.Text = "Revoke";
            autoList1.cancel.Text = "Cancel";
            this.autoList1.Show();
            this.autoPage1.Hide();
        }

        //steve
        private void speedCameraReportsOffenceToolStripMenuItem_Click(object sender, EventArgs e) {
            autoPage1.Title = "Speed Camera Reports Offence";
            autoPage1["labels"] = new string[] { "Camera Reg No", "Offence", "TimeDate", "Location", "Photograph" };
            autoPage1["values"] = new string[] { "G8663322", "This is a drop down of regulations", DateTime.Now.ToShortDateString(), "M50", "723.jpg" };
            autoPage1["inputs"] = new string[] { "TextBox", "MLAComboBox", "DateTimePicker", "TextBox", "TextBox" };
            autoPage1.submit.Text = "Submit";
            autoPage1.cancel.Text = "Cancel";
            autoPage1.Reset();
            this.autoList1.Hide();
            this.autoPage1.Show();
        }

        private void notifyDriverOfAcquittalToolStripMenuItem_Click(object sender, EventArgs e) {
            autoPage1.Title = "Notify Driver Of Acquittal";
            autoPage1["labels"] = new string[] { "Reference No", "Time / Date", "Location", "Licence No", "Vehicle Registration" };
            autoPage1["values"] = new string[] { "40123456789", DateTime.Now.ToString(), "R415", "101", "131D123456" };
            autoPage1["inputs"] = new string[] { "TextBox", "DateTimePicker", "TextBox", "TextBox", "TextBox" };
            autoPage1.Reset();
            autoPage1.submit.Text = "Notify";
            autoPage1.cancel.Text = "Cancel";
            this.autoList1.Hide();
            this.autoPage1.Show();
        }

        private void notifyDriverOfDisqualificationToolStripMenuItem_Click(object sender, EventArgs e) {
            autoPage1.Title = "Notify Driver Of Disqualification";
            autoPage1["labels"] = new string[] { "Reference No", "Time / Date", "Location", "Licence No", "Vehicle Registration" };
            autoPage1["values"] = new string[] { "40123456789", DateTime.Now.ToString(), "R415", "101", "131D123456" };
            autoPage1["inputs"] = new string[] { "TextBox", "DateTimePicker", "TextBox", "TextBox", "TextBox" };
            autoPage1.Reset();
            autoPage1.submit.Text = "Notify";
            autoPage1.cancel.Text = "Cancel";
            this.autoList1.Hide();
            this.autoPage1.Show();
        }

        private void driverOfEndorsementToolStripMenuItem_Click(object sender, EventArgs e) {
            autoPage1.Title = "Notify Driver Of Endorsement";
            autoPage1["labels"] = new string[] { "Reference No", "Time / Date", "Location", "Licence No", "Vehicle Registration" };
            autoPage1["values"] = new string[] { "40123456789", DateTime.Now.ToString(), "R415", "101", "131D123456" };
            autoPage1["inputs"] = new string[] { "TextBox", "DateTimePicker", "TextBox", "TextBox", "TextBox" };
            autoPage1.Reset();
            autoPage1.submit.Text = "Notify";
            autoPage1.cancel.Text = "Cancel";
            this.autoList1.Hide();
            this.autoPage1.Show();
        }

        private void filteringAListToolStripMenuItem_Click(object sender, EventArgs e) {
            //Textbox myTb = new TextBox();
            Button myButton = new Button();
            autoList1.Title = "Revoke Remote Oranization Users";
            autoList1["labels"] = new string[] { "User Name", "Organization ID", "DateAdded" };
            autoList1.values = new string[][] {
                new string[] { "M973888", "Motor Licence Authority", DateTime.Now.ToShortDateString() },
                new string[] { "M937772", "Motor Licence Authority", DateTime.Now.ToShortDateString() },
                new string[] { "M774443", "Motor Licence Authority", DateTime.Now.ToShortDateString() },
                new string[] { "M", "Motor Licence Authority", DateTime.Now.ToShortDateString() }
            };
            autoList1.Reset();
            autoList1.submit.Text = "Select";
            autoList1.cancel.Text = "Cancel";

            this.autoList1.Show();
            this.autoPage1.Hide();
        }

        private void scheduleIncrementalBackUpToolStripMenuItem_Click(object sender, EventArgs e) {
            autoPage1.Title = "Schedule Incremental backups";
            autoPage1["labels"] = new string[] { "Name", "Start Date", "Repeat Interval", "Specify item to backup" };
            autoPage1["values"] = new string[] { "", DateTime.Now.ToString(), "", "", "" };
            autoPage1["inputs"] = new string[] { "TextBox", "DateTimePicker", "TextBox", "TextBox" };
            autoPage1.Reset();
            autoPage1.submit.Text = "Schedule";
            autoPage1.cancel.Text = "Cancel";
            this.autoList1.Hide();
            this.autoPage1.Show();
        }

        private void viewOffenceRecordHistoryToolStripMenuItem_Click(object sender, EventArgs e) {
            autoList1.Title = "View offence history";
            autoList1["labels"] = new string[] { "offenceID", "Offence Name", "DateAdded" };
            autoList1.values = new string[][] {
                new string[] { "44", "speeding", DateTime.Now.ToShortDateString() },
                new string[] { "45", "dangerous driving", DateTime.Now.ToShortDateString() },
                new string[] { "46", "drunk driving", DateTime.Now.ToShortDateString() },

            };
            autoList1.Reset();
            autoList1.submit.Text = "Search";
            autoList1.cancel.Text = "Cancel";
            this.autoList1.Show();
            this.autoPage1.Hide();
        }

        private void issueingAFineToolStripMenuItem_Click(object sender, EventArgs e) {
            autoPage1.Title = "Issue a Fine";
            autoPage1["labels"] = new string[] { "Driver ID", "Name", "Offence", "Fine", "Address 1", "Address 2" };
            autoPage1["values"] = new string[] { "40123456789", "joe", "Speeding Fine", "€30", "lit", "test" };
            autoPage1["inputs"] = new string[] { "TextBox", "TextBox", "TextBox", "TextBox", "TextBox", "TextBox" };
            autoPage1.Reset();
            autoPage1.submit.Text = "Submit";
            autoPage1.cancel.Text = "Cancel";
            this.autoList1.Hide();
            this.autoPage1.Show();
        }


        public void SetTheme(object sender, EventArgs e) {
            switch (MetroStyleManager.Default.Theme) {
            case "Dark": this.BackColor = Color.Black; break;
            case "Light": this.BackColor = Color.White; break;
            }

            this.tableLayoutPanel1.BackColor = this.BackColor;
            this.dashboardPanel.BackColor = this.BackColor;
            this.workspace.BackColor = this.BackColor;
            //this.autoPage1.OnBackColorChanged(sender, e);
            //this.autoList1.OnBackColorChanged(sender, e);
            this.autoPage1.Theme = MetroStyleManager.Default.Theme;
            this.autoList1.Theme = MetroStyleManager.Default.Theme;
        }

        private void autoList1_Load(object sender, EventArgs e) {

        }

        private void systemLoginToolStripMenuItem_Click(object sender, EventArgs e) {
            MessageBox.Show("Shown in the Server Console Window");
        }

        private void licenceAuthorityReportChangeOfDetailsToolStripMenuItem_Click(object sender, EventArgs e) {
            autoPage1.Title = "Change Driver Details";
            autoPage1["labels"] = new string[] { "First Name", "Last Name", "Address 1", "Address 2", "City", "County", "DateOfBirth" };
            autoPage1["values"] = new string[] { "John", "Smith", "123 Sunnydale Dr", "Ashbrooke", "Limerick", "Limerick", DateTime.Now.ToShortDateString() };
            autoPage1["inputs"] = new string[] { "TextBox", "TextBox", "TextBox", "TextBox", "TextBox", "TextBox", "DateTimePicker" };
            autoPage1.submit.Text = "Submit";
            autoPage1.cancel.Text = "Cancel";
            autoPage1.Reset();
            this.autoList1.Hide();
            this.autoPage1.Show();
        }

        private void automaticDisqualificationToolStripMenuItem_Click(object sender, EventArgs e) {
            MessageBox.Show("Will be handled as a trigger in the database");
        }

        private void gardaReportsCourtRulingsToolStripMenuItem_Click(object sender, EventArgs e) {
            autoPage1.Title = "Garda Reports Court Ruling";
            autoPage1["labels"] = new string[] { "Reference No", "Offence", "Court Date", "Location", "Licence No", "Vehicle Registration", "Acquitted", "Convicted", "Disqualified" };
            autoPage1["values"] = new string[] { "40123456789", "", DateTime.Now.ToString(), "", "", "", "false", "false", "false" };
            autoPage1["inputs"] = new string[] { "TextBox", "TextBox", "DateTimePicker", "TextBox", "TextBox", "TextBox", "CheckBox", "CheckBox", "CheckBox" };
            autoPage1.Reset();
            autoPage1.submit.Text = "Submit";
            autoPage1.cancel.Text = "Cancel";
            this.autoList1.Hide();
            this.autoPage1.Show();
        }

        private void driverPaysFineToolStripMenuItem_Click(object sender, EventArgs e) {
            autoPage1.Title = "Driver Pays Fine";
            autoPage1["labels"] = new string[] { "Reference No", "Licence No", "Date", "Previous Balance", "Amount Paid", "Remaining Balance" };
            autoPage1["values"] = new string[] { "40123456789", "101", DateTime.Now.ToString(), "120.00", "", "" };
            autoPage1["inputs"] = new string[] { "TextBox", "TextBox", "DateTimePicker", "TextBox", "TextBox", "TextBox" };
            autoPage1.Reset();
            autoPage1.submit.Text = "Pay Fine";
            autoPage1.cancel.Text = "Cancel";
            this.autoList1.Hide();
            this.autoPage1.Show();
        }

        private void customizeReportToolStripMenuItem_Click(object sender, EventArgs e) {
            MessageBox.Show("In progress .. Check Back Soon");
        }

        private void viewingALogToolStripMenuItem_Click(object sender, EventArgs e) {
            MessageBox.Show("In progress .. Check Back Soon");
        }

        private void createBlackListRuleToolStripMenuItem_Click(object sender, EventArgs e) {
            autoPage1.Title = "Create BlackList Rules";
            autoPage1["labels"] = new string[] { "User", "Action", "Allow? (Uncheck for Deny)" };
            autoPage1["values"] = new string[] { "", "", "false" };
            autoPage1["inputs"] = new string[] { "TextBox", "TextBox", "CheckBox" };
            autoPage1.submit.Text = "Create";
            autoPage1.cancel.Text = "Reset";
            autoPage1.Reset();
            this.autoList1.Hide();
            this.autoPage1.Show();
        }

        private void userLoginToolStripMenuItem_Click(object sender, EventArgs e) {
            Frame frame = Parent as Frame;
            if (frame != null) {
                this.Hide();
                frame.loginForm.Show();
            }
        }

        private void viewUserDetailsToolStripMenuItem_Click(object sender, EventArgs e) {
            autoPage1.Title = "View User Details";
            autoPage1["labels"] = new string[] { "User Name", "Organization ID", "Position", "DateAdded" };
            autoPage1["values"] = new string[] { "John.Smith", "PPB", "Staff", DateTime.Now.ToShortDateString() };
            autoPage1["inputs"] = new string[] { "TextBox", "TextBox", "TextBox", "DateTimePicker" };
            autoPage1.submit.Text = "Submit";
            autoPage1.cancel.Text = "Cancel";
            autoPage1.Reset();
            this.autoList1.Hide();
            this.autoPage1.Show();
        }

        private void licenceAuthorityIssueNewLicenceToolStripMenuItem_Click(object sender, EventArgs e) {
            MessageBox.Show("Will be handled as a trigger in the database");
        }

        private void notifyLicenceAuthorityOfOverturnedDisqualificationToolStripMenuItem_Click(object sender, EventArgs e) {
            MessageBox.Show("Will be handled as a trigger in the database");
        }

        private void viewOffenceListToolStripMenuItem_Click(object sender, EventArgs e) {
            autoList1.Title = "View Offence List";
            autoList1["labels"] = new string[] { "Reference No", "Offence", "Time / Date", "Location", "Licence No", "Vehicle Registration" };
            autoList1.values = new string[][] {
                new string[] { "40123456789",  "Speeding", "1-1-2016", "R406", "102", "99CE1234" },
                new string[] { "40123456701",  "Drink Driving", "1-1-2016", "R406", "102", "99CE1235" },
                new string[] { "40123456702",  "Speeding", "1-1-2016", "R406", "102", "99CE1236" },
                new string[] { "40123456703",  "Speeding", "1-1-2016", "R406", "102", "99CE1237" },
                new string[] { "40123456704",  "Speeding", "1-1-2016", "R406", "102", "99CE1238" },
                new string[] { "40123456705",  "Speeding", "1-1-2016", "R406", "102", "99CE1239" },
                new string[] { "40123456706",  "Speeding", "1-1-2016", "R406", "102", "99LK1234" },
                new string[] { "40123456707",  "Speeding", "1-1-2016", "R406", "102", "99LK1235" },
                new string[] { "40123456708",  "Speeding", "1-1-2016", "R406", "102", "99LK1236" },
                new string[] { "40123456709",  "Speeding", "1-1-2016", "R406", "102", "99LK1237" },
                new string[] { "40123456710",  "Speeding", "1-1-2016", "R406", "102", "99LK1238" },
                new string[] { "40123456711",  "Speeding", "1-1-2016", "R406", "102", "99LK1239" },
            };
            autoList1.Reset();
            autoList1.submit.Text = "Submit";
            autoList1.cancel.Text = "Cancel";
            this.autoPage1.Hide();
            this.autoList1.Show();

        }

        private void penaltyPointsExpireAutomaticallyToolStripMenuItem_Click(object sender, EventArgs e) {
            MessageBox.Show("Will be handled as a calculated feild in the database");
        }

        private void automaticLogSyncOnEachEntryToolStripMenuItem_Click(object sender, EventArgs e) {
            MessageBox.Show("Handled on the Client Side during a request,\r\nAnd on the Server Side when receiving a request");
        }

        private void searchingAndFilteringALogToolStripMenuItem_Click(object sender, EventArgs e) {
            autoList1.Title = "Searchin and Filtering a Log";
            autoList1["labels"] = new string[] { "Time / Date", "UserName", "Action", "Description", "Reason" };
            autoList1.values = new string[][] {
                new string[] { "1-1-2016", "John.Smith", "Create/User/101", "Create User 'Test'", "" },
                new string[] { "1-1-2016", "John.Smith", "Update/User/101", "Update User 'Test'", "" },
                new string[] { "1-1-2016", "John.Smith", "Delete/User/101", "Delete User 'Test'", "Testing delete function" },
            };
            autoList1.Reset();
            autoList1.submit.Text = "Submit";
            autoList1.cancel.Text = "Cancel";
            this.autoPage1.Hide();
            this.autoList1.Show();
        }
    }
}
