using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AppProgramming.MainForm
{
    public static class GridHelper
    {
        public static void SetColumnHeader(IEnumerable<DataGridViewColumn> columns, string name, string title)
        {
            var column = columns.Where(c => c.Name == name).First();
            column.HeaderText = title;
        }

        public static void SetHiddenColumn(IEnumerable<DataGridViewColumn> columns, string name)
        {
            var column = columns.Where(c => c.Name == name).First();
            column.Visible = false;
        }
    }
}
