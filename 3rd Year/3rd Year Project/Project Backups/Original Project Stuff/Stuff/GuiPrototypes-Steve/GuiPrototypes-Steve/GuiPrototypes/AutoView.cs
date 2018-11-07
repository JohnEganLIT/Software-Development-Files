using MetroFramework.Controls;
using MetroFramework.Components;
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
    public partial class AutoView : UserControl {
        public AutoView() {
            meta = new Dictionary<string, string[]>();
            InitializeComponent();
            this.DoubleBuffered = true;
            this.content.View = System.Windows.Forms.View.Details;
        }

        private void config_Click(object sender, EventArgs e) {
            MessageBox.Show("");
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) {
            switch (this.comboBox1.SelectedIndex) {
            case 0: this.content.View = System.Windows.Forms.View.List; break;
            case 1: this.content.View = System.Windows.Forms.View.Details; break;
            case 2: this.content.View = System.Windows.Forms.View.SmallIcon; break;
            case 3: this.content.View = System.Windows.Forms.View.LargeIcon; break;
            case 4: this.content.View = System.Windows.Forms.View.Tile; break;
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
                    rows[row] = new ListViewItem(record, 0, Color.Empty, Color.Empty,
                        new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point,
                        ((byte)(0))));
                    row++;
                }
                this.content.Items.Clear();
                this.content.Items.AddRange(rows);
            }
            return true;
        }
    }
}
