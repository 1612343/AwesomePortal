﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AwesomePortal.Forms
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            loginUC1.OnLoginSuccess += LoginUC1_OnLoginSuccess;
        }

        private void LoginUC1_OnLoginSuccess(int errorCode)
        {
            if (errorCode == 0)
                ShowDKHP();
        }

        public void ShowDKHP()
        {
            dkhp_panel.BringToFront();
            dangKyHocPhanUC1.Show();
            dangKyHocPhanUC1.RenderEverything();
        }
    }
}
