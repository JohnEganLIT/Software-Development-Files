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

namespace PenaltyPoints {
    public partial class Frame : MetroForm {
        private Config config;

        public Frame() {
            config = new Config(@"config.json");
            config.Load();
            OnLoadConfig();

            InitializeComponent();

            ConfigTitle.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));

            var themes = MetroStyleManager.Styles.Themes.Keys;
            foreach (string theme in themes) {
                ConfigTheme.Items.Add(theme);
            }

            var styles = MetroStyleManager.Styles.Styles.Keys;
            foreach (var style in styles) {
                ConfigStyle.Items.Add(style);
            }
        }

        public bool OnLoadConfig() {
            if (!config.Load()) return false;
            if (config["Theme"] != "") MetroStyleManager.Default.Theme = config["Theme"];
            if (config["Style"] != "") MetroStyleManager.Default.Style = config["Style"];
            return true;
        }

        public bool OnSaveConfig() {
            return config.Save();
        }

        private void OnConfigThemeChanged(object sender, EventArgs e) {
            int key = (sender as MetroComboBox).SelectedIndex;
            var themes = MetroStyleManager.Styles.Themes.Keys;
            MetroStyleManager.Default.Theme = themes.ElementAt(key);
            config["Theme"] = themes.ElementAt(key);
        }

        private void OnConfigStyleChanged(object sender, EventArgs e) {
            int key = (sender as MetroComboBox).SelectedIndex;
            var styles = MetroStyleManager.Styles.Styles.Keys;
            MetroStyleManager.Default.Style = styles.ElementAt(key);
            config["Style"] = styles.ElementAt(key);
        }

        private void OnConfigResetClick(object sender, EventArgs e) {
            OnLoadConfig();
        }

        private void OnConfigSaveClick(object sender, EventArgs e) {
            OnSaveConfig();
        }
    }
}
