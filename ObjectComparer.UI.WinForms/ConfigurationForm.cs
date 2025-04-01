using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SIT.Components.ObjectComparer.UI.WinForms {
    public partial class ConfigurationForm : Form {
        public ConfigurationForm() {
            InitializeComponent();
        }

        private Configuration _configuration;

        public ConfigurationForm(Configuration config) : this(){
            _configuration = config;
            bsConfiguration.DataSource = _configuration;
        }

    }
}
