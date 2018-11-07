using System.Windows.Forms;

namespace View {
    partial class AutoPanel {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.metroPanel1 = new MetroFramework.Controls.MetroPanel();
            this.reset = new MetroFramework.Controls.MetroButton();
            this.apply = new MetroFramework.Controls.MetroButton();
            this.title = new MetroFramework.Controls.MetroLabel();
            this.content = new System.Windows.Forms.Panel();
            this.metroPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // metroPanel1
            // 
            this.metroPanel1.Controls.Add(this.reset);
            this.metroPanel1.Controls.Add(this.apply);
            this.metroPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.metroPanel1.HorizontalScrollbarBarColor = true;
            this.metroPanel1.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel1.HorizontalScrollbarSize = 10;
            this.metroPanel1.Location = new System.Drawing.Point(0, 363);
            this.metroPanel1.Name = "metroPanel1";
            this.metroPanel1.Size = new System.Drawing.Size(411, 64);
            this.metroPanel1.TabIndex = 1;
            this.metroPanel1.VerticalScrollbarBarColor = true;
            this.metroPanel1.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel1.VerticalScrollbarSize = 10;
            // 
            // reset
            // 
            this.reset.Location = new System.Drawing.Point(91, 22);
            this.reset.Name = "reset";
            this.reset.Size = new System.Drawing.Size(75, 23);
            this.reset.TabIndex = 3;
            this.reset.Text = "Reset";
            // 
            // apply
            // 
            this.apply.Location = new System.Drawing.Point(253, 22);
            this.apply.Name = "apply";
            this.apply.Size = new System.Drawing.Size(75, 23);
            this.apply.TabIndex = 2;
            this.apply.Text = "Apply";
            // 
            // title
            // 
            this.title.Dock = System.Windows.Forms.DockStyle.Top;
            this.title.FontSize = MetroFramework.Drawing.MetroFontSize.Large;
            this.title.Location = new System.Drawing.Point(0, 0);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(411, 74);
            this.title.TabIndex = 2;
            this.title.Text = "title";
            this.title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // content
            // 
            this.content.Dock = System.Windows.Forms.DockStyle.Fill;
            this.content.Location = new System.Drawing.Point(0, 74);
            this.content.Name = "content";
            this.content.Size = new System.Drawing.Size(411, 289);
            this.content.TabIndex = 3;
            // 
            // AutoPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.content);
            this.Controls.Add(this.title);
            this.Controls.Add(this.metroPanel1);
            this.Name = "AutoPanel";
            this.Size = new System.Drawing.Size(411, 427);
            this.metroPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private MetroFramework.Controls.MetroPanel metroPanel1;
        public MetroFramework.Controls.MetroButton reset;
        public MetroFramework.Controls.MetroButton apply;
        public MetroFramework.Controls.MetroLabel title;
        private Panel content;
    }
}
