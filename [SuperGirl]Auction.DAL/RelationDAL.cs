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
    public class RelationDAL : IRelationDAL
    {
        string connectionString;

        public RelationDAL()
        {
            connectionString = ConfigurationManager.ConnectionStrings["default"].ConnectionString;
        }

        public bool Create(Relation relation)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var createLot = connection.CreateCommand();
                createLot.CommandText = "INSERT INTO dbo.Relation (idUser, idLot) VALUES (@uId, @lId)";
                createLot.Parameters.AddWithValue("@uId", relation.UserId);
                createLot.Parameters.AddWithValue("@lId", relation.LotId);
                connection.Open();
                var result = createLot.ExecuteNonQuery();
                return (result != 0);
            }
        }

        public bool Delete(Guid Id)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var deleteRelation = connection.CreateCommand();
                deleteRelation.CommandText = "DELETE FROM dbo.Relation WHERE idLot = @Id OR idUser = @ID";
                deleteRelation.Parameters.AddWithValue("@Id", Id);
                connection.Open();
                var result = deleteRelation.ExecuteNonQuery();
                return (result != 0);
            }
        }

        public IEnumerable<Relation> GetAll()
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandText = "SELECT idLot, idUser FROM dbo.Relation";
                connection.Open();
                List<Relation> ListOfRelation = new List<Relation>();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        ListOfRelation.Add(new Relation((Guid)reader["idUser"], (Guid)reader["idLot"]));
                    }
                }
                foreach (var item in ListOfRelation)
                {
                    yield return item;
                }
            }
        }

        public IEnumerable<Guid> GetLotId(Guid UserId)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandText = "SELECT idLot FROM dbo.Relation WHERE idUser=@uID";
                command.Parameters.AddWithValue("uID", UserId);
                connection.Open();
                List<Guid> LotsId = new List<Guid>();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        LotsId.Add((Guid)reader["idLot"]);
                    }
                }
                foreach (var item in LotsId)
                {
                    yield return item;
                }
            }
        }

        public Guid GetUserId(Guid LotId)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandText = "SELECT idUser FROM dbo.Relation WHERE idLot=@lID";
                command.Parameters.AddWithValue("lID", LotId);
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        return (Guid)reader["idUser"];
                    }
                    return default(Guid);
                }
            }
        }
    }
}
