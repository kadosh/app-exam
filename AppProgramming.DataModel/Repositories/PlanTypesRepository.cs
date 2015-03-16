using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppProgramming.DataModel.Models;
using System.Data.SqlClient;

namespace AppProgramming.DataModel.Repositories
{
    public class PlanTypesRepository : AbstractRepository
    {
        public PlanTypesRepository()
            : base()
        {
            this.connection.Open();
        }

        public double GetApplicableRule(int planTypeID, int age, string gender)
        {
            SqlCommand command = new SqlCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.Connection = this.connection;
            command.CommandText =
                "SELECT TOP 1 " +
                "Price " +
                "FROM PlanRules " +
                "WHERE PlanTypeID = @PlanTypeID AND @age >= FromAge AND @age <= ToAge AND Gender = @gender";

            command.Parameters.AddWithValue("@PlanTypeID", planTypeID);
            command.Parameters.AddWithValue("@age", age);
            command.Parameters.AddWithValue("@gender", gender);

            var result = Convert.ToDouble(command.ExecuteScalar());

            return result;
        }
    }
}
