using MetroFramework.Controls;
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
    public partial class AutoList : UserControl {
        public AutoList() {
            meta = new Dictionary<string, string[]>();
            InitializeComponent();
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

        private Dictionary<string, string[]> meta;
        public string[][] values;

        public string[] this[string name] {
            get {
                if (meta.ContainsKey(name)) return meta[name];
                return null;
            }
            set {
                if (meta.ContainsKey(name)) meta[name] = value;
                else meta.Add(name, value);
            }
        }

        public bool Reset() {
            string[] labels = this["labels"];

            // place the input controls
            if (values != null) {
                // place the column headers
                ColumnHeader[] columns = new ColumnHeader[labels.Count()];
                if (labels != null) {
                    for (int count = 0; count < labels.Count(); count++) {
                        ColumnHeader column = new ColumnHeader();
                        column.Text = labels[count];
                        column.Width = 130;
                        columns[count] = column;
                    }
                }

                this.content.Columns.Clear();
                this.content.Columns.AddRange(columns);

                ListViewItem[] rows = new ListViewItem[values.Count()];
                int row = 0;
                foreach (string[] record in values) {
                    rows[row] = new ListViewItem(record, -1, Color.Empty, Color.Empty,
                        new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point,
                        ((byte)(0))));
                    row++;
                }
                this.content.Items.Clear();
                this.content.Items.AddRange(rows);
            }
            return true;
        }

        public void OnBackColorChanged(object sender, EventArgs e) {
            switch (MetroStyleManager.Default.Theme) {
            case "Dark": this.BackColor = Color.Black; break;
            case "Light": this.BackColor = Color.White; break;
            }
            this.vertical.BackColor = this.BackColor;
            this.horizontal.BackColor = this.BackColor;
            this.tableLayoutPanel1.BackColor = this.BackColor;
        }
    }

    public class MyListView : ListView {
        public MyListView() {
            this.DoubleBuffered = true;
        }
    }
}
