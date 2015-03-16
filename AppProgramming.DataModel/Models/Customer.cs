using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AppProgramming.DataModel.Models
{
    public class Customer
    {
        public int CustomerID { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string MothersName { get; set; }

        public int CityID { get; set; }

        public string CityName { get; set; }

        public int StateID { get; set; }

        public string StateName { get; set; }

        public string RFC { get; set; }

        public DateTime BirthDate { get; set; }

        public string Gender { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string Address1 { get; set; }

        public string Address2 { get; set; }

        public string CellNumber { get; set; }

        public int BloodTypeID { get; set; }

        public string BloodTypeTitle { get; set; }

        public int Smoke { get; set; }

        public int Drink { get; set; }

        public int PracticeSports { get; set; }

        public string FullName { get; set; }

    }
}
