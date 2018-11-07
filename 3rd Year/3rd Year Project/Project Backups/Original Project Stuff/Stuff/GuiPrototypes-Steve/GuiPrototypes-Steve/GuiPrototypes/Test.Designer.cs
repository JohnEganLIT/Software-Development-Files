namespace GuiPrototypes {
    partial class Test {
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.autoView1 = new GuiPrototypes.AutoView();
            this.SuspendLayout();
            // 
            // autoView1
            // 
            this.autoView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.autoView1.Location = new System.Drawing.Point(20, 60);
            this.autoView1.Name = "autoView1";
            this.autoView1.Size = new System.Drawing.Size(420, 515);
            this.autoView1.TabIndex = 0;
            // 
            // Test
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(460, 595);
            this.Controls.Add(this.autoView1);
            this.Name = "Test";
            this.Text = "Test";
            this.ResumeLayout(false);

        }

        #endregion

        public AutoView autoView1;
    }
}