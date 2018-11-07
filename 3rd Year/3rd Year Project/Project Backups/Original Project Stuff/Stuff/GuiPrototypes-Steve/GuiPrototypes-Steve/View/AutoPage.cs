using Newtonsoft.Json;
using MetroFramework.Controls;
using System.Collections.Specialized;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using System.Collections.Generic;

namespace View {
    public class AutoPage : MetroPanel {
        protected NameValueCollection headings;

        public AutoPage() : base() {
            headings = new NameValueCollection();
            TabStop = false;
            Location = new Point(0, 0);
            Text = "AutoPage";
        }

        public void SetHeadings(NameValueCollection list) {
            headings = list;
        }

        public void Populate(object o) {
            int tabIndex = 0;
            int maxWidth = 0;
            FieldInfo[] members = o.GetType().GetFields(BindingFlags.Public | BindingFlags.Instance);
            foreach (FieldInfo member in members) {
                string name = member.Name;
                // TODO : Check Black List
                MetroLabel label = new MetroLabel();
                label.AutoSize = true;
                label.Location = new Point(32, tabIndex*32 + 4);
                label.Text = (headings[name] == null) ? name : headings[name];
                maxWidth = (label.Size.Width > maxWidth) ? label.Size.Width : maxWidth;
                Controls.Add(label);
                tabIndex++;
            }

            tabIndex = 0;
            foreach (FieldInfo member in members) {
                object valu = member.GetValue(o);
                string text = (valu == null) ? "" : valu.ToString();
                string type = member.FieldType.Name;
                string name = member.Name;

                // TODO : Check Black List
                Control control = new AutoWidget().Produce(type, name, text.ToString(), tabIndex);
                control.Location = new Point(maxWidth + 32, tabIndex*32);
                Controls.Add(control);
                tabIndex++;
            }
            //Size = new Size(maxWidth + 220 + 64, tabIndex*32 + 128);
            //Location = new Point(0, 0);
            Dock = DockStyle.Fill;
        }
    }
}
