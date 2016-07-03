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
    public class LotDAL : ILotDAL
    {
        public List<Lot> ListOfLot= null;
        string connectionString;

        public LotDAL()
        {
            connectionString = ConfigurationManager.ConnectionStrings["default"].ConnectionString;
            ListOfLot = new List<Lot>();
        }

        public bool Change(Guid oldLotId, string newLotName, string newLotDescription)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var changeLot = connection.CreateCommand();
                changeLot.CommandText = "UPDATE dbo.Lot SET Name=@Name, Description=@Description WHERE Id=@Id";
                changeLot.Parameters.AddWithValue("@Name", newLotName);
                changeLot.Parameters.AddWithValue("@Description", newLotDescription);
                changeLot.Parameters.AddWithValue("@Id", oldLotId);
                connection.Open();
                var result = changeLot.ExecuteNonQuery();
                connection.Close();
                return (result != 0);
            }
        }

        public Guid Create(Lot lot)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var createLot = connection.CreateCommand();
                createLot.CommandText = "INSERT INTO dbo.Lot (Id, Name, Description) VALUES (@Id, @Name, @Description)";
                createLot.Parameters.AddWithValue("@Id", lot.ID);
                createLot.Parameters.AddWithValue("@Name", lot.Name);
                createLot.Parameters.AddWithValue("@Description", lot.Description);
                connection.Open();
                var result = createLot.ExecuteNonQuery();
                if (result != 0)
                {
                    return lot.ID;
                }
                else return default(Guid);
            }
        }

        public bool Delete(Guid Id)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var deleteRelation = connection.CreateCommand();
                deleteRelation.CommandText = "DELETE FROM dbo.Relation WHERE idLot = @Id";
                deleteRelation.Parameters.AddWithValue("@Id", Id);
                connection.Open();
                var result = deleteRelation.ExecuteNonQuery();
                if (result == 0)
                {
                    return false;
                }
                var deleteLot = connection.CreateCommand();
                deleteLot.CommandText = "DELETE FROM dbo.Lot WHERE Id = @ID";
                deleteLot.Parameters.AddWithValue("@ID", Id);
                var res = deleteLot.ExecuteNonQuery();
                return (res != 0) ;
            }
        }

        public Lot Get(Guid Id)
        {
            using (var connection = new SqlConnection(connectionString))
            {
               Lot myLot = null;
                var command = connection.CreateCommand();
                command.CommandText = "SELECT Id, Name, Description FROM dbo.Lot WHERE Id = @ID";
                command.Parameters.AddWithValue("@ID", Id);
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        myLot = new Lot((Guid)reader["Id"], (string)reader["Name"], (string)reader["Description"]);
                    }
                    return myLot;
                }
            }
        }

        public IEnumerable<Lot> GetAll()
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandText = "SELECT Id, Name, Description FROM dbo.Lot";
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        ListOfLot.Add(new Lot((Guid)reader["Id"], (string)reader["Name"], (string)reader["Description"]));
                    }
                }
                foreach (var item in ListOfLot)
                {
                    yield return item;
                }
            }
        }

    }
}
