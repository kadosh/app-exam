using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AppProgramming.DataModel.Repositories;

namespace AppProgramming.MainForm
{
    public partial class Users : Form
    {
        public Users()
        {
            InitializeComponent();
        }

        private void Users_Load(object sender, EventArgs e)
        {
            using (var repository = new UsersRepository())
            {
                this.usersDataGrid.DataSource = repository.ListAll().ToList();

                var columnsCasted =
                    this.usersDataGrid.Columns.Cast<DataGridViewColumn>();

                GridHelper.SetColumnHeader(columnsCasted, "UserID", "ID de Usuario");
                GridHelper.SetColumnHeader(columnsCasted, "FirstName", "Nombre(s)");
                GridHelper.SetColumnHeader(columnsCasted, "LastName", "Apellido P.");
                GridHelper.SetColumnHeader(columnsCasted, "MothersName", "Apellido M.");
                GridHelper.SetColumnHeader(columnsCasted, "UserName", "Nombre de Usuario");
                GridHelper.SetColumnHeader(columnsCasted, "RoleFriendlyName", "Rol");

                GridHelper.SetHiddenColumn(columnsCasted, "RoleID");
                GridHelper.SetHiddenColumn(columnsCasted, "Password");
                GridHelper.SetHiddenColumn(columnsCasted, "RoleName");
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            var dictionary = new Dictionary<string, string>();

            if (schID.Text.Trim().Length > 0)
            {
                dictionary.Add("UserID", schID.Text);
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

            if (schUserName.Text.Trim().Length > 0)
            {
                dictionary.Add("UserName", schUserName.Text);
            }

            if (schRole.Text.Trim().Length > 0)
            {
                dictionary.Add("Roles.FriendlyName", schRole.Text);
            }

            if (dictionary.Count > 0)
            {
                using (var repository = new UsersRepository())
                {
                    this.usersDataGrid.DataSource = repository.Query(dictionary, true).ToList();
                }
            }
            else
            {
                MessageBox.Show("Por favor escriba al menos un parámetro para realizar la búsqueda", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void agregarToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void ReloadDataSource()
        {
            using (var repository = new UsersRepository())
            {
                this.usersDataGrid.DataSource = repository.ListAll().ToList();
            }
        }

        private void editarToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void OpenUserEdit()
        {
            var selected = (DataModel.Models.User)this.usersDataGrid.SelectedRows[0].DataBoundItem;

            User userForm = new User(FormActions.Edit, selected);
            var result = userForm.ShowDialog();

            if (result == System.Windows.Forms.DialogResult.OK)
            {
                this.ReloadDataSource();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            User customerForm = new User();
            var result = customerForm.ShowDialog();

            if (result == System.Windows.Forms.DialogResult.OK)
            {
                this.ReloadDataSource();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (this.usersDataGrid.SelectedRows.Count == 0)
            {
                MessageBox.Show("Por favor primero seleccione un registro de la tabla para poder editarlo.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            OpenUserEdit();
        }

        private void usersDataGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (this.usersDataGrid.SelectedRows.Count == 0)
            {
                MessageBox.Show("Por favor primero seleccione un registro de la tabla para poder editarlo.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            OpenUserEdit();
        }
    }
}
