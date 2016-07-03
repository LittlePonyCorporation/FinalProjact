using _SuperGirl_Auction.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _SuperGirl_Auction.InterfacesDAL
{
    public interface IBuyDAL
    {
        bool Create(Buy buy);
        bool Change(Guid lotId, Guid newUserId);
        bool Delete(Guid lotId);
        Buy Get(Guid LotId);
        bool AddInArchive(Buy buy);
        Guid GetUserAr(Guid lotId);
        Guid GetLotAr(Guid userId);
    }
}
