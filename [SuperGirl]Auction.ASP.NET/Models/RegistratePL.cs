using _SuperGirl_Auction.Entites;
using _SuperGirl_Auction.InterfacesBLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _SuperGirl_Auction.ASP.NET.Models
{
    public class RegistratePL
    {
        private IRegistrateBLL RBLL;

        public RegistratePL()
        {
            RBLL = new _SuperGirl_Auction.BLL.RegistrateBLL();
        }

        public Guid Create(Registrate registrate)
        {
            return RBLL.Create(registrate);
        }

        public bool Delete(Guid Id)
        {
            return RBLL.Delete(Id);
        }

        public int GetPass(string login)
        {
            return RBLL.GetPass(login);
        }

        public int GetRole(Guid loginId)
        {
            return RBLL.GetRole(loginId);
        }

        public Registrate GetUser(Guid loginId)
        {
            return RBLL.GetUser(loginId);
        }

        public Guid GetLoginId(Guid uId)
        {
            return RBLL.GetLoginId(uId);
        }

        public Guid GetLoginId(string log)
        {
            return RBLL.GetLoginId(log);
        }

        public bool ChangeRole(Guid LoginId, int roleId)
        {
            return RBLL.ChangeRole(LoginId, roleId);
        }

        public string GetRoleName(string login)
        {
            return RBLL.GetRoleName(login);
        }
    }
}