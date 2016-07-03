using _SuperGirl_Auction.InterfacesDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _SuperGirl_Auction.Entites;
using System.Data.SqlClient;
using System.Configuration;

namespace _SuperGirl_Auction.DAL
{
    public class ImageDAL : IImageDAL
    {
        string connectionString = ConfigurationManager.ConnectionStrings["default"].ConnectionString;

        public bool AddImage(Guid Lot, Guid img)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var addImage = connection.CreateCommand();
                addImage.CommandText = "UPDATE dbo.Lot SET ImageId=@iID WHERE Id = @LotId";
                addImage.Parameters.AddWithValue("@iID", img);
                addImage.Parameters.AddWithValue("@LotId", Lot);
                connection.Open();
                var result = addImage.ExecuteNonQuery();
                connection.Close();
                return (result != 0);
            }
        }

        public Guid Create(Image img)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var createImage = connection.CreateCommand();
                createImage.CommandText = $"INSERT INTO dbo.Image (Id, Content, ContentType) VALUES (@ID, @CONTENT, @TYPECONTENT)";
                createImage.Parameters.AddWithValue("@ID", img.ID);
                createImage.Parameters.AddWithValue("@CONTENT", img.Content);
                createImage.Parameters.AddWithValue("@TYPECONTENT", img.ContentType);
                connection.Open();
                var result = createImage.ExecuteNonQuery();
                connection.Close();
                if (result != 0)
                {
                    return img.ID;
                }
                return default(Guid);
            }
        }

        public bool Delete(Guid Id)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var changeLot = connection.CreateCommand();
                changeLot.CommandText = "UPDATE dbo.Lot SET ImageId=NULL WHERE ImageId = @Id";
                changeLot.Parameters.AddWithValue("@Id", Id);
                connection.Open();
                var res = changeLot.ExecuteNonQuery();
                connection.Close();
                var deleteImage = connection.CreateCommand();
                deleteImage.CommandText = "DELETE FROM dbo.Image WHERE Id = @ID";
                deleteImage.Parameters.AddWithValue("@ID", Id);
                connection.Open();
                var result = deleteImage.ExecuteNonQuery();
                connection.Close();
                return (result != 0);
            }
        }

        public Image Get(Guid Id)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                Image myImage = null;
                var command = connection.CreateCommand();
                command.CommandText = "SELECT Content, ContentType FROM dbo.Image WHERE Id = @ID";
                command.Parameters.AddWithValue("@ID", Id);
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        myImage = new Image((byte[])reader["Content"], (string)reader["ContentType"]);
                    }
                }
                connection.Close();
                return myImage;
            }
        }

        public Guid GetImageForLot(Guid lotId)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                Guid myImageId = default(Guid);
                var command = connection.CreateCommand();
                command.CommandText = "SELECT ImageId FROM dbo.Lot WHERE Id = @ID";
                command.Parameters.AddWithValue("@ID", lotId);
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        myImageId = (Guid)reader["ImageId"];
                    }
                }
                return myImageId;
            }
        }

    }
}
