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
    public partial class AutoPage : UserControl {
        public AutoPage() {
            meta = new Dictionary<string, object>();
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

        private Dictionary<string, object> meta;

        public object this[string name] {
            get {
                foreach (Control c in this.Controls) {
                    if (c.Name == name) return c.ToString();
                }
                return null;
            }
            set {
                if (meta.ContainsKey(name)) meta[name] = value;
                else meta.Add(name, value);
            }
        }

        public bool Reset() {
            List<Control> list = new List<Control>();
            string[] labels = this["labels"] as string[];
            string[] fields = this["fields"] as string[];
            string[] inputs = this["inputs"] as string[];
            string[] values = this["values"] as string[];
            int deltaX = 32;
            int deltaY = 32;

            // place the labels
            if (labels != null) {
                for (int count = 0; count < labels.Count(); count++) {
                    if (inputs[count].ToLower() == "checkbox") continue;
                    MetroLabel widget = new MetroLabel();
                    widget.Text = labels[count];
                    widget.Location = new Point(deltaX + 16, deltaY + count*36 + 4);
                    widget.AutoSize = true;
                    list.Add(widget);
                }
            }

            // place the input controls
            if (values != null && inputs != null) {
                for (int count = 0; count < inputs.Count(); count++) {

                    Control widget  = null;
                    switch (inputs[count].ToLower()) {
                    default:
                    case "textbox":
                        widget = new TextBox();
                        widget.Text = values[count];
                        break;
                    case "datetimepicker":
                        widget = new DateTimePicker();
                        (widget as DateTimePicker).Value = DateTime.Parse(values[count]);
                        break;

                    case "MLAComboBox":
                        ComboBox regulationComboBox = new ComboBox();
                        regulationComboBox.FormattingEnabled = true;
                        regulationComboBox.Items.AddRange(new object[] { "LA01 Speeding", "LA02 Dangerous Driving"});
                        regulationComboBox.Location = new Point(3, 777);
                        regulationComboBox.Name = "regulationComboBox";
                        regulationComboBox.Size = new Size(121, 21);
                        regulationComboBox.TabIndex = 2;
                        widget = regulationComboBox;
                        break;
                    case "checkbox":
                        widget = new CheckBox();
                        (widget as CheckBox).Checked = bool.Parse(values[count]);
                        (widget as CheckBox).Text = labels[count];
                        break;
                    }

                    widget.Name     = fields[count];
                    widget.Location = new Point(deltaX + 160, deltaY + count*36);
                    widget.Size     = new Size(220,  count*23);
                    widget.Font     = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
                    list.Add(widget);
                }
            }

            this.content.Controls.Clear();
            foreach (Control widget in list) {
                this.content.Controls.Add(widget);
            }
            return true;
        }

        public void OnBackColorChanged(object sender, EventArgs e) {
            switch (MetroStyleManager.Default.Theme) {
            case "Dark":  this.BackColor = Color.Black; break;
            case "Light": this.BackColor = Color.White; break;
            }
            this.verticle.BackColor   = this.BackColor;
            this.horizontal.BackColor = this.BackColor;
            this.center.BackColor     = this.BackColor;
        }
    }
}
