using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _SuperGirl_Auction.Entites
{
    public class Buy
    {
        public Guid LogId { get; set; }
        public Guid NewUserId { get; set; }
        public DateTime BuyTime { get; set; }

        public Buy(Guid lid, Guid nuid)
        {
            LogId = lid;
            NewUserId = nuid;
            BuyTime = DateTime.Now;
        }

        public Buy(Guid lid, Guid nuid, DateTime bt)
        {
            LogId = lid;
            NewUserId = nuid;
            BuyTime = bt;
        }
    }
}
