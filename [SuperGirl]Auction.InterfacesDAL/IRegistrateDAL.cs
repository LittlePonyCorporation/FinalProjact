using _SuperGirl_Auction.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _SuperGirl_Auction.InterfacesDAL
{
    public interface IRegistrateDAL
    {
        Guid Create(Registrate reg);
        bool Delete(Guid Id);
        Registrate GetUser(Guid loginId);
        int GetPass(string login);
        int GetRole(Guid loginId);
        string GetRoleName(int role);
        Guid GetLoginId(Guid userId);
        bool ChangeRole(Guid LoginId, int roleId);
        Guid GetLoginId(string log);
    }
}
