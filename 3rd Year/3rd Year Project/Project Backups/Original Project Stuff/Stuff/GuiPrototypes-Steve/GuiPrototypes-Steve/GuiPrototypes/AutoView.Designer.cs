namespace GuiPrototypes {
    partial class AutoView {
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
            } set {
                switch (value) {
                case "Light":
                    System.Drawing.Color Back = System.Drawing.Color.FromArgb(255,255,255);
                    System.Drawing.Color Fore = System.Drawing.Color.FromArgb( 16, 16, 16);
                    this.BackColor = this.content.BackColor = Back;
                    this.ForeColor = this.content.ForeColor = Fore;
                    this.content.LargeImageList = this.blackLarge;
                    this.content.SmallImageList = this.blackSmall;
                    break;
                case "Dark":
                    System.Drawing.Color DarkBack = System.Drawing.Color.FromArgb( 17, 17, 17);
                    System.Drawing.Color DarkFore = System.Drawing.Color.FromArgb(240,240,240);
                    this.BackColor = this.content.BackColor = DarkBack;
                    this.ForeColor = this.content.ForeColor = DarkFore;
                    this.content.LargeImageList = this.whiteLarge;
                    this.content.SmallImageList = this.whiteSmall;
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem(new string[] {
            "Test 1",
            "Test list item info"}, 0);
            System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem(new string[] {
            "Test 2",
            "Test list item info"}, 0);
            System.Windows.Forms.ListViewItem listViewItem3 = new System.Windows.Forms.ListViewItem(new string[] {
            "Test 3",
            "Test list item info"}, 0);
            System.Windows.Forms.ListViewItem listViewItem4 = new System.Windows.Forms.ListViewItem(new string[] {
            "Test 4",
            "Test list item info"}, 0);
            System.Windows.Forms.ListViewItem listViewItem5 = new System.Windows.Forms.ListViewItem(new string[] {
            "Test 5",
            "Test list item info"}, 0);
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AutoView));
            this.metroPanel1 = new MetroFramework.Controls.MetroPanel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.titleLabel = new MetroFramework.Controls.MetroTile();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.metroTile2 = new MetroFramework.Controls.MetroTile();
            this.content = new GuiPrototypes.MyListView();
            this.info = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.additional = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.blackLarge = new System.Windows.Forms.ImageList(this.components);
            this.blackSmall = new System.Windows.Forms.ImageList(this.components);
            this.whiteSmall = new System.Windows.Forms.ImageList(this.components);
            this.whiteLarge = new System.Windows.Forms.ImageList(this.components);
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.submit = new System.Windows.Forms.Button();
            this.cancel = new System.Windows.Forms.Button();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.metroPanel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.titleLabel.SuspendLayout();
            this.metroTile2.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
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
            this.metroPanel1.Size = new System.Drawing.Size(629, 500);
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
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 96F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(629, 500);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // titleLabel
            // 
            this.titleLabel.Controls.Add(this.comboBox1);
            this.titleLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.titleLabel.FontSize = MetroFramework.Drawing.MetroFontSize.Large;
            this.titleLabel.FontWeight = MetroFramework.Drawing.MetroFontWeight.Bold;
            this.titleLabel.Location = new System.Drawing.Point(3, 3);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(623, 58);
            this.titleLabel.TabIndex = 0;
            this.titleLabel.Text = "Title";
            this.titleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // comboBox1
            // 
            this.comboBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "List",
            "Details",
            "Small Icons",
            "Large Icons",
            "Tiles"});
            this.comboBox1.Location = new System.Drawing.Point(481, 15);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(128, 28);
            this.comboBox1.TabIndex = 1;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // metroTile2
            // 
            this.metroTile2.Controls.Add(this.tableLayoutPanel2);
            this.metroTile2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.metroTile2.Location = new System.Drawing.Point(3, 407);
            this.metroTile2.Name = "metroTile2";
            this.metroTile2.Size = new System.Drawing.Size(623, 90);
            this.metroTile2.TabIndex = 1;
            // 
            // content
            // 
            this.content.BackColor = System.Drawing.SystemColors.Window;
            this.content.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.info,
            this.additional});
            this.content.Dock = System.Windows.Forms.DockStyle.Fill;
            this.content.FullRowSelect = true;
            this.content.GridLines = true;
            listViewItem1.ToolTipText = "Test list item 1";
            listViewItem2.ToolTipText = "Test list item 2";
            listViewItem3.ToolTipText = "Test list item 3";
            listViewItem4.ToolTipText = "Test list item 4";
            listViewItem5.ToolTipText = "Test list item 5";
            this.content.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1,
            listViewItem2,
            listViewItem3,
            listViewItem4,
            listViewItem5});
            this.content.LargeImageList = this.blackLarge;
            this.content.Location = new System.Drawing.Point(3, 67);
            this.content.MultiSelect = false;
            this.content.Name = "content";
            this.content.ShowItemToolTips = true;
            this.content.Size = new System.Drawing.Size(623, 334);
            this.content.SmallImageList = this.blackSmall;
            this.content.TabIndex = 2;
            this.content.UseCompatibleStateImageBehavior = false;
            this.content.View = System.Windows.Forms.View.Tile;
            // 
            // info
            // 
            this.info.Text = "Title";
            this.info.Width = 64;
            // 
            // additional
            // 
            this.additional.Text = "Info";
            this.additional.Width = 149;
            // 
            // blackLarge
            // 
            this.blackLarge.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("blackLarge.ImageStream")));
            this.blackLarge.TransparentColor = System.Drawing.Color.Transparent;
            this.blackLarge.Images.SetKeyName(0, "file-black-128.png");
            this.blackLarge.Images.SetKeyName(1, "file-white-128.png");
            // 
            // blackSmall
            // 
            this.blackSmall.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("blackSmall.ImageStream")));
            this.blackSmall.TransparentColor = System.Drawing.Color.Transparent;
            this.blackSmall.Images.SetKeyName(0, "file-black-32.png");
            // 
            // whiteSmall
            // 
            this.whiteSmall.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("whiteSmall.ImageStream")));
            this.whiteSmall.TransparentColor = System.Drawing.Color.Transparent;
            this.whiteSmall.Images.SetKeyName(0, "file-white-32.png");
            // 
            // whiteLarge
            // 
            this.whiteLarge.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("whiteLarge.ImageStream")));
            this.whiteLarge.TransparentColor = System.Drawing.Color.Transparent;
            this.whiteLarge.Images.SetKeyName(0, "file-white-128.png");
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel3, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel4, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(623, 90);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel3.ColumnCount = 5;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 96F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 64F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 96F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.submit, 3, 0);
            this.tableLayoutPanel3.Controls.Add(this.cancel, 1, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 48);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(617, 39);
            this.tableLayoutPanel3.TabIndex = 3;
            // 
            // submit
            // 
            this.submit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.submit.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.submit.ForeColor = System.Drawing.Color.Black;
            this.submit.Location = new System.Drawing.Point(343, 3);
            this.submit.Name = "submit";
            this.submit.Size = new System.Drawing.Size(90, 33);
            this.submit.TabIndex = 0;
            this.submit.Text = "Submit";
            this.submit.UseVisualStyleBackColor = true;
            // 
            // cancel
            // 
            this.cancel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cancel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancel.ForeColor = System.Drawing.Color.Black;
            this.cancel.Location = new System.Drawing.Point(183, 3);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(90, 33);
            this.cancel.TabIndex = 1;
            this.cancel.Text = "Cancel";
            this.cancel.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 2;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 29.17342F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70.82658F));
            this.tableLayoutPanel4.Controls.Add(this.textBox1, 1, 0);
            this.tableLayoutPanel4.Controls.Add(this.metroLabel1, 0, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(617, 39);
            this.tableLayoutPanel4.TabIndex = 4;
            // 
            // textBox1
            // 
            this.textBox1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textBox1.Location = new System.Drawing.Point(183, 7);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(300, 25);
            this.textBox1.TabIndex = 0;
            // 
            // metroLabel1
            // 
            this.metroLabel1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(129, 10);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(48, 19);
            this.metroLabel1.TabIndex = 1;
            this.metroLabel1.Text = "Search";
            // 
            // AutoView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.metroPanel1);
            this.Name = "AutoView";
            this.Size = new System.Drawing.Size(629, 500);
            this.metroPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.titleLabel.ResumeLayout(false);
            this.metroTile2.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroPanel metroPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private MetroFramework.Controls.MetroTile titleLabel;
        private MetroFramework.Controls.MetroTile metroTile2;
        private System.Windows.Forms.ColumnHeader info;
        private System.Windows.Forms.ColumnHeader additional;
        private System.Windows.Forms.ImageList blackLarge;
        private System.Windows.Forms.ImageList blackSmall;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ImageList whiteSmall;
        private System.Windows.Forms.ImageList whiteLarge;
        private MyListView content;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        public System.Windows.Forms.Button submit;
        public System.Windows.Forms.Button cancel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.TextBox textBox1;
        private MetroFramework.Controls.MetroLabel metroLabel1;
    }
}
