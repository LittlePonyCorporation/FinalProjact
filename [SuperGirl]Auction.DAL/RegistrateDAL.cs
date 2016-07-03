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
    public class RegistrateDAL : IRegistrateDAL
    {
        string connectionString = ConfigurationManager.ConnectionStrings["default"].ConnectionString;

        public bool ChangeRole(Guid LoginId, int roleId)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var changeRole = connection.CreateCommand();
                changeRole.CommandText = "UPDATE dbo.AuthorizationUsers SET RoleId=@RId WHERE LoginId=@LId";
                changeRole.Parameters.AddWithValue("@RId", roleId);
                changeRole.Parameters.AddWithValue("@LId", LoginId);
                connection.Open();
                var result = changeRole.ExecuteNonQuery();
                connection.Close();
                return (result != 0);
            }
        }

        public Guid Create(Registrate reg)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var createAuthentication = connection.CreateCommand();
                createAuthentication.CommandText = "INSERT INTO dbo.Authentication (LoginId, Login, Password) VALUES (@Id, @Log, @Pass)";
                createAuthentication.Parameters.AddWithValue("@Id", reg.ID);
                createAuthentication.Parameters.AddWithValue("@Log", reg.Login);
                createAuthentication.Parameters.AddWithValue("@Pass", reg.Password.GetHashCode());

                var createAuthorization = connection.CreateCommand();
                createAuthorization.CommandText = "INSERT INTO dbo.AuthorizationUsers (LoginId, RoleId) VALUES (@LogId, @RoleId)";
                createAuthorization.Parameters.AddWithValue("@LogId", reg.ID);
                createAuthorization.Parameters.AddWithValue("@RoleId", reg.RoleId);

                connection.Open();
                var result = createAuthentication.ExecuteNonQuery();
                var res = createAuthorization.ExecuteNonQuery();
                if (res == 0 || result == 0)
                {
                    return default(Guid);
                }
                return reg.ID;
            }
        }

        public bool Delete(Guid Id)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var deleteAuthorization = connection.CreateCommand();
                deleteAuthorization.CommandText = "DELETE FROM dbo.AuthorizationUsers WHERE LoginId=@LogId";
                deleteAuthorization.Parameters.AddWithValue("@LogId", Id);
                connection.Open();
                var res = deleteAuthorization.ExecuteNonQuery();
                connection.Close();
                if (res == 0)
                {
                    return false;
                }
                var deleteAuthentication = connection.CreateCommand();
                deleteAuthentication.CommandText = "DELETE FROM dbo.Authentication WHERE LoginId=@Id";
                deleteAuthentication.Parameters.AddWithValue("@Id", Id);
                connection.Open();
                var result = deleteAuthentication.ExecuteNonQuery();
                return (result != 0);
            }
        }

        public Guid GetLoginId(string log)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var getId = connection.CreateCommand();
                getId.CommandText = "SELECT LoginId FROM dbo.Authentication WHERE Login=@Log";
                getId.Parameters.AddWithValue("@Log", log);
                connection.Open();
                using (var reader = getId.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        return (Guid)reader["LoginId"];
                    }
                    return default(Guid);
                }
            }
        }

        public Guid GetLoginId(Guid uId)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var getId = connection.CreateCommand();
                getId.CommandText = "SELECT LoginId FROM dbo.Users WHERE Id=@uId";
                getId.Parameters.AddWithValue("@uId", uId);
                connection.Open();
                using (var reader = getId.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        return (Guid)reader["LoginId"];
                    }
                    return default(Guid);
                }
            }
        }

        public int GetPass(string login)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var getPass = connection.CreateCommand();
                getPass.CommandText = "SELECT Password FROM dbo.Authentication WHERE Login=@login";
                getPass.Parameters.AddWithValue("@login", login);
                connection.Open();
                using (var reader = getPass.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        return (int)reader["Password"];
                    }
                    return 0;
                }
            }
        }

        public int GetRole(Guid loginId)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var getRole = connection.CreateCommand();
                getRole.CommandText = "SELECT RoleId FROM dbo.AuthorizationUsers WHERE LoginId=@login";
                getRole.Parameters.AddWithValue("@login", loginId);
                connection.Open();
                using (var reader = getRole.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        return (int)reader["RoleId"];
                    }
                    return 0;
                }
            }
        }

        public string GetRoleName(int rol)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var getRole = connection.CreateCommand();
                getRole.CommandText = "SELECT Role FROM dbo.Role WHERE RoleId=@ID";
                getRole.Parameters.AddWithValue("@ID", rol);
                connection.Open();
                using (var reader = getRole.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        return (string)reader["Role"];
                    }
                    return null;
                }
            }
        }

        public Registrate GetUser(Guid loginId)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var getPass = connection.CreateCommand();
                getPass.CommandText = "SELECT Login, Password FROM dbo.Authentication WHERE LoginId=@login";
                getPass.Parameters.AddWithValue("@login", loginId);
                connection.Open();
                string login = default(string);
                int pass = 0;
                using (var reader = getPass.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        login = (string)reader["Login"];
                        pass = (int)reader["Password"];
                    }
                }
                connection.Close();
                var getRole = connection.CreateCommand();
                getRole.CommandText = "SELECT RoleId FROM dbo.AuthorizationUsers WHERE LoginId=@login";
                getRole.Parameters.AddWithValue("@login", loginId);
                connection.Open();
                int role = 0;
                using (var reader = getRole.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        role = (int)reader["RoleId"];
                    }
                }
                return new Registrate(loginId, login, pass, role);
            }
        }
    }
}
