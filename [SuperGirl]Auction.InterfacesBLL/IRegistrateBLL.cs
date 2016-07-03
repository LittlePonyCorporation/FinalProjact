using _SuperGirl_Auction.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _SuperGirl_Auction.InterfacesBLL
{
    public interface IRegistrateBLL
    {
        Guid Create(Registrate registrate);
        bool Delete(Guid Id);
        Registrate GetUser(Guid loginId);
        int GetPass(string login);
        int GetRole(Guid loginId);
        string GetRoleName(string login);
        Guid GetLoginId(Guid userId);
        bool ChangeRole(Guid LoginId, int roleId);
        Guid GetLoginId(string log);
    }
}
