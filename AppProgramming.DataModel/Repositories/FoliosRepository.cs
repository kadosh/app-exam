using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using AppProgramming.DataModel.Models;

namespace AppProgramming.DataModel.Repositories
{
    public class FoliosRepository : AbstractRepository
    {
        public FoliosRepository()
            : base()
        {
            this.connection.Open();
        }

        public Folio GetNextFolio()
        {
            SqlCommand command = new SqlCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.Connection = this.connection;
            command.CommandText =
                "SELECT ISNULL(MAX(Number), 0) + 1 " +
                "FROM Folios";

            var result = Convert.ToInt32(command.ExecuteScalar());

            SqlCommand insertCommand = new SqlCommand();
            insertCommand.CommandType = System.Data.CommandType.Text;
            insertCommand.Connection = this.connection;
            insertCommand.CommandText =
                "INSERT INTO Folios (Number) VALUES (@Number)";

            insertCommand.Parameters.AddWithValue("@Number", result);

            insertCommand.ExecuteNonQuery();

            SqlCommand getCommand = new SqlCommand();
            getCommand.CommandType = System.Data.CommandType.Text;
            getCommand.Connection = this.connection;
            getCommand.CommandText =
                "SELECT TOP 1 FolioID, Number " +
                "FROM Folios WHERE Number = @Number";

            getCommand.Parameters.AddWithValue("@Number", result);

            var folioReader = getCommand.ExecuteReader(System.Data.CommandBehavior.SingleRow);

            folioReader.Read();

            return new Folio
            {
                FolioID = folioReader.GetInt32(0),
                Number = folioReader.GetInt32(1)
            };
        }

        public int GetNextFolioNumber()
        {
            SqlCommand command = new SqlCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.Connection = this.connection;
            command.CommandText =
                "SELECT ISNULL(MAX(Number), 0) + 1 " +
                "FROM Folios";

            var result = Convert.ToInt32(command.ExecuteScalar());

            return result;
        }
    }
}
