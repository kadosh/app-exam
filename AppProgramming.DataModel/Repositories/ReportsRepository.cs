﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace AppProgramming.DataModel.Repositories
{
    public class ReportsRepository : AbstractRepository
    {
        public ReportsRepository()
            : base()
        {
            this.connection.Open();
        }

        public DataSet GetCustomersAnalysisByCity()
        {
            DataSet ds = new DataSet();

            SqlCommand command = new SqlCommand();
            command.Connection = this.connection;
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText =
                "SELECT " +
                    "Cities.Name AS CityName, " +
                    "SUM(IIF(Customers.Gender = 'F', 1, 0)) AS Femenine, " +
                    "SUM(IIF(Customers.Gender = 'M', 1, 0)) AS Masculine, " +
                    "SUM(Customers.Smoke) AS Smokes, " +
                    "SUM(Customers.Drink) AS Drinks, " +
                    "SUM(Customers.PracticeSports) AS PracticeSports, " +
                    "COUNT(*) AS TotalSimulations, " +
                    "(SELECT COUNT(*) FROM Simulations) AS GlobalTotalSimulations " +
                "FROM Simulations " +
                    "JOIN Customers ON Simulations.CustomerID = Customers.CustomerID " +
                    "JOIN Cities ON Customers.CityID = Cities.CityID " +
                "GROUP BY Cities.Name";

            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = command;
            adapter.Fill(ds, "Result");

            return ds;
        }

        public DataSet GetComparePlanTypesByCity()
        {
            DataSet ds = new DataSet();

            SqlCommand command = new SqlCommand();
            command.Connection = this.connection;
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText =
                "SELECT Cities.Name AS CityName, " +
                "(SELECT COUNT(*) FROM Simulations JOIN Customers ON Simulations.CustomerID = Customers.CustomerID WHERE Simulations.PlanTypeID = '1' AND Customers.CityID = Cities.CityID) AS [NormalPlan], " +
                "(SELECT COUNT(*) FROM Simulations JOIN Customers ON Simulations.CustomerID = Customers.CustomerID WHERE Simulations.PlanTypeID = '2' AND Customers.CityID = Cities.CityID) AS [PlusPlan] " +
                "FROM Cities";

            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = command;
            adapter.Fill(ds, "Result");

            return ds;
        }

        public DataSet GetBestCommecialAssistants()
        {
            DataSet ds = new DataSet();

            SqlCommand command = new SqlCommand();
            command.Connection = this.connection;
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText =
                "SELECT TOP 10 Users.FirstName, Users.LastName, Users.MothersName, COUNT(*) As SimulationsCount " +
                "FROM Simulations " +
                "JOIN Users ON Simulations.UserID = Users.UserID " +
                "GROUP BY Users.FirstName, Users.LastName, Users.MothersName " +
                "ORDER BY COUNT(*) DESC";

            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = command;
            adapter.Fill(ds, "Result");

            return ds;
        }
    }
}
