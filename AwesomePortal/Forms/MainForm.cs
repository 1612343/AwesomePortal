﻿using AwesomePortal.Models;
using System;
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
            HideAllPanel();
            ShowLogin();
            
            
            loginUC1.OnLoginSuccess += LoginUC1_OnLoginSuccess;
            homeUC1.OnClickButtonNavigate += HomeUC1_OnClickButtonNavigate;
        }

        private void HomeUC1_OnClickButtonNavigate(string UCname)
        {
            switch (UCname)
            {
                case "dkhp":
                    ShowDKHP();
                    break;
                case "tkb":
                    ShowTKB();
                    break;
                case "kq":
                    //ShowKQ();
                    break;
                default:
                    break;
            }
        }

        private void LoginUC1_OnLoginSuccess(int errorCode)
        {
            if (errorCode == 0)
            {
                ShowHome();
            }
            else
                MessageBox.Show("Bạn nhập sai MSSV hoặc mật khẩu!");
        }

        public void HideAllPanel()
        {
            dkhp_panel.Hide();
            home_panel.Hide();
            login_panel.Hide();
            tkb_panel.Hide();
            navigator_panel.Hide();
        }
        public void ShowDKHP()
        {
            HideAllPanel();
            dkhp_panel.BringToFront();
            dkhp_panel.Show();
            navigator_panel.Show();
            dangKyHocPhanUC1.RenderEverything();
            dkhp_panel.Location = new Point(0, navigator_panel.Height + 10);
        }

        public void ShowHome()
        {
            HideAllPanel();
            home_panel.BringToFront();
            home_panel.Show();
            navigator_panel.Show();
            homeUC1.GetSinhVienDetail();
            home_panel.Location = new Point(0, navigator_panel.Height + 10);
        }

        public void ShowLogin()
        {
            HideAllPanel();
            login_panel.BringToFront();
            login_panel.Show();
            login_panel.Location = new Point(0, 0);
        }

        public void ShowTKB(List<HocPhan> data)
        {
            HideAllPanel();
            tkb_panel.BringToFront();
            tkb_panel.Show();
            thoiKhoaBieuUC1.SetData(data);
            thoiKhoaBieuUC1.RenderData();
            navigator_panel.Show();
            tkb_panel.Location = new Point(0, navigator_panel.Height + 10);
        }

        public void ShowTKB(List<DangKyHocPhan> data)
        {
            List<HocPhan> arr = new List<HocPhan>();
            foreach (var d in data)
            {
                arr.Add(d.hocPhan);
            }
            ShowTKB(arr);
        }

        public void ShowTKB() => ShowTKB(SinhVien.getInstance().dangKyHocPhan);

        private void btn_back_Click(object sender, EventArgs e)
        {
            ShowHome();
        }
    }
}
