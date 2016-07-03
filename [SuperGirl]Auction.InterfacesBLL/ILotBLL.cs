using _SuperGirl_Auction.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _SuperGirl_Auction.InterfacesBLL
{
    public interface ILotBLL
    {
        IEnumerable<Lot> GetAllSortByName();
        IEnumerable<Lot> GetAll();
        Lot Get(Guid Id);
        Guid Create(Lot lot);
        bool Delete(Guid Id);
        bool Change(Guid oldLotId, string newLotName, string newLotDescription);
    }
}
