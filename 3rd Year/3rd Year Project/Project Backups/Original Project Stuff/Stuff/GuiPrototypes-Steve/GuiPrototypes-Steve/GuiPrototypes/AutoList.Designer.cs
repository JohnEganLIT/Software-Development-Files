namespace GuiPrototypes {
    partial class AutoList {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        #region Properties
        public string Title {
            get {
                return this.titleLabel.Text;
            }
            set {
                this.titleLabel.Text = value;
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
            this.vertical = new System.Windows.Forms.TableLayoutPanel();
            this.horizontal = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.titleLabel = new MetroFramework.Controls.MetroLabel();
            this.divider1 = new MetroFramework.Controls.MetroTile();
            this.divider2 = new MetroFramework.Controls.MetroTile();
            this.content = new GuiPrototypes.MyListView();
            this.submit = new System.Windows.Forms.Button();
            this.cancel = new System.Windows.Forms.Button();
            this.metroPanel1 = new MetroFramework.Controls.MetroPanel();
            this.vertical.SuspendLayout();
            this.horizontal.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.metroPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // vertical
            // 
            this.vertical.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.vertical.ColumnCount = 1;
            this.vertical.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.vertical.Controls.Add(this.horizontal, 0, 1);
            this.vertical.Dock = System.Windows.Forms.DockStyle.Fill;
            this.vertical.Location = new System.Drawing.Point(0, 0);
            this.vertical.Name = "vertical";
            this.vertical.RowCount = 3;
            this.vertical.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.vertical.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 540F));
            this.vertical.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.vertical.Size = new System.Drawing.Size(700, 570);
            this.vertical.TabIndex = 0;
            // 
            // horizontal
            // 
            this.horizontal.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.horizontal.ColumnCount = 3;
            this.horizontal.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.horizontal.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 512F));
            this.horizontal.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.horizontal.Controls.Add(this.tableLayoutPanel1, 1, 0);
            this.horizontal.Controls.Add(this.divider1, 0, 0);
            this.horizontal.Controls.Add(this.divider2, 2, 0);
            this.horizontal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.horizontal.Location = new System.Drawing.Point(3, 18);
            this.horizontal.Name = "horizontal";
            this.horizontal.RowCount = 1;
            this.horizontal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.horizontal.Size = new System.Drawing.Size(694, 534);
            this.horizontal.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.titleLabel, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.metroPanel1, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.content, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(94, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 64F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 64F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(506, 528);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // titleLabel
            // 
            this.titleLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.titleLabel.FontSize = MetroFramework.Drawing.MetroFontSize.Large;
            this.titleLabel.FontWeight = MetroFramework.Drawing.MetroFontWeight.Regular;
            this.titleLabel.Location = new System.Drawing.Point(3, 0);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(500, 64);
            this.titleLabel.TabIndex = 0;
            this.titleLabel.Text = "Title";
            this.titleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // divider1
            // 
            this.divider1.Dock = System.Windows.Forms.DockStyle.Right;
            this.divider1.FontSize = MetroFramework.Drawing.MetroFontSize.Large;
            this.divider1.FontWeight = MetroFramework.Drawing.MetroFontWeight.Bold;
            this.divider1.Location = new System.Drawing.Point(48, 3);
            this.divider1.Name = "divider1";
            this.divider1.Size = new System.Drawing.Size(40, 528);
            this.divider1.TabIndex = 1;
            this.divider1.Text = "<";
            this.divider1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // divider2
            // 
            this.divider2.Dock = System.Windows.Forms.DockStyle.Left;
            this.divider2.FontSize = MetroFramework.Drawing.MetroFontSize.Large;
            this.divider2.FontWeight = MetroFramework.Drawing.MetroFontWeight.Bold;
            this.divider2.Location = new System.Drawing.Point(606, 3);
            this.divider2.Name = "divider2";
            this.divider2.Size = new System.Drawing.Size(40, 528);
            this.divider2.TabIndex = 2;
            this.divider2.Text = ">";
            this.divider2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // content
            // 
            this.content.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.content.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.content.FullRowSelect = true;
            this.content.GridLines = true;
            this.content.Location = new System.Drawing.Point(55, 111);
            this.content.Name = "content";
            this.content.Size = new System.Drawing.Size(396, 305);
            this.content.TabIndex = 2;
            this.content.UseCompatibleStateImageBehavior = false;
            this.content.View = System.Windows.Forms.View.Details;
            // 
            // submit
            // 
            this.submit.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.submit.Location = new System.Drawing.Point(317, 14);
            this.submit.Name = "submit";
            this.submit.Size = new System.Drawing.Size(96, 32);
            this.submit.TabIndex = 2;
            this.submit.Text = "Submit";
            this.submit.UseVisualStyleBackColor = true;
            // 
            // cancel
            // 
            this.cancel.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancel.Location = new System.Drawing.Point(102, 14);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(96, 32);
            this.cancel.TabIndex = 3;
            this.cancel.Text = "Cancel";
            this.cancel.UseVisualStyleBackColor = true;
            // 
            // metroPanel1
            // 
            this.metroPanel1.Controls.Add(this.cancel);
            this.metroPanel1.Controls.Add(this.submit);
            this.metroPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.metroPanel1.HorizontalScrollbarBarColor = true;
            this.metroPanel1.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel1.HorizontalScrollbarSize = 10;
            this.metroPanel1.Location = new System.Drawing.Point(3, 467);
            this.metroPanel1.Name = "metroPanel1";
            this.metroPanel1.Size = new System.Drawing.Size(500, 58);
            this.metroPanel1.TabIndex = 1;
            this.metroPanel1.VerticalScrollbarBarColor = true;
            this.metroPanel1.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel1.VerticalScrollbarSize = 10;
            // 
            // AutoList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.vertical);
            this.Name = "AutoList";
            this.Size = new System.Drawing.Size(700, 570);
            this.BackColorChanged += new System.EventHandler(this.OnBackColorChanged);
            this.vertical.ResumeLayout(false);
            this.horizontal.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.metroPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel vertical;
        private System.Windows.Forms.TableLayoutPanel horizontal;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private MetroFramework.Controls.MetroLabel titleLabel;
        private MyListView content;
        private MetroFramework.Controls.MetroTile divider1;
        private MetroFramework.Controls.MetroTile divider2;
        private MetroFramework.Controls.MetroPanel metroPanel1;
        public System.Windows.Forms.Button cancel;
        public System.Windows.Forms.Button submit;
    }
}
