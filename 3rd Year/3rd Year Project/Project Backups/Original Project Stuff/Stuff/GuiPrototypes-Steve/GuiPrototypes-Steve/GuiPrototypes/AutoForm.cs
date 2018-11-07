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
    public partial class AutoForm : UserControl {
        public AutoForm() {
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
        public string[] this[string name] {
            get {
                if (meta.ContainsKey(name)) {
                    return meta[name];
                }
                return null;
            }
            set {
                if (meta.ContainsKey(name)) meta[name] = value;
                else meta.Add(name, value);
            }
        }

        public object Field(string name) {
            foreach (Control ctrl in this.content.Controls) {
                if (ctrl.Name == name) {
                    if (null != ctrl as DateTimePicker) {
                        DateTimePicker Date = ctrl as DateTimePicker;
                        return Date.Value.ToString("yyyy-MM-dd");
                        //return Date.Value.ToShortDateString();
                    } else return ctrl.Text.ToString();
                }
            }
            return null;
        }

        public bool Reset() {
            List<Control> list = new List<Control>();
            string[] labels = this["labels"];
            string[] fields = this["fields"] as string[];
            string[] inputs = this["inputs"];
            string[] values = this["values"];
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
                        widget.Text = values[count]; ;
                        break;
                    case "datetimepicker":
                        widget = new DateTimePicker();
                        (widget as DateTimePicker).Value = DateTime.Parse(values[count]);
                        break;
                    case "checkbox":
                        widget = new CheckBox();
                        (widget as CheckBox).Checked = bool.Parse(values[count]);
                        (widget as CheckBox).Text = labels[count];
                        break;
                    }

                    widget.Name     = fields[count];
                    widget.Location = new Point(deltaX + 160, deltaY + count*36);
                    widget.Size     = new Size(220, 23);
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
    }
}
