using _SuperGirl_Auction.Entites;
using _SuperGirl_Auction.InterfacesBLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _SuperGirl_Auction.ASP.NET.Models
{
    public class RelationPL
    {
        private IRelationBLL RBLL;

        public RelationPL()
        {
            RBLL = new _SuperGirl_Auction.BLL.RelationBLL();
        }

        public bool Create(Relation relation)
        {
            return RBLL.Create(relation);
        }

        public bool Delete(Guid Id)
        {
            return RBLL.Delete(Id);
        }

        public IEnumerable<Relation> GetAll()
        {
            return RBLL.GetAll().ToArray();
        }

        public IEnumerable<Guid> GetLotId(Guid UserId)
        {
            return RBLL.GetLotId(UserId);
        }

        public Guid GetUserId(Guid LotId)
        {
            return RBLL.GetUserId(LotId);
        }
    }
}