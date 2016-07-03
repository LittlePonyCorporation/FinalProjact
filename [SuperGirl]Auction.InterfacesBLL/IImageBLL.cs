using _SuperGirl_Auction.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _SuperGirl_Auction.InterfacesBLL
{
    public interface IImageBLL
    {
        Image Get(Guid Id);
        Guid Create(Image image);
        bool Delete(Guid Id);
        Guid GetImageForLot(Guid lotId);
        bool AddImage(Guid Lot, Guid img);
    }
}
