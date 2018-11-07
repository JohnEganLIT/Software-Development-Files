using System.Collections.Generic;
using System.Collections.Specialized;
using System.Windows.Forms;

namespace View {
    public partial class AutoPanel : UserControl {
        protected NameValueCollection headings;

        public AutoPanel() {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
        }

        public void SetTitle(string text) {
            this.title.Text = text;
        }

        public void SetHeadings(NameValueCollection list) {
            headings = list;
        }

        public void Populate(object o) {
            this.SuspendLayout();
            AutoPage child = new AutoPage();
            child.SetHeadings(headings);
            child.Populate(o);
            content.Controls.Add(child);
            ResumeLayout(false);
        }

        public void Populate<T>(List<T> list) {
            this.SuspendLayout();
            AutoList child = new AutoList();
            child.SetHeadings(headings);
            child.Populate<T>(list);
            content.Controls.Add(child);
            ResumeLayout(false);
        }
    }
}
