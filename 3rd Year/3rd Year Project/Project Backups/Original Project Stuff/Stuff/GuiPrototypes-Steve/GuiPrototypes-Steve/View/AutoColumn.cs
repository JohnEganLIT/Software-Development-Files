using MetroFramework.Controls;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

namespace View {
    class AutoColumn {
        public DataGridViewColumn column;

        //private DataGridViewTextBoxColumn TextBoxColumn;
        //private DataGridViewLinkColumn LinkColumn;
        //private DataGridViewImageColumn ImageColumn;
        //private DataGridViewComboBoxColumn ComboBoxColumn;
        //private DataGridViewCheckBoxColumn CheckBoxColumn;
        //private DataGridViewButtonColumn ButtonColumn;
        public DataGridViewColumn Produce(string type, string name, string value) {
            switch (type) {
            default:
            case "String": column = new DataGridViewTextBoxColumn(); break;
            case "Int32": column = new DataGridViewTextBoxColumn(); break;
            case "Int63": column = new DataGridViewTextBoxColumn(); break;
            case "Double": column = new DataGridViewTextBoxColumn(); break;
            case "Email": column = new DataGridViewLinkColumn(); break;
            case "Password": column = new DataGridViewTextBoxColumn(); break;
            case "DateTime": column = new DataGridViewTextBoxColumn(); break;
            case "Domain": column = new DataGridViewComboBoxColumn(); break;
            }

            column.Name       = name+"."+type;
            column.HeaderText = value;
            return column;
        }
    }
}
