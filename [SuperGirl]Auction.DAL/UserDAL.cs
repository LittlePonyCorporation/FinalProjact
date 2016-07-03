using _SuperGirl_Auction.InterfacesDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _SuperGirl_Auction.Entites;
using System.Configuration;
using System.Data.SqlClient;

namespace _SuperGirl_Auction.DAL
{
    public class UserDAL : IUserDAL
    {
        public static List<User> ListOfUser = null;
        string connectionString;

        public UserDAL()
        {
            connectionString = ConfigurationManager.ConnectionStrings["default"].ConnectionString;
            ListOfUser = new List<User>();
        }

        public bool Change(Guid oldUserId, string newName, string newSurname, string newMail)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var changeUser = connection.CreateCommand();
                changeUser.CommandText = "UPDATE dbo.Users SET Name = @Name, Surname = @SName, Mail = @Mail WHERE Id = @Id";
                changeUser.Parameters.AddWithValue("@Id", oldUserId);
                changeUser.Parameters.AddWithValue("@SName", newSurname);
                changeUser.Parameters.AddWithValue("@Name", newName);
                changeUser.Parameters.AddWithValue("@Mail", newMail);
                connection.Open();
                var result = changeUser.ExecuteNonQuery();
                connection.Close();
                if (result == 0)
                {
                    return false;
                }
                return true;
            }
        }

        public Guid Create(User user, Guid loginId)
        {
            if (loginId == default(Guid))
            {
                return default(Guid);
            }
            using (var connection = new SqlConnection(connectionString))
            {
                var createUser = connection.CreateCommand();
                createUser.CommandText = "INSERT INTO dbo.Users (Id, Name, Surname, Mail, LoginId) VALUES (@Id, @Name, @SName, @Mail, @LoginId)";
                createUser.Parameters.AddWithValue("@Id", user.ID);
                createUser.Parameters.AddWithValue("@SName", user.Surname);
                createUser.Parameters.AddWithValue("@Name", user.Name);
                createUser.Parameters.AddWithValue("@Mail", user.Mail);
                createUser.Parameters.AddWithValue("@LoginId", loginId);
                connection.Open();
                var result = createUser.ExecuteNonQuery();
                connection.Close();
                if (result == 0)
                {
                    return default(Guid);
                }
                return user.ID;
            }
        }

        public bool Delete(Guid Id)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var deleteRelation = connection.CreateCommand();
                deleteRelation.CommandText = "DELETE FROM dbo.Relation WHERE idUser = @Id";
                deleteRelation.Parameters.AddWithValue("@Id", Id);
                connection.Open();
                var result = deleteRelation.ExecuteNonQuery();
                if (result == 0)
                {
                    return false;
                }
                var deleteUser = connection.CreateCommand();
                deleteUser.CommandText = "DELETE FROM dbo.Users WHERE Id = @ID";
                deleteUser.Parameters.AddWithValue("@ID", Id);
                var res = deleteUser.ExecuteNonQuery();
                return (res != 0);
            }
        }

        public User Get(Guid Id)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                User myUser = null;
                var command = connection.CreateCommand();
                command.CommandText = "SELECT Id, Surname, Name, Mail FROM dbo.Users WHERE Id = @ID";
                command.Parameters.AddWithValue("@ID", Id);
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        myUser = new User((Guid)reader["Id"], (string)reader["Name"], (string)reader["Surname"], (string)reader["Mail"]);
                    }
                    return myUser;
                }
            }
        }

        public IEnumerable<User> GetAll()
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandText = "SELECT Id, Name, Surname, Mail FROM dbo.Users";
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        ListOfUser.Add(new User((Guid)reader["Id"], (string)reader["Name"], (string)reader["Surname"], (string)reader["Mail"]));
                    }
                }
                foreach (var item in ListOfUser)
                {
                    yield return item;
                }
            }
        }

        public Guid GetUserId(Guid loginId)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandText = "SELECT Id FROM dbo.Users WHERE LoginId = @ID";
                command.Parameters.AddWithValue("@ID", loginId);
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        return (Guid)reader["Id"];
                    }
                    return default(Guid);
                }
            }
        }
    }
}
