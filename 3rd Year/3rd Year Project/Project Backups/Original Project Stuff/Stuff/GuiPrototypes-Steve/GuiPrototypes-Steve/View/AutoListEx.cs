using MetroFramework.Controls;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

namespace PenaltyPointsBureau {
    public class AutoListEx : ListViewEx {
        private NameValueCollection headings;

        public AutoListEx() : base() {
            headings = new NameValueCollection();

            TabStop = false;
            Location = new Point(0, 0);
            Size = new Size(397, 353);
            Text = "AutoList";
            FullRowSelect = true;
            UseCompatibleStateImageBehavior = false;
            GridLines = true;
            DoubleBuffered = true;
            View = View.Details;
            //LargeImageList = this.imageList1;
            //SmallImageList = this.imageList1;
        }

        public void SetHeadings(NameValueCollection list) {
            headings = list;
            this.Columns.Clear();
            for (int i = 0; i < list.Count; i++) {
                ColumnHeader column = new ColumnHeader();
                column.Text = list.GetValues(i)[0];
                Columns.Add(column);
            }
        }

        public void Populate<T>(List<T> list) {
            int tabIndex = 0;
            foreach (T o in list) {
                FieldInfo[] members = o.GetType().GetFields(BindingFlags.Public | BindingFlags.Instance);
                List<string> records = new List<string>();
                foreach (FieldInfo member in members) {
                    object valu = member.GetValue(o);
                    string text = (valu == null) ? "" : valu.ToString();
                    string type = member.FieldType.Name;
                    string name = member.Name;

                    // TODO : Check Black List
                    if (headings[name] == null) continue;
                    records.Add(text);
                    tabIndex++;
                }
                Items.Add(new ListViewItem(records.ToArray()));
            }
            int row = 0;
            foreach (T o in list) {
                int col = 0;
                FieldInfo[] members = o.GetType().GetFields(BindingFlags.Public | BindingFlags.Instance);
                List<string> records = new List<string>();
                foreach (FieldInfo member in members) {
                    object valu = member.GetValue(o);
                    string text = (valu == null) ? "" : valu.ToString();
                    string type = member.FieldType.Name;
                    string name = member.Name;

                    // TODO : Check Black List
                    if (headings[name] == null) continue;

                    Control control = new AutoWidget().Produce(type, name, text.ToString(), row);
                    Controls.Add(control);
                    AddEmbeddedControl(control, col, row);

                    col++;
                }
                row++;
            }

            Size = new Size(200 + 64, tabIndex*32 + 64);
            Location = new Point(0, 0);
            Dock = DockStyle.Top;
        }
    }
}
