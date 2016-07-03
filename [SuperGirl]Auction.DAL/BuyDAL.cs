using _SuperGirl_Auction.InterfacesDAL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _SuperGirl_Auction.Entites;
using System.Data.SqlClient;

namespace _SuperGirl_Auction.DAL
{
    public class BuyDAL : IBuyDAL
    {
        string connectionString = ConfigurationManager.ConnectionStrings["default"].ConnectionString;

        public bool AddInArchive(Buy buy)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var delete = connection.CreateCommand();
                delete.CommandText = "DELETE FROM dbo.Relation WHERE idLot=@LID";
                delete.Parameters.AddWithValue("@LID", buy.LogId);
                connection.Open();
                var result = delete.ExecuteNonQuery();
                if (result ==0)
                {
                    return false;
                }
                connection.Close();
                var add = connection.CreateCommand();
                add.CommandText = "INSERT INTO dbo.Archive (LotId, UserId) VALUES (@lid, @uid)";
                add.Parameters.AddWithValue("@lid", buy.LogId);
                add.Parameters.AddWithValue("@uid", buy.NewUserId);
                connection.Open();
                var res = add.ExecuteNonQuery();
                return (res != 0);
            }
        }

        public bool Change(Guid lotId, Guid newUserId)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var change = connection.CreateCommand();
                change.CommandText = "UPDATE dbo.Buy SET NewUserId=@NUId, Time=@Time WHERE LotId=@Id";
                change.Parameters.AddWithValue("@NUId", newUserId);
                change.Parameters.AddWithValue("@Time", DateTime.Now);
                change.Parameters.AddWithValue("@Id", lotId);
                connection.Open();
                var result = change.ExecuteNonQuery();
                connection.Close();
                return (result != 0);
            }
        }

        public bool Create(Buy buy)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var create = connection.CreateCommand();
                create.CommandText = "INSERT INTO dbo.Buy (LotId, NewUserId, Time) VALUES (@Lid, @NUid, @Time)";
                create.Parameters.AddWithValue("@Lid", buy.LogId);
                create.Parameters.AddWithValue("@NUid", buy.NewUserId);
                create.Parameters.AddWithValue("@Time", buy.BuyTime);
                connection.Open();
                var result = create.ExecuteNonQuery();
                return (result != 0);
            }
        }

        public bool Delete(Guid lotId)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var delete = connection.CreateCommand();
                delete.CommandText = "DELETE FROM dbo.Buy WHERE LotId=@LID";
                delete.Parameters.AddWithValue("@LID", lotId);
                connection.Open();
                var result = delete.ExecuteNonQuery();
                return (result != 0);
            }
        }

        public Buy Get(Guid LotId)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                Buy myBuy = null;
                var command = connection.CreateCommand();
                command.CommandText = "SELECT LotId, NewUserId, Time FROM dbo.Buy WHERE LotId = @ID";
                command.Parameters.AddWithValue("@ID", LotId);
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        myBuy = new Buy((Guid)reader["LotId"], (Guid)reader["NewUserId"], (DateTime)reader["Time"]);
                    }
                    return myBuy;
                }
            }
        }

        public Guid GetLotAr(Guid userId)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandText = "SELECT LotId FROM dbo.Archive WHERE UserId=@id";
                command.Parameters.AddWithValue("@id", userId);
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        return (Guid)reader["LotId"];
                    }
                    return default(Guid);
                }
            }
        }

        public Guid GetUserAr(Guid lotId)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandText = "SELECT UserId FROM dbo.Archive WHERE LotId=@id";
                command.Parameters.AddWithValue("@id", lotId);
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        return (Guid)reader["UserId"];
                    }
                    return default(Guid);
                }
            }
        }
    }
}
