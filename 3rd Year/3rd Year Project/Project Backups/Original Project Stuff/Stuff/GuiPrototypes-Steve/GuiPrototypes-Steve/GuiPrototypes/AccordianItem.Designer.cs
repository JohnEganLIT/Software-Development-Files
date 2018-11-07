namespace GuiPrototypes {
    partial class AccordianItem {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        #region Properties
        public string Title {
            get {
                return this.button.Text;
            }
            set {
                this.button.Text = value;
            }
        }
        #endregion

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
            this.content = new System.Windows.Forms.TableLayoutPanel();
            this.button = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.content.SuspendLayout();
            this.SuspendLayout();
            // 
            // content
            // 
            this.content.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.content.ColumnCount = 1;
            this.content.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.content.Controls.Add(this.button, 0, 0);
            this.content.Controls.Add(this.listView1, 0, 1);
            this.content.Dock = System.Windows.Forms.DockStyle.Fill;
            this.content.Location = new System.Drawing.Point(0, 0);
            this.content.Name = "content";
            this.content.RowCount = 2;
            this.content.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 48F));
            this.content.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.content.Size = new System.Drawing.Size(335, 256);
            this.content.TabIndex = 0;
            // 
            // button
            // 
            this.button.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button.Location = new System.Drawing.Point(3, 3);
            this.button.Name = "button";
            this.button.Size = new System.Drawing.Size(329, 42);
            this.button.TabIndex = 0;
            this.button.Text = "AccordianItemText";
            this.button.UseVisualStyleBackColor = true;
            // 
            // listView1
            // 
            this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView1.GridLines = true;
            this.listView1.Location = new System.Drawing.Point(3, 51);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(329, 202);
            this.listView1.TabIndex = 1;
            this.listView1.UseCompatibleStateImageBehavior = false;
            // 
            // AccordianItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.content);
            this.Name = "AccordianItem";
            this.Size = new System.Drawing.Size(335, 256);
            this.content.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel content;
        private System.Windows.Forms.Button button;
        private System.Windows.Forms.ListView listView1;
    }
}
