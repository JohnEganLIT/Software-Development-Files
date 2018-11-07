namespace GuiPrototypes {
    partial class AutoPage {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        #region Properties
        public string Title {
            get {
                return this.titleLabel.Text;
            } set {
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
            this.verticle = new System.Windows.Forms.TableLayoutPanel();
            this.horizontal = new System.Windows.Forms.TableLayoutPanel();
            this.center = new System.Windows.Forms.TableLayoutPanel();
            this.content = new MetroFramework.Controls.MetroPanel();
            this.actions = new MetroFramework.Controls.MetroPanel();
            this.cancel = new System.Windows.Forms.Button();
            this.submit = new System.Windows.Forms.Button();
            this.titleLabel = new MetroFramework.Controls.MetroLabel();
            this.divider1 = new MetroFramework.Controls.MetroTile();
            this.divider2 = new MetroFramework.Controls.MetroTile();
            this.verticle.SuspendLayout();
            this.horizontal.SuspendLayout();
            this.center.SuspendLayout();
            this.actions.SuspendLayout();
            this.SuspendLayout();
            // 
            // verticle
            // 
            this.verticle.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.verticle.ColumnCount = 1;
            this.verticle.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.verticle.Controls.Add(this.horizontal, 0, 1);
            this.verticle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.verticle.Location = new System.Drawing.Point(0, 0);
            this.verticle.Name = "verticle";
            this.verticle.RowCount = 3;
            this.verticle.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.verticle.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 535F));
            this.verticle.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.verticle.Size = new System.Drawing.Size(700, 570);
            this.verticle.TabIndex = 0;
            // 
            // horizontal
            // 
            this.horizontal.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.horizontal.ColumnCount = 3;
            this.horizontal.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.horizontal.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 512F));
            this.horizontal.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.horizontal.Controls.Add(this.center, 1, 0);
            this.horizontal.Controls.Add(this.divider1, 0, 0);
            this.horizontal.Controls.Add(this.divider2, 2, 0);
            this.horizontal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.horizontal.Location = new System.Drawing.Point(3, 20);
            this.horizontal.Name = "horizontal";
            this.horizontal.RowCount = 1;
            this.horizontal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.horizontal.Size = new System.Drawing.Size(694, 529);
            this.horizontal.TabIndex = 0;
            // 
            // center
            // 
            this.center.ColumnCount = 1;
            this.center.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.center.Controls.Add(this.content, 0, 1);
            this.center.Controls.Add(this.actions, 0, 2);
            this.center.Controls.Add(this.titleLabel, 0, 0);
            this.center.Dock = System.Windows.Forms.DockStyle.Fill;
            this.center.Location = new System.Drawing.Point(94, 3);
            this.center.Name = "center";
            this.center.RowCount = 3;
            this.center.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 64F));
            this.center.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.center.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 64F));
            this.center.Size = new System.Drawing.Size(506, 523);
            this.center.TabIndex = 0;
            // 
            // content
            // 
            this.content.Dock = System.Windows.Forms.DockStyle.Fill;
            this.content.HorizontalScrollbarBarColor = true;
            this.content.HorizontalScrollbarHighlightOnWheel = false;
            this.content.HorizontalScrollbarSize = 10;
            this.content.Location = new System.Drawing.Point(3, 67);
            this.content.Name = "content";
            this.content.Size = new System.Drawing.Size(500, 389);
            this.content.TabIndex = 0;
            this.content.VerticalScrollbarBarColor = true;
            this.content.VerticalScrollbarHighlightOnWheel = false;
            this.content.VerticalScrollbarSize = 10;
            // 
            // actions
            // 
            this.actions.Controls.Add(this.cancel);
            this.actions.Controls.Add(this.submit);
            this.actions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.actions.HorizontalScrollbarBarColor = true;
            this.actions.HorizontalScrollbarHighlightOnWheel = false;
            this.actions.HorizontalScrollbarSize = 10;
            this.actions.Location = new System.Drawing.Point(3, 462);
            this.actions.Name = "actions";
            this.actions.Size = new System.Drawing.Size(500, 58);
            this.actions.TabIndex = 1;
            this.actions.VerticalScrollbarBarColor = true;
            this.actions.VerticalScrollbarHighlightOnWheel = false;
            this.actions.VerticalScrollbarSize = 10;
            // 
            // cancel
            // 
            this.cancel.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancel.Location = new System.Drawing.Point(103, 12);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(96, 32);
            this.cancel.TabIndex = 3;
            this.cancel.Text = "Cancel";
            this.cancel.UseVisualStyleBackColor = true;
            // 
            // submit
            // 
            this.submit.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.submit.Location = new System.Drawing.Point(319, 12);
            this.submit.Name = "submit";
            this.submit.Size = new System.Drawing.Size(96, 32);
            this.submit.TabIndex = 2;
            this.submit.Text = "Submit";
            this.submit.UseVisualStyleBackColor = true;
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.titleLabel.FontSize = MetroFramework.Drawing.MetroFontSize.Large;
            this.titleLabel.FontWeight = MetroFramework.Drawing.MetroFontWeight.Regular;
            this.titleLabel.Location = new System.Drawing.Point(3, 0);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(500, 64);
            this.titleLabel.TabIndex = 2;
            this.titleLabel.Text = "Title";
            this.titleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // divider1
            // 
            this.divider1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.divider1.FontSize = MetroFramework.Drawing.MetroFontSize.Large;
            this.divider1.FontWeight = MetroFramework.Drawing.MetroFontWeight.Bold;
            this.divider1.Location = new System.Drawing.Point(3, 236);
            this.divider1.Name = "divider1";
            this.divider1.Size = new System.Drawing.Size(40, 56);
            this.divider1.TabIndex = 1;
            this.divider1.Text = "<";
            this.divider1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // divider2
            // 
            this.divider2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.divider2.FontSize = MetroFramework.Drawing.MetroFontSize.Large;
            this.divider2.FontWeight = MetroFramework.Drawing.MetroFontWeight.Bold;
            this.divider2.Location = new System.Drawing.Point(651, 232);
            this.divider2.Name = "divider2";
            this.divider2.Size = new System.Drawing.Size(40, 64);
            this.divider2.TabIndex = 2;
            this.divider2.Text = ">";
            this.divider2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // AutoPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.verticle);
            this.Name = "AutoPage";
            this.Size = new System.Drawing.Size(700, 570);
            this.BackColorChanged += new System.EventHandler(this.OnBackColorChanged);
            this.verticle.ResumeLayout(false);
            this.horizontal.ResumeLayout(false);
            this.center.ResumeLayout(false);
            this.center.PerformLayout();
            this.actions.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel verticle;
        private System.Windows.Forms.TableLayoutPanel horizontal;
        private System.Windows.Forms.TableLayoutPanel center;
        private MetroFramework.Controls.MetroPanel content;
        private MetroFramework.Controls.MetroPanel actions;
        public System.Windows.Forms.Button cancel;
        public System.Windows.Forms.Button submit;
        private MetroFramework.Controls.MetroLabel titleLabel;
        private MetroFramework.Controls.MetroTile divider1;
        private MetroFramework.Controls.MetroTile divider2;
    }
}
