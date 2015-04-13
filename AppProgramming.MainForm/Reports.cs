using AppProgramming.MainForm.MyReports;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AppProgramming.MainForm
{
    public partial class Reports : Form
    {
        public Reports()
        {
            InitializeComponent();
        }

        private void Reports_Load(object sender, EventArgs e)
        {
            //this.WindowState = FormWindowState.Minimized;
            //this.WindowState = FormWindowState.Maximized;
            //this.crystalReportViewer1.

            CustomersReport report = new CustomersReport();

            report.SetDatabaseLogon("sa", "pass.word1", "K2H-LAPXPS", "InsuranceSystem");

            /*ConnectionInfo conn = new ConnectionInfo();
            conn.DatabaseName = "InsuranceSystem";
            conn.Password = "pass.word1";
            conn.ServerName = "K2H-LAPXPS";
            conn.UserID = "sa";

            

            TableLogOnInfo crTableLogoninfo = new TableLogOnInfo();

            foreach (CrystalDecisions.CrystalReports.Engine.Table CrTable in report.Database.Tables)
            {
                crTableLogoninfo = CrTable.LogOnInfo;
                crTableLogoninfo.ConnectionInfo = conn;
                CrTable.ApplyLogOnInfo(crTableLogoninfo);
            }
            foreach (ReportDocument subreport in report.Subreports)
            {
                foreach (CrystalDecisions.CrystalReports.Engine.Table CrTable in subreport.Database.Tables)
                {
                    crTableLogoninfo = CrTable.LogOnInfo;
                    crTableLogoninfo.ConnectionInfo = conn;
                    CrTable.ApplyLogOnInfo(crTableLogoninfo);
                }
            }*/

            this.crystalReportViewer1.ReportSource = report;
            
        }
    }
}
