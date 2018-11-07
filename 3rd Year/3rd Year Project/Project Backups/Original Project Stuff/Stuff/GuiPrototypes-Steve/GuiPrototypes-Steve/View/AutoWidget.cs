using System.Drawing;
using System.Windows.Forms;

namespace View {
    class AutoWidget {
        public Control control;

        public Control Produce(string type, string name, string value, int tabIndex) {
            switch (type) {
            default:
            case "String": control = new TextBox(); break;
            case "Int32": control = new NumericUpDown(); break;
            case "Int63": control = new NumericUpDown(); break;
            case "Double": control = new TextBox(); break;
            case "Email": control = new TextBox(); break;
            case "Password": control = new TextBox(); break;
            case "DateTime": control = new DateTimePicker(); break;
            case "Domain": control = new TextBox(); break;
            }

            control.Name     = name+"."+type;
            control.Location = new Point(0, 0);
            control.Size     = new Size(220, 20);
            control.Text     = value;
            control.TabStop  = true;
            control.TabIndex = tabIndex;
            control.Font     = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));

            switch (type) {
            case "Int32": break;
            case "Int63": break;
            case "Double": break;
            case "String": break;
            case "Email": break;
            case "Password": (control as TextBox).PasswordChar = '✱'; break;
            case "DateTime": break;
            case "Domain": break;
            }
            return control;
        }
    }
}
