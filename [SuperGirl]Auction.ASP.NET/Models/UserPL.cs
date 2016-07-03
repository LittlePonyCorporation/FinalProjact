using _SuperGirl_Auction.Entites;
using _SuperGirl_Auction.InterfacesBLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _SuperGirl_Auction.ASP.NET.Models
{
    public class UserPL
    {
        private IUserBLL UBLL;

        public UserPL()
        {
            UBLL = new _SuperGirl_Auction.BLL.UserBLL();
        }

        public bool Change(Guid oldUserId, string newName, string newSurname, string newMail)
        {
            return UBLL.Change(oldUserId, newName, newSurname, newMail);
        }

        public Guid Create(User user, Guid log)
        {
            return UBLL.Create(user, log);
        }

        public bool Delete(Guid Id)
        {
            return UBLL.Delete(Id);
        }

        public User Get(Guid Id)
        {
            return UBLL.Get(Id);
        }

        public IEnumerable<User> GetAll()
        {
            return UBLL.GetAll().ToArray();
        }

        public IEnumerable<User> GetAllSortBySurname()
        {
            return UBLL.GetAllSortBySurname().ToArray();
        }

        public Guid GetUserId(Guid logId)
        {
            return UBLL.GetUserId(logId);
        }
    }
}