using MetroFramework.Components;
using MetroFramework.Controls;
using MetroFramework.Forms;
using Security;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GuiPrototypes {
    public partial class Frame : MetroForm {
        public Config config;
        //public Test test;
        public SslClient client;

        public Frame() {
            //test = new Test();
            //test.Show();
            InitializeComponent();
            config = new Config(@"config.json");
            config.Load();
            OnLoadConfig();
        }

        public Frame(SslClient socket) {
            client = socket;
            //test = new Test();
            //test.Show();
            InitializeComponent();
            config = new Config(@"config.json");
            config.Load();
            OnLoadConfig();

        }

        private void Frame_Load(object sender, EventArgs e) {
            var themes = MetroStyleManager.Styles.Themes.Keys;
            foreach (string theme in themes) {
                themeConfig.Items.Add(theme);
            }

            var styles = MetroStyleManager.Styles.Styles.Keys;
            foreach (var style in styles) {
                if (style == "White" || style == "Black") continue;
                styleConfig.Items.Add(style);
            }
            this.dashboardForm.SetTheme(this, e);
            this.loginForm.SetTheme(this, e);
            this.ForgotPasswordForm.Hide();
            this.UserIDResetForm.Hide();
            this.dashboardForm.Hide();
            this.loginForm.Show();
        }

        public bool OnLoadConfig() {
            if (!config.Load()) return false;
            if (config["Theme"] != "") MetroStyleManager.Default.Theme = config["Theme"];
            if (config["Style"] != "") MetroStyleManager.Default.Style = config["Style"];
            //this.test.autoView1.Theme = config["Theme"];
            return true;
        }

        public bool OnSaveConfig() {
            return config.Save();
        }

        private void OnThemeConfigChanged(object sender, EventArgs e) {
            int key = (sender as MetroComboBox).SelectedIndex;
            var themes = MetroStyleManager.Styles.Themes.Keys;
            MetroStyleManager.Default.Theme = themes.ElementAt(key);
            config["Theme"] = themes.ElementAt(key);
            this.dashboardForm.SetTheme(this, e);
            this.loginForm.SetTheme(this, e);
            //this.test.autoView1.Theme = themes.ElementAt(key);
        }

        private void OnStyleConfigChanged(object sender, EventArgs e) {
            int key = (sender as MetroComboBox).SelectedIndex + 2;
            var styles = MetroStyleManager.Styles.Styles.Keys;
            MetroStyleManager.Default.Style = styles.ElementAt(key);
            config["Style"] = styles.ElementAt(key);
            this.dashboardForm.SetTheme(this, e);
            this.loginForm.SetTheme(this, e);
        }

        private void OnConfigResetClick(object sender, EventArgs e) {
            OnLoadConfig();
        }

        private void OnConfigSaveClick(object sender, EventArgs e) {
            OnSaveConfig();
        }

        private void dashboard_Load(object sender, EventArgs e) {

        }

        private void ForgotPassword_Load(object sender, EventArgs e) {
        }

        private void UserIdReset_Load(object sender, EventArgs e) {
        }
    }
}
