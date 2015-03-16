using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace AppProgramming.DataModel.Repositories
{
    public class SimulationsRepository : AbstractRepository
    {
        public SimulationsRepository()
            : base()
        {
            this.connection.Open();
        }

        public bool Add(int customerID, int paymentTypeID, int planTypeID, int folioID, DateTime dateTime, int userID, double discount, double subTotal, double total)
        {
            SqlCommand command = new SqlCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.Connection = this.connection;
            command.CommandText =
                "INSERT INTO [dbo].[Simulations]" +
                       "([CustomerID]" +
                       ",[PaymentTypeID]" +
                       ",[PlanTypeID]" +
                       ",[FolioID]" +
                       ",[SimulationDateTime]" +
                       ",[UserID]" +
                       ",[ComputedDiscount]" +
                       ",[ComputedSubTotal]" +
                       ",[ComputedTotal])" +
                 "VALUES" +
                       "(@CustomerID" +
                       ",@PaymentTypeID" +
                       ",@PlanTypeID" +
                       ",@FolioID" +
                       ",@SimulationDateTime" +
                       ",@UserID" +
                       ",@ComputedDiscount" +
                       ",@ComputedSubTotal" +
                       ",@ComputedTotal)";

            command.Parameters.Clear();
            command.Parameters.AddWithValue("@CustomerID", customerID);
            command.Parameters.AddWithValue("@PaymentTypeID", paymentTypeID);
            command.Parameters.AddWithValue("@PlanTypeID", planTypeID);
            command.Parameters.AddWithValue("@FolioID", folioID);
            command.Parameters.AddWithValue("@SimulationDateTime", dateTime);
            command.Parameters.AddWithValue("@UserID", userID);
            command.Parameters.AddWithValue("@ComputedDiscount", discount);
            command.Parameters.AddWithValue("@ComputedSubTotal", subTotal);
            command.Parameters.AddWithValue("@ComputedTotal", total);

            return command.ExecuteNonQuery() > 0;
        }
    }
}
