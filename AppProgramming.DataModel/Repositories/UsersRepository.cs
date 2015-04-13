using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppProgramming.DataModel.Models;
using System.Data.SqlClient;

namespace AppProgramming.DataModel.Repositories
{
    public class UsersRepository : AbstractRepository, IRepository<User>
    {
        public UsersRepository()
            : base()
        {
            this.connection.Open();
        }

        public int GetRandomUserId()
        {
            SqlCommand command = new SqlCommand();
            command.Connection = this.connection;
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText =
                "SELECT top 1 percent UserID FROM Users " +
                "order by newid()";

            int result = Convert.ToInt32(command.ExecuteScalar());

            return result;
        }

        public User FindUser(string userName, string password)
        {
            SqlCommand command = new SqlCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.Connection = this.connection;
            command.CommandText =
                "SELECT " +
                "Users.FirstName, Users.LastName, Users.MothersName, " +
                "Users.UserName, Users.UserID, Roles.RoleID, Roles.Name AS RoleName, Roles.FriendlyName " +
                "FROM Users " +
                "JOIN Roles ON Users.RoleID = Roles.RoleID " +
                "WHERE UserName = @UserName AND Password = @Password";

            command.Parameters.AddWithValue("@UserName", userName);
            command.Parameters.AddWithValue("@Password", HashHelper.GetHash(password));

            var dataReader = command.ExecuteReader(System.Data.CommandBehavior.SingleRow);

            if (!dataReader.HasRows)
            {
                return null;
            }

            dataReader.Read();

            User user = new User
            {
                FirstName = dataReader.GetString(0),
                LastName = dataReader.GetString(1),
                MothersName = dataReader.GetString(2),
                UserName = dataReader.GetString(3),
                UserID = dataReader.GetInt32(4),
                RoleID = dataReader.GetInt32(5),
                RoleName = dataReader.GetString(6),
                RoleFriendlyName = dataReader.GetString(7)
            };

            return user;
        }

        public User GetById(int id)
        {
            SqlCommand command = new SqlCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.Connection = this.connection;
            command.CommandText =
                "SELECT " +
                "Users.FirstName, Users.LastName, Users.MothersName, " +
                "Users.UserName, Users.UserID, Roles.RoleID, Roles.Name AS RoleName, Roles.FriendlyName " +
                "FROM Users " +
                "JOIN Roles ON Users.RoleID = Roles.RoleID " +
                "WHERE UserID = @UserID";

            command.Parameters.AddWithValue("@UserID", id);

            var dataReader = command.ExecuteReader(System.Data.CommandBehavior.SingleRow);

            User user = new User
            {
                FirstName = dataReader.GetString(0),
                LastName = dataReader.GetString(1),
                MothersName = dataReader.GetString(2),
                UserName = dataReader.GetString(3),
                UserID = dataReader.GetInt32(4),
                RoleID = dataReader.GetInt32(5),
                RoleName = dataReader.GetString(6),
                RoleFriendlyName = dataReader.GetString(7)
            };

            return user;
        }

        public IEnumerable<User> Query(Dictionary<string, string> queryItems, bool approachMode = false)
        {
            SqlCommand command = new SqlCommand();
            command.Connection = this.connection;
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText =
                "SELECT " +
                "Users.FirstName, Users.LastName, Users.MothersName, " +
                "Users.UserName, Users.UserID, Roles.RoleID, Roles.Name AS RoleName, Roles.FriendlyName " +
                "FROM Users " +
                "JOIN Roles ON Users.RoleID = Roles.RoleID " +
                "WHERE ";

            BuildQuery(queryItems, command, true);

            IList<User> items = new List<User>();

            var dataReader = command.ExecuteReader();

            while (dataReader.Read())
            {
                User user = new User
                {
                    FirstName = dataReader.GetString(0),
                    LastName = dataReader.GetString(1),
                    MothersName = dataReader.GetString(2),
                    UserName = dataReader.GetString(3),
                    UserID = dataReader.GetInt32(4),
                    RoleID = dataReader.GetInt32(5),
                    RoleName = dataReader.GetString(6),
                    RoleFriendlyName = dataReader.GetString(7)
                };

                items.Add(user);
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

        public bool Add(User entity)
        {
            SqlCommand command = new SqlCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.Connection = this.connection;
            command.CommandText =
                "INSERT INTO [dbo].[Users]" +
                "([FirstName] " +
                ",[LastName]" +
                ",[MothersName]" +
                ",[UserName]" +
                ",[Password]" +
                ",[RoleID])" +
            "VALUES" +
               "(@FirstName" +
               ",@LastName" +
               ",@MothersName" +
               ",@UserName" +
               ",@Password" +
               ",@RoleID)";

            command.Parameters.Clear();
            command.Parameters.AddWithValue("@FirstName", entity.FirstName);
            command.Parameters.AddWithValue("@LastName", entity.LastName);
            command.Parameters.AddWithValue("@MothersName", entity.MothersName);
            command.Parameters.AddWithValue("@UserName", entity.UserName);
            command.Parameters.AddWithValue("@Password", HashHelper.GetHash(entity.Password));
            command.Parameters.AddWithValue("@RoleID", entity.RoleID);

            return command.ExecuteNonQuery() > 0;
        }

        public bool Update(User entity)
        {
            SqlCommand command = new SqlCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.Connection = this.connection;
            command.CommandText =
               "UPDATE [dbo].[Users] " +
               "SET " +
               "FirstName = @FirstName" +
               ", LastName = @LastName" +
               ", MothersName = @MothersName" +
               ", RoleID = @RoleID" +
               " WHERE UserID = @UserID";

            command.Parameters.Clear();
            command.Parameters.AddWithValue("@FirstName", entity.FirstName);
            command.Parameters.AddWithValue("@LastName", entity.LastName);
            command.Parameters.AddWithValue("@MothersName", entity.MothersName);
            command.Parameters.AddWithValue("@RoleID", entity.RoleID);
            command.Parameters.AddWithValue("@UserID", entity.UserID);

            return command.ExecuteNonQuery() > 0;
        }

        public bool Delete(int id)
        {
            SqlCommand command = new SqlCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.Connection = this.connection;
            command.CommandText =
               "DELETE FROM [dbo].[Users] " +
               " WHERE UserID = @UserID";

            command.Parameters.Clear();
            command.Parameters.AddWithValue("@UserID", id);

            return command.ExecuteNonQuery() > 0;
        }

        public bool Delete(User entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> ListAll()
        {
            SqlCommand command = new SqlCommand();
            command.Connection = this.connection;
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText =
                "SELECT " +
                "Users.FirstName, Users.LastName, Users.MothersName, " +
                "Users.UserName, Users.UserID, Roles.RoleID, Roles.Name AS RoleName, Roles.FriendlyName " +
                "FROM Users " +
                "JOIN Roles ON Users.RoleID = Roles.RoleID";

            IList<User> items = new List<User>();

            var dataReader = command.ExecuteReader();

            while (dataReader.Read())
            {
                User user = new User
                {
                    FirstName = dataReader.GetString(0),
                    LastName = dataReader.GetString(1),
                    MothersName = dataReader.GetString(2),
                    UserName = dataReader.GetString(3),
                    UserID = dataReader.GetInt32(4),
                    RoleID = dataReader.GetInt32(5),
                    RoleName = dataReader.GetString(6),
                    RoleFriendlyName = dataReader.GetString(7)
                };

                items.Add(user);
            }

            return items;
        }


        public IEnumerable<User> Query(Dictionary<string, string> queryItems)
        {
            return this.Query(queryItems, false);
        }
    }
}
