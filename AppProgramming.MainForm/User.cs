using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AppProgramming.DataModel;
using AppProgramming.DataModel.Repositories;
using AppProgramming.DataModel.Models;

namespace AppProgramming.MainForm
{
    public partial class User : Form
    {
        protected FormActions currentAction = FormActions.Add;

        public DataModel.Models.User UserEntity { get; set; }

        public User(FormActions formAction, DataModel.Models.User entity)
            : this()
        {
            this.currentAction = formAction;
            this.UserEntity = entity;
        }

        public User()
        {
            InitializeComponent();
        }

        private bool ValidateFormOnAdd()
        {
            bool result = true;

            if (string.IsNullOrEmpty(txtFirstName.Text) || txtFirstName.Text.Length < 5)
            {
                errorProvider.SetError(txtFirstName, "Por favor escriba un nombre de al menos 5 letras");
                result = false;
            }

            if (string.IsNullOrEmpty(txtLastName.Text) || txtLastName.Text.Length < 5)
            {
                errorProvider.SetError(txtLastName, "Por favor escriba un apellido de al menos 5 letras");
                result = false;
            }

            if (string.IsNullOrEmpty(txtMothersName.Text) || txtMothersName.Text.Length < 5)
            {
                errorProvider.SetError(txtMothersName, "Por favor escriba un apellido de al menos 5 letras");
                result = false;
            }

            if (string.IsNullOrEmpty(txtUserName.Text) || txtUserName.Text.Length < 5)
            {
                errorProvider.SetError(txtUserName, "Por favor escriba un nombre de usuario de al menos 5 letras");
                result = false;
            }

            if (string.IsNullOrEmpty(txtPassword.Text) || txtPassword.Text.Length < 7)
            {
                errorProvider.SetError(txtPassword, "Por favor escriba una contraseña de al menos 7 letras");
                result = false;
            }
            else
            {
                if (txtPassword.Text != txtConfirmPassword.Text)
                {
                    errorProvider.SetError(txtConfirmPassword, "La confirmación no coincide con la contraseña.");
                    result = false;
                }
            }

            return result;
        }

        private bool validateFormOnEdit()
        {
            bool result = true;

            if (string.IsNullOrEmpty(txtFirstName.Text) || txtFirstName.Text.Length < 5)
            {
                errorProvider.SetError(txtFirstName, "Por favor escriba un nombre de al menos 5 letras");
                result = false;
            }

            if (string.IsNullOrEmpty(txtLastName.Text) || txtLastName.Text.Length < 5)
            {
                errorProvider.SetError(txtLastName, "Por favor escriba un apellido de al menos 5 letras");
                result = false;
            }

            if (string.IsNullOrEmpty(txtMothersName.Text) || txtMothersName.Text.Length < 5)
            {
                errorProvider.SetError(txtMothersName, "Por favor escriba un apellido de al menos 5 letras");
                result = false;
            }

            return result;
        }

        private bool ValidateForm()
        {
            if (this.currentAction == FormActions.Add)
            {
                return ValidateFormOnAdd();
            }
            else
            {
                return validateFormOnEdit();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            errorProvider.Clear();

            if (!this.ValidateForm())
            {
                return;
            }

            var entity = new DataModel.Models.User
            {
                FirstName = txtFirstName.Text,
                LastName = txtLastName.Text,
                MothersName = txtMothersName.Text,
                UserName = txtUserName.Text,
                Password = txtPassword.Text,
                RoleID = ((Role)cmbRole.SelectedItem).RoleID
            };

            using (var repository = new UsersRepository())
            {
                if (this.currentAction == FormActions.Add)
                {
                    if (txtPassword.Text != txtConfirmPassword.Text)
                    {
                        MessageBox.Show("Las contraseñas no coinciden. Favor de modificarlas.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }

                    repository.Add(entity);
                }
                else
                {
                    entity.UserID = Convert.ToInt32(txtUserID.Text);
                    repository.Update(entity);
                }
            }

            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private void User_Load(object sender, EventArgs e)
        {
            if (this.currentAction == FormActions.Add)
            {
                this.txtUserID.Enabled = false;
            }

            this.cmbRole.DataSource = Catalogs.GetRoles();
            this.cmbRole.DisplayMember = "FriendlyName";
            this.cmbRole.ValueMember = "RoleID";

            if (this.currentAction == FormActions.Edit)
            {
                txtUserID.Text = UserEntity.UserID.ToString();
                txtFirstName.Text = UserEntity.FirstName;
                cmbRole.SelectedValue = UserEntity.RoleID;
                txtLastName.Text = UserEntity.LastName;
                txtMothersName.Text = UserEntity.MothersName;
                txtUserName.Text = UserEntity.UserName;
                txtPassword.Text = "*************";
                txtConfirmPassword.Text = "*************";

                txtUserName.ReadOnly = true;
                txtPassword.ReadOnly = true;
                txtConfirmPassword.ReadOnly = true;
            }
        }

        private void txtFirstName_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validations.KeyPressValidations.FilterTextOnly(sender, e);
        }

        private void txtLastName_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validations.KeyPressValidations.FilterTextOnly(sender, e);
        }

        private void txtMothersName_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validations.KeyPressValidations.FilterTextOnly(sender, e);
        }

        private void txtUserName_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validations.KeyPressValidations.FilterUserName(sender, e);
        }

        private void btnClean_Click(object sender, EventArgs e)
        {
            txtUserName.Clear();
            txtFirstName.Clear();
            txtLastName.Clear();
            txtMothersName.Clear();
            txtPassword.Clear();
            txtConfirmPassword.Clear();
            errorProvider.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
