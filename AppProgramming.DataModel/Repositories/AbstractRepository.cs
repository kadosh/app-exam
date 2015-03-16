using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace AppProgramming.DataModel.Repositories
{
    public abstract class AbstractRepository : IDisposable
    {
        protected SqlConnection connection;

        public AbstractRepository()
        {
            this.connection = new SqlConnection("Server=K2H-LAPXPS; Database= InsuranceSystem; User Id=sa; Password=pass.word1");
        }

        public void Dispose()
        {
            this.connection.Close();
        }
    }
}
