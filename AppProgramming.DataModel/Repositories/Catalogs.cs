using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using AppProgramming.DataModel.Models;

namespace AppProgramming.DataModel.Repositories
{
    public static class Catalogs
    {
        public static IEnumerable<Role> GetRoles()
        {
            var connection = new SqlConnection("Server=K2H-LAPXPS; Database= InsuranceSystem; User Id=sa; Password=pass.word1");
            connection.Open();

            var command = new SqlCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = "SELECT RoleId, Name, FriendlyName FROM Roles";
            command.Connection = connection;

            var reader = command.ExecuteReader();

            IList<Role> result = new List<Role>();

            while (reader.Read())
            {
                result.Add(new Role
                {
                    RoleID = reader.GetInt32(0),
                    Name = reader.GetString(1),
                    FriendlyName = reader.GetString(2)
                });
            }

            connection.Close();
            return result;
        }

        public static IEnumerable<City> GetCities(int stateID)
        {
            var connection = new SqlConnection("Server=K2H-LAPXPS; Database= InsuranceSystem; User Id=sa; Password=pass.word1");
            connection.Open();

            var command = new SqlCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = "SELECT CityID, Name FROM Cities WHERE StateID = @StateID";
            command.Connection = connection;

            command.Parameters.AddWithValue("@StateID", stateID);

            var reader = command.ExecuteReader();

            IList<City> result = new List<City>();

            while (reader.Read())
            {
                result.Add(new City
                {
                    CityID = reader.GetInt32(0),
                    Name = reader.GetString(1)
                });
            }

            connection.Close();
            return result;
        }

        public static IEnumerable<string> GetYesNo()
        {
            IList<string> result = new List<string>();
            result.Add("Sí");
            result.Add("No");
            return result;
        }

        public static IEnumerable<string> GetGenres()
        {
            IList<string> result = new List<string>();
            result.Add("Masculino");
            result.Add("Femenino");
            return result;
        }

        public static IEnumerable<State> GetStates()
        {
            var connection = new SqlConnection("Server=K2H-LAPXPS; Database= InsuranceSystem; User Id=sa; Password=pass.word1");
            connection.Open();

            var command = new SqlCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = "SELECT StateID, Name FROM States";
            command.Connection = connection;

            var reader = command.ExecuteReader();

            IList<State> result = new List<State>();

            while (reader.Read())
            {
                result.Add(new State
                {
                    StateID = reader.GetInt32(0),
                    Name = reader.GetString(1)
                });
            }

            connection.Close();
            return result;
        }

        public static IEnumerable<PlanType> GetPlanTypes()
        {
            var connection = new SqlConnection("Server=K2H-LAPXPS; Database= InsuranceSystem; User Id=sa; Password=pass.word1");
            connection.Open();

            var command = new SqlCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = "SELECT PlanTypeID, Title FROM PlanTypes";
            command.Connection = connection;

            var reader = command.ExecuteReader();

            IList<PlanType> result = new List<PlanType>();

            while (reader.Read())
            {
                result.Add(new PlanType
                {
                    PlanTypeID = reader.GetInt32(0),
                    Title = reader.GetString(1)
                });
            }

            connection.Close();
            return result;
        }

        public static IEnumerable<PaymentType> GetPaymentTypes()
        {
            var connection = new SqlConnection("Server=K2H-LAPXPS; Database= InsuranceSystem; User Id=sa; Password=pass.word1");
            connection.Open();

            var command = new SqlCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = "SELECT PaymentTypeID, Title, DiscountPercentage FROM PaymentTypes";
            command.Connection = connection;

            var reader = command.ExecuteReader();

            IList<PaymentType> result = new List<PaymentType>();

            while (reader.Read())
            {
                result.Add(new PaymentType
                {
                    PaymentTypeID = reader.GetInt32(0),
                    Title = reader.GetString(1),
                    DiscountPercentage = reader.GetDouble(2)
                });
            }

            connection.Close();
            return result;
        }

        public static IEnumerable<BloodType> GetBloodTypes()
        {
            var connection = new SqlConnection("Server=K2H-LAPXPS; Database= InsuranceSystem; User Id=sa; Password=pass.word1");
            connection.Open();

            var command = new SqlCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = "SELECT BloodTypeID, Title FROM BloodTypes";
            command.Connection = connection;

            var reader = command.ExecuteReader();

            IList<BloodType> result = new List<BloodType>();

            while (reader.Read())
            {
                result.Add(new BloodType
                {
                    BloodTypeID = reader.GetInt32(0),
                    Title = reader.GetString(1)
                });
            }

            connection.Close();
            return result;
        }
    }
}
