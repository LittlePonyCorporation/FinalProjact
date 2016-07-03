using _SuperGirl_Auction.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _SuperGirl_Auction.InterfacesDAL
{
    public interface IImageDAL
    {
        Image Get(Guid Id);
        Guid Create(Image image);
        bool Delete(Guid Id);
        bool AddImage(Guid Lot, Guid img);
        Guid GetImageForLot(Guid lotId);
    }
}
