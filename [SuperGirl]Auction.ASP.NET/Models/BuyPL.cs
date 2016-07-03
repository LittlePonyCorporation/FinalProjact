using _SuperGirl_Auction.Entites;
using _SuperGirl_Auction.InterfacesBLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _SuperGirl_Auction.ASP.NET.Models
{
    public class BuyPL
    {
        public IBuyBLL BLL = null;

        public BuyPL()
        {
            BLL = new _SuperGirl_Auction.BLL.BuyBLL();
        }

        public bool Change(Guid lotId, Guid newUserId)
        {
            return BLL.Change(lotId, newUserId);
        }

        public bool Create(Buy buy)
        {
            return BLL.Create(buy);
        }

        public bool Delete(Guid lotId)
        {
            return BLL.Delete(lotId);
        }

        public Buy Get(Guid LotId)
        {
            return BLL.Get(LotId);
        }

        public bool AddInArchive(Buy buy)
        {
            return BLL.AddInArchive(buy);
        }

        public Guid GetLotAr(Guid userId)
        {
            return BLL.GetLotAr(userId);
        }

        public Guid GetUserAr(Guid lotId)
        {
            return BLL.GetUserAr(lotId);
        }
    }
}