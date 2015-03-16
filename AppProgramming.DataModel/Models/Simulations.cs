using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AppProgramming.DataModel.Models
{
    public class Simulations
    {
        public int SimulationID { get; set; }

        public int CustomerID { get; set; }

        public int PaymentTypeID { get; set; }

        public int PlanTypeID { get; set; }

        public int FolioID { get; set; }

        public DateTime SimulationDateTime { get; set; }

        public int UserID { get; set; }

        public float ComputedDiscount { get; set; }

        public float ComputedSubTotal { get; set; }

        public float ComputedTotal { get; set; }
    }
}
