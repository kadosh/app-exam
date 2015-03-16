using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Windows.Forms;
using AppProgramming.DataModel.Repositories;
using AppProgramming.MainForm.Formatters;

namespace AppProgramming.MainForm
{
    public partial class Customers : Form
    {
        public Customers()
        {
            InitializeComponent();
        }

        protected DataModel.Models.User CurrentUser;

        public void SetIdentity(DataModel.Models.User user)
        {
            this.CurrentUser = user;
        }

        public void ShowSelectionLegend()
        {
            lbSelectionLegend.Show();
        }

        public void HideSelectionLegend()
        {
            lbSelectionLegend.Hide();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

        }

        private void Customers_Load(object sender, EventArgs e)
        {
            this.customersDataGrid.CellFormatting += dataGridView_CellFormatting;

            using (var repository = new CustomersRepository())
            {
                this.customersDataGrid.DataSource = repository.ListAll().ToList();

                var columnsCasted =
                    this.customersDataGrid.Columns.Cast<DataGridViewColumn>();

                GridHelper.SetColumnHeader(columnsCasted, "CustomerID", "ID Cliente");
                GridHelper.SetColumnHeader(columnsCasted, "FirstName", "Nombre(s)");
                GridHelper.SetColumnHeader(columnsCasted, "LastName", "Apellido P.");
                GridHelper.SetColumnHeader(columnsCasted, "MothersName", "Apellido M.");
                GridHelper.SetColumnHeader(columnsCasted, "StateName", "Estado");
                GridHelper.SetColumnHeader(columnsCasted, "CityName", "Ciudad");
                GridHelper.SetColumnHeader(columnsCasted, "RFC", "RFC");
                GridHelper.SetColumnHeader(columnsCasted, "BirthDate", "Fecha de Nacimiento");
                GridHelper.SetColumnHeader(columnsCasted, "Gender", "Sexo");
                GridHelper.SetColumnHeader(columnsCasted, "Email", "Correo electrónico");
                GridHelper.SetColumnHeader(columnsCasted, "PhoneNumber", "Teléfono");
                GridHelper.SetColumnHeader(columnsCasted, "Address1", "Dirección");
                GridHelper.SetColumnHeader(columnsCasted, "Address2", "Colonia");
                GridHelper.SetColumnHeader(columnsCasted, "CellNumber", "Celular");
                GridHelper.SetColumnHeader(columnsCasted, "BloodTypeTitle", "Tipo de Sangre");
                GridHelper.SetColumnHeader(columnsCasted, "Smoke", "Fuma");
                GridHelper.SetColumnHeader(columnsCasted, "Drink", "Ingiere bebidas alcohólicas");
                GridHelper.SetColumnHeader(columnsCasted, "PracticeSports", "Practica algún deporte");
                GridHelper.SetColumnHeader(columnsCasted, "FullName", "Nombre completo");

                GridHelper.SetHiddenColumn(columnsCasted, "StateID");
                GridHelper.SetHiddenColumn(columnsCasted, "CityID");
                GridHelper.SetHiddenColumn(columnsCasted, "BloodTypeID");
            }
        }

        void dataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            var grid = (DataGridView)sender;
            switch (grid.Columns[e.ColumnIndex].Name)
            {
                case "Smoke":
                case "Drink":
                case "PracticeSports":
                    e.Value = (int)e.Value == 0 ? "No" : "Sí";
                    e.FormattingApplied = true;
                    break;
            }
        }

        private void ReloadDataSource()
        {
            using (var repository = new CustomersRepository())
            {
                this.customersDataGrid.DataSource = repository.ListAll().ToList();
            }
        }

        private void agregarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Customer customerForm = new Customer();
            var result = customerForm.ShowDialog();

            if (result == System.Windows.Forms.DialogResult.OK)
            {
                this.ReloadDataSource();
            }
        }

        private void editarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.customersDataGrid.SelectedRows.Count == 0)
            {
                MessageBox.Show("Por favor primero seleccione un registro de la tabla para poder editarlo.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            OpenCustomerEdit();
        }

        private void OpenCustomerEdit()
        {
            var selected = (DataModel.Models.Customer)this.customersDataGrid.SelectedRows[0].DataBoundItem;

            Customer customerForm = new Customer(FormActions.Edit, selected);
            var result = customerForm.ShowDialog();

            if (result == System.Windows.Forms.DialogResult.OK)
            {
                this.ReloadDataSource();
            }
        }

        private void customersDataGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            OpenCustomerEdit();
        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.customersDataGrid.SelectedRows.Count == 0)
            {
                MessageBox.Show("Por favor primero seleccione un registro de la tabla para poder eliminarlo.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var selected = (DataModel.Models.Customer)this.customersDataGrid.SelectedRows[0].DataBoundItem;

            var result = MessageBox.Show(string.Format("¿Está seguro que desea eliminar el registro del cliente con el ID: {0}", selected.CustomerID), "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                using (var repository = new CustomersRepository())
                {
                    repository.Delete(selected.CustomerID);
                    ReloadDataSource();
                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            var dictionary = new Dictionary<string, string>();

            if (schID.Text.Trim().Length > 0)
            {
                dictionary.Add("CustomerID", schID.Text);
            }

            if (schFirstName.Text.Trim().Length > 0)
            {
                dictionary.Add("FirstName", schFirstName.Text);
            }

            if (schLastName.Text.Trim().Length > 0)
            {
                dictionary.Add("LastName", schLastName.Text);
            }

            if (schMothersName.Text.Trim().Length > 0)
            {
                dictionary.Add("MothersName", schMothersName.Text);
            }

            if (schRFC.Text.Trim().Length > 0)
            {
                dictionary.Add("RFC", schRFC.Text);
            }

            if (dictionary.Count > 0)
            {
                using (var repository = new CustomersRepository())
                {
                    this.customersDataGrid.DataSource = repository.Query(dictionary, true).ToList();
                }
            }
            else
            {
                MessageBox.Show("Por favor escriba al menos un parámetro para realizar la búsqueda", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnClearSearch_Click(object sender, EventArgs e)
        {
            schID.Clear();
            schFirstName.Clear();
            schLastName.Clear();
            schMothersName.Clear();
            schRFC.Clear();

            this.ReloadDataSource();
        }

        private void btnGoBudget_Click(object sender, EventArgs e)
        {
            if (this.customersDataGrid.SelectedRows.Count == 0)
            {
                MessageBox.Show("Por favor primero seleccione un cliente de la tabla para poder realizar la cotización.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var selected = (DataModel.Models.Customer)this.customersDataGrid.SelectedRows[0].DataBoundItem;
            Budgets budgets = new Budgets(selected);
            budgets.SetIdentity(this.CurrentUser);
            this.Hide();

            var result = budgets.ShowDialog();
            if (result == System.Windows.Forms.DialogResult.OK)
            {
                this.Show();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Customer customerForm = new Customer();
            var result = customerForm.ShowDialog();

            if (result == System.Windows.Forms.DialogResult.OK)
            {
                this.ReloadDataSource();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (this.customersDataGrid.SelectedRows.Count == 0)
            {
                MessageBox.Show("Por favor primero seleccione un registro de la tabla para poder editarlo.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            OpenCustomerEdit();
        }
    }
}
