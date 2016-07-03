using _SuperGirl_Auction.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _SuperGirl_Auction.InterfacesDAL
{
    public interface IRelationDAL
    {
        IEnumerable<Relation> GetAll();
        bool Create(Relation relation);
        bool Delete(Guid Id);
        Guid GetUserId(Guid LotId);
        IEnumerable<Guid> GetLotId(Guid UserId);
    }
}
