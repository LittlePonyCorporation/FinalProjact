﻿using _SuperGirl_Auction.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _SuperGirl_Auction.InterfacesBLL
{
    public interface IUserBLL
    {
        IEnumerable<User> GetAllSortBySurname();
        IEnumerable<User> GetAll();
        User Get(Guid Id);
        Guid Create(User user, Guid LoginId);
        bool Delete(Guid Id);
        bool Change(Guid oldUserId, string newName, string newSurname, string newMail);
        Guid GetUserId(Guid lofinId);
    }
}
