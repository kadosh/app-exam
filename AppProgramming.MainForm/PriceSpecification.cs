using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AppProgramming.MainForm
{
    public class PriceSpecification
    {
        public string Genre { get; set; }
        public double NormalPrice { get; set; }
        public double PlusPrice { get; set; }
        public int FromAge { get; set; }
        public int ToAge { get; set; }
    }
}
