using MetroFramework.Controls;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

namespace View {
    public class AutoGrid : DataGridView {
        private NameValueCollection headings;

        public AutoGrid() : base() {
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();

            this.TabStop = false;
            this.Location = new Point(0, 0);
            ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            AutoGenerateColumns = true;
            DoubleBuffered = true;
            Dock = DockStyle.Top;
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
        }

        public void SetHeadings(NameValueCollection list) {
            headings = list;
        }

        public void Populate<T>(List<T> list) {
            this.Columns.Clear();
            int count = 0;
            T item = list[0];
            FieldInfo[] members = item.GetType().GetFields(BindingFlags.Public | BindingFlags.Instance);
            foreach (FieldInfo member in members) {
                object valu = member.GetValue(item);
                string text = (valu == null) ? "" : valu.ToString();
                string type = member.FieldType.Name;
                string name = member.Name;
                string value = headings[name];
                if (value == null) continue;

                DataGridViewColumn column = new AutoColumn().Produce(type, name, value);
                this.Columns.Add(column);
                count++;
            }
            Rows.Clear();
            foreach (T o in list) {
                int i = 0;
                object[] values = new object[count];
                FieldInfo[] feilds = o.GetType().GetFields(BindingFlags.Public | BindingFlags.Instance);
                foreach (FieldInfo member in feilds) {
                    string value = headings[member.Name];
                    if (value == null) continue;
                    values[i++] = member.GetValue(o);
                }
                Rows.Add(values);
            }
            Size = new Size(Size.Width, 32*list.Count + 64);
        }
    }
}
