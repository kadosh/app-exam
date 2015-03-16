using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AppProgramming.MainForm.Validations
{
    public static class KeyPressValidations
    {
        public static void FilterTextOnly(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        public static void FilterUserName(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 65 || e.KeyChar > 122) && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }
    }
}
