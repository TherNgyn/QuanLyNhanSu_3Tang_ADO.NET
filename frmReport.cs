﻿using Stimulsoft.Report.Components;
using Stimulsoft.Report;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Stimulsoft.Report.Viewer;
using QuanLyNhanSu_3Tang_ADO.BS_Layer;
using System.Data.SqlClient;
using System.Data.Common;

namespace QuanLyNhanSu_3Tang_ADO
{
    public partial class frmReport : Form
    {
        string MaNV;
        private Form parentForm = null; // Thêm biến lưu form cha

        public frmReport(string maNV)
        {
            InitializeComponent();
            MaNV = maNV;
        }

        
        public frmReport(string maNV, Form parent)
        {
            InitializeComponent();
            MaNV = maNV;
            parentForm = parent;
        }

        private void frmReport_Load(object sender, EventArgs e)
        {
            try
            {
                var report = new StiReport();
                string reportPath = Application.StartupPath + "\\Report\\ReportLuongTheoHopDong.mrt";
                report.Load(reportPath);
                /*DB_Layer.DBMain db = new DB_Layer.DBMain();
                string query = "SELECT * FROM vw_ThongTinHopDong";
                DataSet ds = db.ExecuteQueryDataSet(query, CommandType.Text);
                report.RegData("ThongTinHopDong", ds.Tables[0]);
                report.Dictionary.Synchronize();*/
                report.Render();
                stiRibbonViewerControl1.Report = report;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải báo cáo: " + ex.Message);
            }
        }

        private void frmReport_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (parentForm != null)
            {
                
                parentForm.Show();
            }
            else
            {
                
                frmMenuQuanTriVien frm = new frmMenuQuanTriVien(MaNV);
                frm.Show();
            }
        }
    }
}