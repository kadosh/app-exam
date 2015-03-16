using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AppProgramming.DataModel.Models
{
    public class PlanRule
    {
        public int PlanRuleID { get; set; }

        public int FromAge { get; set; }

        public int ToAge { get; set; }

        public string Gender { get; set; }

        public float Price { get; set; }

        public int PlanTypeID { get; set; }
    }
}
