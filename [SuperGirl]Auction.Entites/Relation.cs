using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _SuperGirl_Auction.Entites
{
    public class Relation
    {
        public Guid UserId { get; set; }
        public Guid LotId { get; set; }

        public Relation(Guid userId, Guid lotId)
        {
            UserId = userId;
            LotId = lotId;
        }
    }
}
