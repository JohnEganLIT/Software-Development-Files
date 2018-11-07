namespace GuiPrototypes {
    partial class AutoForm {
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

        #region Properties
        public string Title {
            get {
                return this.titleLabel.Text;
            }
            set {
                this.titleLabel.Text = value;
            }
        }

        public string Theme {
            get {
                return this.Theme;
            }
            set {
                switch (value) {
                case "Light":
                    System.Drawing.Color Back = System.Drawing.Color.FromArgb(255,255,255);
                    System.Drawing.Color Fore = System.Drawing.Color.FromArgb( 16, 16, 16);
                    this.BackColor = this.content.BackColor = Back;
                    this.ForeColor = this.content.ForeColor = Fore;
                    foreach (System.Windows.Forms.Control widget in this.content.Controls) {
                        widget.BackColor = Back;
                        widget.ForeColor = Fore;
                    }
                    break;
                case "Dark":
                    System.Drawing.Color DarkBack = System.Drawing.Color.FromArgb( 17, 17, 17);
                    System.Drawing.Color DarkFore = System.Drawing.Color.FromArgb(240,240,240);
                    this.BackColor = this.content.BackColor = DarkBack;
                    this.ForeColor = this.content.ForeColor = DarkFore;
                    foreach (System.Windows.Forms.Control widget in this.content.Controls) {
                        widget.BackColor = DarkBack;
                        widget.ForeColor = DarkFore;
                    }
                    break;
                }
            }
        }
        #endregion
        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.metroPanel1 = new MetroFramework.Controls.MetroPanel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.titleLabel = new MetroFramework.Controls.MetroTile();
            this.metroTile2 = new MetroFramework.Controls.MetroTile();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.submit = new System.Windows.Forms.Button();
            this.cancel = new System.Windows.Forms.Button();
            this.content = new MetroFramework.Controls.MetroPanel();
            this.metroPanel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.metroTile2.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // metroPanel1
            // 
            this.metroPanel1.Controls.Add(this.tableLayoutPanel1);
            this.metroPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.metroPanel1.HorizontalScrollbarBarColor = true;
            this.metroPanel1.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel1.HorizontalScrollbarSize = 10;
            this.metroPanel1.Location = new System.Drawing.Point(0, 0);
            this.metroPanel1.Name = "metroPanel1";
            this.metroPanel1.Size = new System.Drawing.Size(412, 500);
            this.metroPanel1.TabIndex = 0;
            this.metroPanel1.VerticalScrollbarBarColor = true;
            this.metroPanel1.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel1.VerticalScrollbarSize = 10;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.titleLabel, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.metroTile2, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.content, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 64F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 48F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(412, 500);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // titleLabel
            // 
            this.titleLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.titleLabel.FontSize = MetroFramework.Drawing.MetroFontSize.Large;
            this.titleLabel.FontWeight = MetroFramework.Drawing.MetroFontWeight.Bold;
            this.titleLabel.Location = new System.Drawing.Point(3, 3);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(406, 58);
            this.titleLabel.TabIndex = 0;
            this.titleLabel.Text = "Title";
            this.titleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // metroTile2
            // 
            this.metroTile2.Controls.Add(this.tableLayoutPanel2);
            this.metroTile2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.metroTile2.Location = new System.Drawing.Point(3, 455);
            this.metroTile2.Name = "metroTile2";
            this.metroTile2.Size = new System.Drawing.Size(406, 42);
            this.metroTile2.TabIndex = 1;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel2.ColumnCount = 5;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 96F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 64F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 96F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.submit, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.cancel, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(406, 42);
            this.tableLayoutPanel2.TabIndex = 2;
            // 
            // submit
            // 
            this.submit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.submit.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.submit.ForeColor = System.Drawing.Color.Black;
            this.submit.Location = new System.Drawing.Point(238, 3);
            this.submit.Name = "submit";
            this.submit.Size = new System.Drawing.Size(90, 36);
            this.submit.TabIndex = 0;
            this.submit.Text = "Submit";
            this.submit.UseVisualStyleBackColor = true;
            // 
            // cancel
            // 
            this.cancel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cancel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancel.ForeColor = System.Drawing.Color.Black;
            this.cancel.Location = new System.Drawing.Point(78, 3);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(90, 36);
            this.cancel.TabIndex = 1;
            this.cancel.Text = "Cancel";
            this.cancel.UseVisualStyleBackColor = true;
            // 
            // content
            // 
            this.content.Dock = System.Windows.Forms.DockStyle.Fill;
            this.content.HorizontalScrollbarBarColor = true;
            this.content.HorizontalScrollbarHighlightOnWheel = false;
            this.content.HorizontalScrollbarSize = 10;
            this.content.Location = new System.Drawing.Point(3, 67);
            this.content.Name = "content";
            this.content.Size = new System.Drawing.Size(406, 382);
            this.content.TabIndex = 2;
            this.content.VerticalScrollbarBarColor = true;
            this.content.VerticalScrollbarHighlightOnWheel = false;
            this.content.VerticalScrollbarSize = 10;
            // 
            // AutoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.metroPanel1);
            this.Name = "AutoForm";
            this.Size = new System.Drawing.Size(412, 500);
            this.metroPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.metroTile2.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroPanel metroPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private MetroFramework.Controls.MetroTile titleLabel;
        private MetroFramework.Controls.MetroTile metroTile2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private MetroFramework.Controls.MetroPanel content;
        public System.Windows.Forms.Button cancel;
        public System.Windows.Forms.Button submit;
    }
}
