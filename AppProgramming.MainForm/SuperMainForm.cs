using AppProgramming.DataModel.Repositories;
using AppProgramming.MainForm.MyReports;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading;
using System.Windows.Forms;

namespace AppProgramming.MainForm
{
    public partial class SuperMainForm : Form
    {
        private static Reports _reportsForm;
        private static Users _usersForms;
        private static Customers _customersForm;
        private static Budgets _budgetsForm;

        public DataModel.Models.User CurrentUser { get; set; }

        public void InitializeUserSettings()
        {
            if (CurrentUser.RoleName != "admin")
            {
                usersMenuItem.Visible = false;
                reportsMenuItem.Visible = false;
            }
            else
            {
                usersMenuItem.Visible = true;
                reportsMenuItem.Visible = true;
            }

            toolStripStatusUserName.Text = string.Format("{0} {1} {2} ({3})", this.CurrentUser.LastName, this.CurrentUser.MothersName, this.CurrentUser.FirstName, this.CurrentUser.UserName);
        }

        private void closeAllDialogsExcept(Form form)
        {
            foreach (var item in this.forms)
            {
                if (item != null && item != form)
                {
                    item.Hide();
                }
            }
        }

        private void TryInitializeReports()
        {
            if (_reportsForm == null || _reportsForm.IsDisposed)
            {
                _reportsForm = new Reports();
                _reportsForm.MdiParent = this;
            }
        }

        private void TryInitializeUsers()
        {
            if (_usersForms == null || _usersForms.IsDisposed)
            {
                _usersForms = new Users();
                _usersForms.MdiParent = this;
            }
        }

        private void TryInitializeBudgets()
        {
            if (_budgetsForm == null || _budgetsForm.IsDisposed)
            {
                _budgetsForm = new Budgets();
                _budgetsForm.MdiParent = this;
            }
        }

        private void TryInitializeCustomers()
        {
            if (_customersForm == null || _customersForm.IsDisposed)
            {
                _customersForm = new Customers();
                _customersForm.SetIdentity(this.CurrentUser);
                _customersForm.MdiParent = this;
            }
        }

        private IList<Form> forms
        {
            get
            {
                return new List<Form>
                {
                    _reportsForm,
                    _budgetsForm,
                    _customersForm,
                    _usersForms
                };
            }
        }

        public SuperMainForm()
        {
            InitializeComponent();

            this.Hide();

            var loginForm = new LoginForm(this);
            var result = loginForm.ShowDialog();

            if (result == System.Windows.Forms.DialogResult.OK)
            {
                Thread newThread = new Thread(showSplash);
                newThread.Start();
#if DEBUG
                Thread.Sleep(5);
#else
                Thread.Sleep(5000);
#endif
                newThread.Abort();
            }
            else
            {
                Application.Exit();
            }

            this.InitializeUserSettings();

            TryInitializeReports();
            TryInitializeUsers();
            TryInitializeCustomers();
            TryInitializeBudgets();
        }

        private void showSplash()
        {
            Splash splash = new Splash();
            splash.ShowDialog();
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void reportesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TryInitializeReports();
            _reportsForm.Show();
            _reportsForm.BringToFront();
            closeAllDialogsExcept(_reportsForm);
        }

        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void cotizacionesToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void cotizacionesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            TryInitializeCustomers();
            _customersForm.Show();
            _customersForm.ShowSelectionLegend();
            _customersForm.BringToFront();
            closeAllDialogsExcept(_customersForm);
        }

        private void clientesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            TryInitializeCustomers();
            _customersForm.Show();
            _customersForm.HideSelectionLegend();
            _customersForm.BringToFront();
            closeAllDialogsExcept(_customersForm);
        }

        private void usuariosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            TryInitializeUsers();
            _usersForms.Show();
            _usersForms.BringToFront();
            closeAllDialogsExcept(_usersForms);
        }

        private void salirToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("¿Seguro que desea salir?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            switch (result)
            {
                case DialogResult.Yes:
                    Application.Exit();
                    break;
            }
        }

        private void reportesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            /*TryInitializeReports();
            _reportsForm.Show();
            _reportsForm.BringToFront();
            closeAllDialogsExcept(_reportsForm);*/
        }

        private void listadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void agregarUsuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TryInitializeUsers();
            _usersForms.Show();
            _usersForms.BringToFront();
            closeAllDialogsExcept(_usersForms);
        }

        private void listadoToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void cerrarSesiónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("¿Seguro que deseas cerrar sesión?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == System.Windows.Forms.DialogResult.Yes)
            {

                this.CurrentUser = null;

                foreach (var item in this.forms)
                {
                    item.Hide();
                }

                this.Hide();

                var loginForm = new LoginForm(this);
                var loginResult = loginForm.ShowDialog();

                if (loginResult == System.Windows.Forms.DialogResult.OK)
                {
                    this.InitializeUserSettings();
                    this.Show();
                    this.BringToFront();
                }
                else
                {
                    Application.Exit();
                }
            }
        }

        private void top10AsesoresConMásCotizacionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dsUsersReports dataSet = new dsUsersReports();

            DataSet ds = new DataSet();
            using (var repo = new ReportsRepository())
            {
                ds = repo.GetBestCommecialAssistants();
            }

            if (ds.Tables[0].Rows.Count == 0)
            {
                MessageBox.Show("No hay datos");
            }
            else
            {
                foreach (DataRow row in ds.Tables["Result"].Rows)
                {
                    dataSet.BestCommercialAssistants.Rows.Add(
                        string.Format(
                            "{0} {1} {2}",
                            row["FirstName"].ToString(),
                            row["LastName"].ToString(),
                            row["MothersName"].ToString()),
                        row["SimulationsCount"].ToString()
                        );
                }
            }

            BestCommercialAssistantsReport report = new BestCommercialAssistantsReport();
            report.SetDataSource((DataTable)dataSet.BestCommercialAssistants);

            ReportDialog dialog = new ReportDialog(report);
            dialog.ShowDialog();
        }

        private void tipoDePlanElegidoPorCiudadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dsUsersReports dataSet = new dsUsersReports();

            DataSet ds = new DataSet();

            using (var repo = new ReportsRepository())
            {
                ds = repo.GetComparePlanTypesByCity();
            }

            if (ds.Tables[0].Rows.Count == 0)
            {
                MessageBox.Show("No hay datos");
            }
            else
            {
                foreach (DataRow row in ds.Tables["Result"].Rows)
                {
                    double normalPlan = Convert.ToDouble(row["NormalPlan"]),
                            plusPlan = Convert.ToDouble(row["PlusPlan"]),
                            total = normalPlan + plusPlan;

                    double normalPlanAvg = total > 0 ? normalPlan * 100 / total : 0;
                    double plusPlanAvg = total > 0 ? plusPlan * 100 / total : 0;

                    dataSet.ComparePlanTypesByCity.Rows.Add(
                            row["CityName"].ToString(),
                            row["NormalPlan"].ToString(),
                            row["PlusPlan"].ToString(),
                            total.ToString(),
                            normalPlanAvg.ToString(),
                            plusPlanAvg.ToString()
                        );
                }
            }

            ComparePlanTypesByCityReport report = new ComparePlanTypesByCityReport();
            report.SetDataSource((DataTable)dataSet.ComparePlanTypesByCity);

            ReportDialog dialog = new ReportDialog(report);
            dialog.ShowDialog();
        }
    }
}
