using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using AppProgramming.DataModel.Repositories;
using AppProgramming.DataModel.Models;

namespace AppProgramming.MainForm
{
    public partial class Budgets : Form
    {
        protected DataModel.Models.Customer CustomerEntity { get; set; }

        protected DataModel.Models.User CurrentUser;

        public void SetIdentity(DataModel.Models.User user)
        {
            this.CurrentUser = user;
        }

        public Budgets()
        {
            InitializeComponent();
        }

        public Budgets(DataModel.Models.Customer customerEntity)
            : this()
        {

            this.CustomerEntity = customerEntity;
        }

        private void Budgets_Load(object sender, EventArgs e)
        {
            cmbPayment.DataSource = Catalogs.GetPaymentTypes().ToList();
            cmbPayment.ValueMember = "PaymentTypeID";
            cmbPayment.DisplayMember = "Title";

            cmbPlan.DataSource = Catalogs.GetPlanTypes().ToList();
            cmbPlan.ValueMember = "PlanTypeID";
            cmbPlan.DisplayMember = "Title";

            cmbSex.DataSource = Catalogs.GetGenres();

            cmbCity.SelectedIndex = 0;
            cmbPayment.SelectedIndex = 0;
            cmbPlan.SelectedIndex = 0;
            cmbSex.SelectedIndex = 0;


            if (this.CustomerEntity != null)
            {
                this.cmbCity.DataSource = Catalogs.GetCities(this.CustomerEntity.StateID);
                this.cmbCity.DisplayMember = "Name";
                this.cmbCity.ValueMember = "CityID";

                txtCustomerID.Text = this.CustomerEntity.CustomerID.ToString();
                txtName.Text = this.CustomerEntity.FullName;

                var year = DateTime.Now.Year - this.CustomerEntity.BirthDate.Year;
                numericAge.Value = year;

                txtEmail.Text = this.CustomerEntity.Email;
                cmbCity.SelectedValue = this.CustomerEntity.CityID;
                cmbSex.SelectedItem = this.CustomerEntity.Gender == "F" ? "Femenino" : "Masculino";
            }
        }

        private double CalculateSubTotal()
        {
            int age;
            age = (int)numericAge.Value;

            string genre;
            genre = cmbSex.SelectedItem.ToString().Substring(0, 1);

            double price = 0;

            using (var planTypesRepo = new PlanTypesRepository())
            {
                price = planTypesRepo.GetApplicableRule(Convert.ToInt32(cmbPlan.SelectedValue), age, genre);
            }

            return price;
        }

        private double GetDiscount(double subTotal)
        {
            var paymentType = (PaymentType)cmbPayment.SelectedItem;

            return subTotal * (paymentType.DiscountPercentage / 100);
        }

        private void printDocumentBudget_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            // Some fonts
            Font fontArialTitle = new Font("Arial", 24, FontStyle.Bold);
            Font fontArialBig = new Font("Arial", 19, FontStyle.Bold);
            Font fontArialNormal = new Font("Arial", 12);
            Font fontArialNormalBold = new Font("Arial", 12, FontStyle.Bold);
            Font fontArialMini = new Font("Arial", 10);

            // Some pencils
            Pen thinAzure = new Pen(Color.Azure, 1);
            Pen boldBlack = new Pen(Color.Blue, 2);

            // Factory Info container
            float startFactoryInfoX = 20;
            float startFactoryInfoY = 50;

            // All information container
            e.Graphics.DrawRectangle(new Pen(Color.SteelBlue, 2), startFactoryInfoX - 10, startFactoryInfoY - 50, 760, 1000);

            e.Graphics.DrawString("Pekin Insurance ®", fontArialMini, Brushes.SteelBlue, startFactoryInfoX + 4, startFactoryInfoY + 174);
            e.Graphics.DrawString("Río Verde #471", fontArialMini, Brushes.SteelBlue, startFactoryInfoX + 4, startFactoryInfoY + 200);
            e.Graphics.DrawString("Tel: (01 33) 3634 2689", fontArialMini, Brushes.SteelBlue, startFactoryInfoX + 4, startFactoryInfoY + 225);
            e.Graphics.DrawString("www.pekinginsurance.com", fontArialMini, Brushes.SteelBlue, startFactoryInfoX + 4, startFactoryInfoY + 251);

            // Render the title, date and the description process leyend
            e.Graphics.DrawString("COTIZACIÓN", fontArialTitle, Brushes.SteelBlue, 280, 8);

            Folio folio = null;
            var date = DateTime.Now;

            using (var folioRepo = new FoliosRepository())
            {
                folio = folioRepo.GetNextFolio();
            }

            double subTotal = CalculateSubTotal();
            double discount = GetDiscount(subTotal);
            double total = subTotal - discount;

            using (var simulationsRepo = new SimulationsRepository())
            {
                simulationsRepo.Add(
                    CustomerEntity.CustomerID,
                    Convert.ToInt32(cmbPayment.SelectedValue),
                    Convert.ToInt32(cmbPlan.SelectedValue),
                    folio.FolioID,
                    date,
                    this.CurrentUser.UserID,
                    discount,
                    subTotal,
                    total
                );
            }

            e.Graphics.DrawString(string.Format("FOLIO {0}", folio.Number), fontArialNormal, Brushes.SteelBlue, 660, 10);
            e.Graphics.DrawString(date.ToString(), fontArialMini, Brushes.SteelBlue, 20, 10);

            // Get the image resource and resize it to 142 x 200
            var image = Resources.logo;
            e.Graphics.DrawImage(image, startFactoryInfoX + 6, startFactoryInfoY + 6, 195, 165);
            e.Graphics.DrawRectangle(new Pen(Color.Turquoise, 1), startFactoryInfoX + 2, startFactoryInfoY + 2, 200, 270);

            // Budget container
            float budgetContainerLabelsX = startFactoryInfoX + 220;
            float budgetContainerLabelsY = startFactoryInfoY;

            float budgetContainerInputsX = budgetContainerLabelsX + 100;
            float budgetContainerInputsY = budgetContainerLabelsY;

            //// Render the description process items
            e.Graphics.DrawString("Nombre", fontArialNormal, Brushes.SteelBlue, budgetContainerInputsX - 68, budgetContainerLabelsY + 4);
            e.Graphics.FillRectangle(Brushes.Azure, budgetContainerInputsX, budgetContainerInputsY, 420, 30);
            e.Graphics.DrawString(txtName.Text, fontArialNormal, Brushes.DimGray, budgetContainerInputsX + 2, budgetContainerInputsY + 4);

            e.Graphics.DrawString("Edad (años)", fontArialNormal, Brushes.SteelBlue, budgetContainerLabelsX, budgetContainerLabelsY + 40);
            e.Graphics.FillRectangle(Brushes.Azure, budgetContainerInputsX, budgetContainerInputsY + 35, 80, 30);
            e.Graphics.DrawString(string.Format("{0}", numericAge.Value), fontArialNormal, Brushes.DimGray, budgetContainerInputsX + 2, budgetContainerInputsY + 40);

            e.Graphics.DrawString("Sexo", fontArialNormal, Brushes.SteelBlue, budgetContainerLabelsX + 200, budgetContainerLabelsY + 40);
            e.Graphics.FillRectangle(Brushes.Azure, budgetContainerInputsX + 150, budgetContainerInputsY + 35, 270, 30);
            e.Graphics.DrawString(cmbSex.SelectedItem.ToString(), fontArialNormal, Brushes.DimGray, budgetContainerLabelsX + 200 + 50, budgetContainerInputsY + 40);

            e.Graphics.DrawString("Ciudad", fontArialNormal, Brushes.SteelBlue, budgetContainerInputsX - 60, budgetContainerLabelsY + 76);
            e.Graphics.FillRectangle(Brushes.Azure, budgetContainerInputsX, budgetContainerInputsY + 70, 420, 30);
            e.Graphics.DrawString(((City)cmbCity.SelectedItem).Name, fontArialNormal, Brushes.DimGray, budgetContainerInputsX + 2, budgetContainerInputsY + 76);

            e.Graphics.DrawString("Tipo de plan", fontArialNormal, Brushes.SteelBlue, budgetContainerLabelsX, budgetContainerLabelsY + 112);
            e.Graphics.FillRectangle(Brushes.Azure, budgetContainerInputsX, budgetContainerInputsY + 105, 420, 30);
            e.Graphics.DrawString(((PlanType)cmbPlan.SelectedItem).Title, fontArialNormal, Brushes.DimGray, budgetContainerInputsX + 2, budgetContainerInputsY + 112);

            e.Graphics.DrawString("Correo", fontArialNormal, Brushes.SteelBlue, budgetContainerInputsX - 60, budgetContainerLabelsY + 146);
            e.Graphics.FillRectangle(Brushes.Azure, budgetContainerInputsX, budgetContainerInputsY + 140, 420, 30);
            e.Graphics.DrawString(txtEmail.Text, fontArialNormal, Brushes.DimGray, budgetContainerInputsX + 2, budgetContainerInputsY + 146);

            e.Graphics.DrawString("Tipo de pago", fontArialNormal, Brushes.SteelBlue, budgetContainerLabelsX - 6, budgetContainerLabelsY + 182);
            e.Graphics.FillRectangle(Brushes.Azure, budgetContainerInputsX, budgetContainerInputsY + 175, 420, 30);
            e.Graphics.DrawString(((PaymentType)cmbPayment.SelectedItem).Title, fontArialNormal, Brushes.DimGray, budgetContainerInputsX + 2, budgetContainerInputsY + 182);

            e.Graphics.DrawString("Asesor", fontArialNormal, Brushes.SteelBlue, budgetContainerInputsX - 60, budgetContainerLabelsY + 218);
            e.Graphics.FillRectangle(Brushes.Azure, budgetContainerInputsX, budgetContainerInputsY + 210, 420, 30);
            e.Graphics.DrawString(string.Format("{0} {1} {2}", this.CurrentUser.FirstName, this.CurrentUser.LastName, this.CurrentUser.MothersName), fontArialNormal, Brushes.DimGray, budgetContainerInputsX + 2, budgetContainerInputsY + 218);

            float spaceForTotals = 30;

            e.Graphics.DrawString("Sub-Total", fontArialNormal, Brushes.SteelBlue, budgetContainerInputsX - 80, budgetContainerLabelsY + spaceForTotals + 254);
            e.Graphics.FillRectangle(Brushes.Azure, budgetContainerInputsX, budgetContainerInputsY + spaceForTotals + 245, 420, 30);
            e.Graphics.DrawString(string.Format("${0:0.00}", subTotal), fontArialNormal, Brushes.DimGray, budgetContainerInputsX + 2, budgetContainerInputsY + spaceForTotals + 254);

            e.Graphics.DrawString("Descuento", fontArialNormal, Brushes.SteelBlue, budgetContainerInputsX - 88, budgetContainerLabelsY + spaceForTotals + 290);
            e.Graphics.FillRectangle(Brushes.Azure, budgetContainerInputsX, budgetContainerInputsY + spaceForTotals + 280, 420, 30);
            e.Graphics.DrawString(string.Format("${0:0.00}", discount), fontArialNormal, Brushes.DimGray, budgetContainerInputsX + 2, budgetContainerInputsY + spaceForTotals + 290);

            e.Graphics.DrawString("Total", new Font("Arial", 13, FontStyle.Bold), Brushes.SteelBlue, budgetContainerInputsX - 60, budgetContainerLabelsY + spaceForTotals + 324);
            e.Graphics.FillRectangle(Brushes.Azure, budgetContainerInputsX, budgetContainerInputsY + spaceForTotals + 315, 420, 30);
            e.Graphics.DrawString(string.Format("${0:0.00}", total), fontArialNormalBold, Brushes.DimGray, budgetContainerInputsX + 2, budgetContainerInputsY + spaceForTotals + 326);

            Bitmap detailsImage = null;

            if (cmbPlan.SelectedIndex == 0)
            {
                detailsImage = Resources.normal_price;
            }
            else
            {
                detailsImage = Resources.plus_price;
            }

            e.Graphics.DrawImage(detailsImage, startFactoryInfoX, budgetContainerInputsY + spaceForTotals + 370, 750, 280);
        }

        private bool validateEmail()
        {
            return Regex.IsMatch(txtEmail.Text,
                @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$",
                RegexOptions.IgnoreCase);
        }

        private void btnExecute_Click(object sender, EventArgs e)
        {
            errorProvider.Clear();
            Control firstWithError = null;
            bool formIsValid = true;

            if (string.IsNullOrEmpty(txtName.Text) || txtName.Text.Length < 10)
            {
                errorProvider.SetError(txtName, "Por favor escriba un nombre de al menos 10 letras");
                formIsValid = false;
                firstWithError = txtName;
            }

            if (string.IsNullOrEmpty(txtEmail.Text))
            {
                errorProvider.SetError(txtEmail, "Por favor escriba el correo electrónico del cliente");
                formIsValid = false;
                if (null == firstWithError)
                {
                    firstWithError = txtEmail;
                }
            }
            else if (!validateEmail())
            {
                errorProvider.SetError(txtEmail, "Correo inválido");
                formIsValid = false;
                if (null == firstWithError)
                {
                    firstWithError = txtEmail;
                }
            }

            if (formIsValid)
            {
                printDocumentBudget.Print();
            }
            else
            {
                firstWithError.Focus();
            }
        }

        private void btnClean_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private void txtName_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtName.Text) || txtName.Text.Length < 10)
            {
                errorProvider.SetError(txtName, "Por favor escriba un nombre de al menos 10 letras");
            }
            else
            {
                errorProvider.SetError(txtName, string.Empty);
            }
        }

        private void txtEmail_Leave(object sender, EventArgs e)
        {
            bool hasError = false;

            if (string.IsNullOrEmpty(txtEmail.Text))
            {
                errorProvider.SetError(txtEmail, "Por favor escriba el correo electrónico del cliente");
                hasError = true;
            }
            else if (!validateEmail())
            {
                errorProvider.SetError(txtEmail, "Correo inválido");
                hasError = true;
            }

            if (!hasError)
            {
                errorProvider.SetError(txtEmail, string.Empty);
            }
        }

        private void txtName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            //if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            //{
            //    e.Handled = false;
            //}
        }
    }
}
