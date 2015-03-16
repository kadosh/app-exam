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
using System.Text.RegularExpressions;

namespace AppProgramming.MainForm
{
    public partial class Customer : Form
    {
        protected FormActions currentAction = FormActions.Add;

        public DataModel.Models.Customer CustomerEntity { get; set; }

        public Customer(FormActions formAction, DataModel.Models.Customer entity)
            : this()
        {
            this.currentAction = formAction;
            this.CustomerEntity = entity;
        }

        public Customer()
        {
            InitializeComponent();
        }

        private bool ValidateForm()
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

            if (!txtRFC.MaskCompleted)
            {
                errorProvider.SetError(txtRFC, "Por favor escriba un RFC de 13 dígitos");
                result = false;
            }

            if (string.IsNullOrEmpty(txtAddress.Text) || txtAddress.Text.Length < 5)
            {
                errorProvider.SetError(txtAddress, "Por favor escriba un domicilio de al menos 5 letras");
                result = false;
            }

            if (string.IsNullOrEmpty(txtAddress2.Text) || txtAddress2.Text.Length < 5)
            {
                errorProvider.SetError(txtAddress2, "Por favor escriba una colonia de al menos 5 letras");
                result = false;
            }

            if (string.IsNullOrEmpty(txtEmail.Text))
            {
                errorProvider.SetError(txtEmail, "Por favor escriba el correo electrónico del cliente");
                result = false;
            }
            else if (!validateEmail())
            {
                errorProvider.SetError(txtEmail, "Correo inválido");
                result = false;
            }

            if (!txtPhoneNumber.MaskCompleted)
            {
                errorProvider.SetError(txtPhoneNumber, "Por favor número de teléfono de 10 dígitos");
                result = false;
            }

            if (!txtCellNumber.MaskCompleted)
            {
                errorProvider.SetError(txtCellNumber, "Por favor número de celular de 10 dígitos");
                result = false;
            }

            return result;
        }

        private bool validateEmail()
        {
            return Regex.IsMatch(txtEmail.Text,
                @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$",
                RegexOptions.IgnoreCase);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            errorProvider.Clear();

            if (!this.ValidateForm())
            {
                return;
            }

            var entity = new DataModel.Models.Customer
            {
                Address1 = txtAddress.Text,
                Address2 = txtAddress2.Text,
                BirthDate = dateBirthdate.Value.Date,
                BloodTypeID = Convert.ToInt32(cmbBloodType.SelectedValue),
                CellNumber = txtCellNumber.Text,
                CityID = Convert.ToInt32(cmbCity.SelectedValue),
                Drink = cmbDrink.SelectedValue.ToString() == "Sí" ? 1 : 0,
                Email = txtEmail.Text,
                FirstName = txtFirstName.Text,
                Gender = cmbGender.SelectedValue.ToString().Substring(0, 1),
                LastName = txtLastName.Text,
                MothersName = txtMothersName.Text,
                PhoneNumber = txtPhoneNumber.Text,
                PracticeSports = cmbPracticeSports.SelectedValue.ToString() == "Sí" ? 1 : 0,
                RFC = txtRFC.Text,
                Smoke = cmbSmoke.SelectedValue.ToString() == "Sí" ? 1 : 0,
            };

            using (var repository = new CustomersRepository())
            {
                if (this.currentAction == FormActions.Add)
                {
                    repository.Add(entity);
                }
                else
                {
                    entity.CustomerID = Convert.ToInt32(txtCustomerID.Text);
                    repository.Update(entity);
                }
            }

            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private void Customer_Load(object sender, EventArgs e)
        {
            if (this.currentAction == FormActions.Add)
            {
                this.txtCustomerID.Enabled = false;
            }

            this.cmbBloodType.DataSource = Catalogs.GetBloodTypes();
            this.cmbBloodType.DisplayMember = "Title";
            this.cmbBloodType.ValueMember = "BloodTypeID";

            this.cmbState.DataSource = Catalogs.GetStates();
            this.cmbState.DisplayMember = "Name";
            this.cmbState.ValueMember = "StateID";

            this.cmbSmoke.DataSource = Catalogs.GetYesNo();
            this.cmbDrink.DataSource = Catalogs.GetYesNo();
            this.cmbPracticeSports.DataSource = Catalogs.GetYesNo();
            this.cmbGender.DataSource = Catalogs.GetGenres();

            this.dateBirthdate.MinDate = DateTime.Now.AddYears(-29);
            this.dateBirthdate.MaxDate = DateTime.Now.AddYears(-20);
            this.dateBirthdate.Value = this.dateBirthdate.MinDate.AddYears(1);

            if (this.currentAction == FormActions.Edit)
            {
                txtCustomerID.Text = CustomerEntity.CustomerID.ToString();
                txtAddress.Text = CustomerEntity.Address1;
                txtAddress2.Text = CustomerEntity.Address2;
                dateBirthdate.Value = CustomerEntity.BirthDate;
                cmbBloodType.SelectedValue = CustomerEntity.BloodTypeID;
                txtCellNumber.Text = CustomerEntity.CellNumber;
                cmbCity.SelectedValue = CustomerEntity.CityID;
                cmbDrink.SelectedItem = CustomerEntity.Drink == 0 ? "No" : "Sí";
                txtEmail.Text = CustomerEntity.Email;
                txtFirstName.Text = CustomerEntity.FirstName;
                cmbGender.SelectedItem = CustomerEntity.Gender == "M" ? "Masculino" : "Femenino";
                txtLastName.Text = CustomerEntity.LastName;
                txtMothersName.Text = CustomerEntity.MothersName;
                txtPhoneNumber.Text = CustomerEntity.PhoneNumber;
                cmbPracticeSports.SelectedItem = CustomerEntity.PracticeSports == 1 ? "Sí" : "No";
                txtRFC.Text = CustomerEntity.RFC;
                cmbSmoke.SelectedItem = CustomerEntity.Smoke == 1 ? "Sí" : "No";
            }
        }

        private void cmbState_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.cmbState.Enabled = false;
            this.cmbCity.Enabled = false;

            this.cmbCity.DataSource = Catalogs.GetCities(((State)this.cmbState.SelectedValue).StateID);
            this.cmbCity.DisplayMember = "Name";
            this.cmbCity.ValueMember = "CityID";

            this.cmbState.Enabled = true;
            this.cmbCity.Enabled = true;
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

        private void txtEmail_Leave(object sender, EventArgs e)
        {
            Validations.ManualCalledValidations.ValidateEmail(this.txtEmail.Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnClean_Click(object sender, EventArgs e)
        {
            txtFirstName.Clear();
            txtLastName.Clear();
            txtMothersName.Clear();
            txtRFC.Clear();
            txtAddress.Clear();
            txtAddress2.Clear();
            txtEmail.Clear();
            txtPhoneNumber.Clear();
            txtCellNumber.Clear();
        }
    }
}
