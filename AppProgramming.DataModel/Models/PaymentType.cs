using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AppProgramming.DataModel.Models
{
    public class PaymentType
    {
        public int PaymentTypeID { get; set; }

        public string Title { get; set; }

        public double DiscountPercentage { get; set; }
    }
}
