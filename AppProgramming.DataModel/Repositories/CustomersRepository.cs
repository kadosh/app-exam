using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppProgramming.DataModel.Models;
using System.Data.SqlClient;

namespace AppProgramming.DataModel.Repositories
{
    public class CustomersRepository : AbstractRepository, IRepository<Customer>
    {
        public CustomersRepository()
            : base()
        {
            this.connection.Open();
        }

        public Customer GetById(int id)
        {
            SqlCommand command = new SqlCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.Connection = this.connection;
            command.CommandText =
                "SELECT TOP 1 " +
                "Customers.FirstName, Customers.LastName, Customers.MothersName, Customers.CityID, Cities.Name, " +
                "Customers.RFC, Customers.BirthDate, Customers.Gender, Customers.Email, Customers.PhoneNumber, " +
                "Customers.Address1, Customers.Address2, Customers.CellNumber, Customers.BloodTypeID, BloodTypes.Title,  " +
                "Customers.Smoke, Customers.Drink, Customers.PracticeSports " +
                "FROM Customers " +
                "JOIN Cities ON Customers.CityID = Cities.CityID " +
                "JOIN BloodTypes ON BloodTypes.BloodTypeID = Customers.BloodTypeID " +
                "FROM Customers " +
                "WHERE Customers.CustomerID = @CustomerID";

            command.Parameters.AddWithValue("@CustomerID", id);

            var result = command.ExecuteReader(System.Data.CommandBehavior.SingleRow);

            Customer customer = new Customer
            {
                FirstName = result.GetString(0),
                LastName = result.GetString(1),
                MothersName = result.GetString(2),
                CityID = result.GetInt32(3),
                CityName = result.GetString(4),
                RFC = result.GetString(5),
                BirthDate = result.GetDateTime(6),
                Gender = result.GetString(7),
                Email = result.GetString(8),
                PhoneNumber = result.GetString(9),
                Address1 = result.GetString(10),
                Address2 = result.GetString(11),
                CellNumber = result.GetString(12),
                BloodTypeID = result.GetInt32(13),
                BloodTypeTitle = result.GetString(14),
                Smoke = result.GetInt32(15),
                Drink = result.GetInt32(16),
                PracticeSports = result.GetInt32(17)
            };

            return customer;
        }

        public IEnumerable<Customer> Query(Dictionary<string, string> queryItems, bool approachMode = false)
        {
            SqlCommand command = new SqlCommand();
            command.Connection = this.connection;
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText =
                "SELECT " +
                "Customers.FirstName, Customers.LastName, Customers.MothersName, Customers.CityID, Cities.Name, " +
                "Customers.RFC, Customers.BirthDate, Customers.Gender, Customers.Email, Customers.PhoneNumber, " +
                "Customers.Address1, Customers.Address2, Customers.CellNumber, Customers.BloodTypeID, BloodTypes.Title,  " +
                "Customers.Smoke, Customers.Drink, Customers.PracticeSports, Customers.CustomerID, Customers.FullName, " +
                "States.StateID, States.Name " +
                "FROM Customers " +
                "JOIN Cities ON Customers.CityID = Cities.CityID " +
                "JOIN States ON Cities.StateID = States.StateID " +
                "JOIN BloodTypes ON BloodTypes.BloodTypeID = Customers.BloodTypeID " +
                "WHERE ";

            BuildQuery(queryItems, command, true);

            IList<Customer> items = new List<Customer>();

            var dataReader = command.ExecuteReader();

            while (dataReader.Read())
            {
                Customer customer = new Customer
                {
                    FirstName = dataReader.GetString(0),
                    LastName = dataReader.GetString(1),
                    MothersName = dataReader.GetString(2),
                    CityID = dataReader.GetInt32(3),
                    CityName = dataReader.GetString(4),
                    RFC = dataReader.GetString(5),
                    BirthDate = dataReader.GetDateTime(6),
                    Gender = dataReader.GetString(7),
                    Email = dataReader.GetString(8),
                    PhoneNumber = dataReader.GetString(9),
                    Address1 = dataReader.GetString(10),
                    Address2 = dataReader.GetString(11),
                    CellNumber = dataReader.GetString(12),
                    BloodTypeID = dataReader.GetInt32(13),
                    BloodTypeTitle = dataReader.GetString(14),
                    Smoke = dataReader.GetInt32(15),
                    Drink = dataReader.GetInt32(16),
                    PracticeSports = dataReader.GetInt32(17),
                    CustomerID = dataReader.GetInt32(18),
                    FullName = dataReader.GetString(19),
                    StateID = dataReader.GetInt32(20),
                    StateName = dataReader.GetString(21)
                };

                items.Add(customer);
            }

            return items;
        }

        private static void BuildQuery(Dictionary<string, string> queryItems, SqlCommand command, bool approachMode = false)
        {
            string whereClause = string.Empty;
            IList<string> whereClauses = new List<string>();

            foreach (var item in queryItems)
            {
                if (approachMode && !item.Key.Contains("ID"))
                {
                    whereClauses.Add(string.Format(@"{0} LIKE '%{1}%'", item.Key, item.Value));
                }
                else
                {
                    whereClauses.Add(string.Format("{0} = @{0}", item.Key));
                    command.Parameters.AddWithValue(string.Format("@{0}", item.Key), item.Value);
                }
            }

            whereClause = string.Join(" AND ", whereClauses.ToArray());

            command.CommandText += whereClause;
        }

        public bool Add(Customer entity)
        {
            SqlCommand command = new SqlCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.Connection = this.connection;
            command.CommandText =
                "INSERT INTO [dbo].[Customers]" +
                "([FirstName] " +
                ",[LastName]" +
                ",[MothersName]" +
                ",[CityID]" +
                ",[RFC]" +
                ",[BirthDate]" +
                ",[Gender]" +
                ",[Email]" +
                ",[PhoneNumber]" +
                ",[Address1]" +
                ",[Address2]" +
                ",[CellNumber]" +
                ",[BloodTypeID]" +
                ",[Smoke]" +
                ",[Drink]" +
                ",[PracticeSports])" +
            "VALUES" +
               "(@FirstName" +
               ",@LastName" +
               ",@MothersName" +
               ",@CityID" +
               ",@RFC" +
               ",@BirthDate" +
               ",@Gender" +
               ",@Email" +
               ",@PhoneNumber" +
               ",@Address1" +
               ",@Address2" +
               ",@CellNumber" +
               ",@BloodTypeID" +
               ",@Smoke" +
               ",@Drink" +
               ",@PracticeSports)";

            command.Parameters.Clear();
            command.Parameters.AddWithValue("@FirstName", entity.FirstName);
            command.Parameters.AddWithValue("@LastName", entity.LastName);
            command.Parameters.AddWithValue("@MothersName", entity.MothersName);
            command.Parameters.AddWithValue("@CityID", entity.CityID);
            command.Parameters.AddWithValue("@RFC", entity.RFC);
            command.Parameters.AddWithValue("@BirthDate", entity.BirthDate);
            command.Parameters.AddWithValue("@Gender", entity.Gender);
            command.Parameters.AddWithValue("@Email", entity.Email);
            command.Parameters.AddWithValue("@PhoneNumber", entity.PhoneNumber);
            command.Parameters.AddWithValue("@Address1", entity.Address1);
            command.Parameters.AddWithValue("@Address2", entity.Address2);
            command.Parameters.AddWithValue("@CellNumber", entity.CellNumber);
            command.Parameters.AddWithValue("@BloodTypeID", entity.BloodTypeID);
            command.Parameters.AddWithValue("@Smoke", entity.Smoke);
            command.Parameters.AddWithValue("@Drink", entity.Drink);
            command.Parameters.AddWithValue("@PracticeSports", entity.PracticeSports);

            return command.ExecuteNonQuery() > 0;
        }

        public bool Update(Customer entity)
        {
            SqlCommand command = new SqlCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.Connection = this.connection;
            command.CommandText =
               "UPDATE [dbo].[Customers] " +
               "SET " +
               "FirstName = @FirstName" +
               ", LastName = @LastName" +
               ", MothersName = @MothersName" +
               ", CityID = @CityID" +
               ", RFC = @RFC" +
               ", BirthDate = @BirthDate" +
               ", Gender = @Gender" +
               ", Email = @Email" +
               ", PhoneNumber = @PhoneNumber" +
               ", Address1 = @Address1" +
               ", Address2 = @Address2" +
               ", CellNumber = @CellNumber" +
               ", BloodTypeID = @BloodTypeID" +
               ", Smoke = @Smoke" +
               ", Drink = @Drink" +
               ", PracticeSports = @PracticeSports" +
               " WHERE CustomerID = @CustomerID";

            command.Parameters.Clear();
            command.Parameters.AddWithValue("@FirstName", entity.FirstName);
            command.Parameters.AddWithValue("@LastName", entity.LastName);
            command.Parameters.AddWithValue("@MothersName", entity.MothersName);
            command.Parameters.AddWithValue("@CityID", entity.CityID);
            command.Parameters.AddWithValue("@RFC", entity.RFC);
            command.Parameters.AddWithValue("@BirthDate", entity.BirthDate);
            command.Parameters.AddWithValue("@Gender", entity.Gender);
            command.Parameters.AddWithValue("@Email", entity.Email);
            command.Parameters.AddWithValue("@PhoneNumber", entity.PhoneNumber);
            command.Parameters.AddWithValue("@Address1", entity.Address1);
            command.Parameters.AddWithValue("@Address2", entity.Address2);
            command.Parameters.AddWithValue("@CellNumber", entity.CellNumber);
            command.Parameters.AddWithValue("@BloodTypeID", entity.BloodTypeID);
            command.Parameters.AddWithValue("@Smoke", entity.Smoke);
            command.Parameters.AddWithValue("@Drink", entity.Drink);
            command.Parameters.AddWithValue("@PracticeSports", entity.PracticeSports);
            command.Parameters.AddWithValue("@CustomerID", entity.CustomerID);

            return command.ExecuteNonQuery() > 0;
        }

        public bool Delete(int id)
        {
            SqlCommand command = new SqlCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.Connection = this.connection;
            command.CommandText =
               "DELETE FROM [dbo].[Customers] " +
               " WHERE CustomerID = @CustomerID";

            command.Parameters.Clear();
            command.Parameters.AddWithValue("@CustomerID", id);

            return command.ExecuteNonQuery() > 0;
        }

        public bool Delete(Customer entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Customer> ListAll()
        {
            SqlCommand command = new SqlCommand();
            command.Connection = this.connection;
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText =
                "SELECT " +
                "Customers.FirstName, Customers.LastName, Customers.MothersName, Customers.CityID, Cities.Name, " +
                "Customers.RFC, Customers.BirthDate, Customers.Gender, Customers.Email, Customers.PhoneNumber, " +
                "Customers.Address1, Customers.Address2, Customers.CellNumber, Customers.BloodTypeID, BloodTypes.Title,  " +
                "Customers.Smoke, Customers.Drink, Customers.PracticeSports, Customers.CustomerID, Customers.FullName, " +
                "States.StateID, States.Name " +
                "FROM Customers " +
                "JOIN Cities ON Customers.CityID = Cities.CityID " +
                "JOIN States ON Cities.StateID = States.StateID " +
                "JOIN BloodTypes ON BloodTypes.BloodTypeID = Customers.BloodTypeID ";

            IList<Customer> items = new List<Customer>();

            var dataReader = command.ExecuteReader();

            while (dataReader.Read())
            {
                Customer customer = new Customer
                {
                    FirstName = dataReader.GetString(0),
                    LastName = dataReader.GetString(1),
                    MothersName = dataReader.GetString(2),
                    CityID = dataReader.GetInt32(3),
                    CityName = dataReader.GetString(4),
                    RFC = dataReader.GetString(5),
                    BirthDate = dataReader.GetDateTime(6),
                    Gender = dataReader.GetString(7),
                    Email = dataReader.GetString(8),
                    PhoneNumber = dataReader.GetString(9),
                    Address1 = dataReader.GetString(10),
                    Address2 = dataReader.GetString(11),
                    CellNumber = dataReader.GetString(12),
                    BloodTypeID = dataReader.GetInt32(13),
                    BloodTypeTitle = dataReader.GetString(14),
                    Smoke = dataReader.GetInt32(15),
                    Drink = dataReader.GetInt32(16),
                    PracticeSports = dataReader.GetInt32(17),
                    CustomerID = dataReader.GetInt32(18),
                    FullName = dataReader.GetString(19),
                    StateID = dataReader.GetInt32(20),
                    StateName = dataReader.GetString(21)
                };

                items.Add(customer);
            }

            return items;
        }


        public IEnumerable<Customer> Query(Dictionary<string, string> queryItems)
        {
            return this.Query(queryItems, false);
        }
    }
}
