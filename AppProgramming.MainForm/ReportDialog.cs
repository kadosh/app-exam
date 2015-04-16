using CrystalDecisions.CrystalReports.Engine;
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
    public partial class ReportDialog : Form
    {
        public ReportDialog(ReportClass report)
        {
            InitializeComponent();

            this.crystalReportViewer.ReportSource = report;
            this.crystalReportViewer.RefreshReport();
        }
    }
}
