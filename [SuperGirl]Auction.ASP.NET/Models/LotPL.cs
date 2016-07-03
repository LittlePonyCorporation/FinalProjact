using _SuperGirl_Auction.Entites;
using _SuperGirl_Auction.InterfacesBLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _SuperGirl_Auction.ASP.NET.Models
{
    public class LotPL
    {
        private ILotBLL LBLL;

        public LotPL()
        {
            LBLL = new _SuperGirl_Auction.BLL.LotBLL();
        }

        public bool Change(Guid oldLotId, string newLotName, string newLotDescription)
        {
            return LBLL.Change(oldLotId, newLotName, newLotDescription);
        }

        public Guid Create(Lot lot)
        {
            return LBLL.Create(lot);
        }

        public bool Delete(Guid Id)
        {
            return LBLL.Delete(Id);
        }

        public Lot Get(Guid Id)
        {
            return LBLL.Get(Id);
        }

        public IEnumerable<Lot> GetAll()
        {
            return LBLL.GetAll().ToArray();
        }

        public IEnumerable<Lot> GetAllSortByName()
        {
            return LBLL.GetAllSortByName().ToArray();
        }
    }
}