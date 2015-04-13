using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using AppProgramming.DataModel.Repositories;

namespace AppProgramming.MainForm
{
    public partial class LoginForm : Form
    {
        private SuperMainForm mainForm;

        public LoginForm(SuperMainForm parent)
        {
            InitializeComponent();
            this.mainForm = parent;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            errorProvider.Clear();

            bool isValid = true;

            if (string.IsNullOrEmpty(txtUserName.Text))
            {
                errorProvider.SetError(txtUserName, "Por favor escriba un nombre de usuario");
                isValid = false;
            }

            if (string.IsNullOrEmpty(txtPassword.Text))
            {
                errorProvider.SetError(txtPassword, "Por favor escriba una contraseña de acceso");
                isValid = false;
            }

            if (!isValid)
            {
                return;
            }

            DataModel.Models.User authenticadedUser = null;

            using (var usersRepo = new UsersRepository())
            {
                authenticadedUser = usersRepo.FindUser(txtUserName.Text, txtPassword.Text);
            }

            if (authenticadedUser != null)
            //if(true)
            {
                this.mainForm.CurrentUser = authenticadedUser;
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Datos de acceso inválidos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            txtUserName.Focus();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnLoginExit_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("¿Seguro que desea salir?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            switch (result)
            {
                case DialogResult.Yes:
                    Application.Exit();
                    break;
            }
        }

        private void txtUserName_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtPassword.Focus();
            }
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnLogin.Focus();
            }
        }

        private void LoginForm_Load_1(object sender, EventArgs e)
        {
            txtUserName.Focus();
        }

        private void txtUserName_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtUserName.Text))
            {
                errorProvider.SetError(txtUserName, "Por favor escriba un nombre de usuario");
            }
            else
            {
                errorProvider.SetError(txtUserName, string.Empty);
            }
        }

        private void txtPassword_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtPassword.Text))
            {
                errorProvider.SetError(txtPassword, "Por favor escriba una contraseña de acceso");
            }
            else
            {
                errorProvider.SetError(txtPassword, string.Empty);
            }
        }
    }
}
