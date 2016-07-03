using _SuperGirl_Auction.InterfacesBLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _SuperGirl_Auction.Entites;
using _SuperGirl_Auction.InterfacesDAL;
using System.Configuration;
using System.IO;
using _SuperGirl_Auction.DAL;

namespace _SuperGirl_Auction.BLL
{
    public class UserBLL : IUserBLL
    {
        private IUserDAL UserDAL;

        public UserBLL()
        {
            string typeDAL;
            try
            {
                typeDAL = ConfigurationManager.AppSettings["TypeDal"];
            }
            catch (FileNotFoundException ex)
            {
                throw new ConfigurationFileException("Some problem whith file", ex);
            }
            switch (typeDAL)
            {
                case "DB":
                    try
                    {
                        UserDAL = new _SuperGirl_Auction.DAL.UserDAL();
                    }
                    catch (DirectoryNotFoundException e)
                    {
                        throw new ConfigurationFileException("Problem whith the data base ", e);
                    }
                    break;
            }
        }

        public bool Change(Guid oldUserId, string newName, string newSurname, string newMail)
        {
            try
            {
                UserDAL.Change(oldUserId, newName, newSurname, newMail);
                return true;
            }
            catch (Exception e)
            {
                Logger.Logger.CreateLog(e);
                return false;
            }
        }

        public Guid Create(User user, Guid loginId)
        {
            try
            {
               return UserDAL.Create(user, loginId);
            }
            catch (Exception e)
            {
                Logger.Logger.CreateLog(e);
                return default(Guid);
            }
        }

        public bool Delete(Guid Id)
        {
            try
            {
                UserDAL.Delete(Id);
                return true;
            }
            catch (Exception e)
            {
                Logger.Logger.CreateLog(e);
                return false;
            }
        }

        public User Get(Guid Id)
        {
            try
            {
                return UserDAL.Get(Id);
            }
            catch (Exception e)
            {
                Logger.Logger.CreateLog(e);
                return null;
            }
        }

        public IEnumerable<User> GetAll()
        {
            try
            {
                return UserDAL.GetAll().ToArray();
            }
            catch (Exception e)
            {
                Logger.Logger.CreateLog(e);
                return null;
            }
        }

        public IEnumerable<User> GetAllSortBySurname()
        {
            try
            {
                return UserDAL.GetAll().OrderBy(x => x.Surname).ToArray();
            }
            catch (Exception e)
            {
                Logger.Logger.CreateLog(e);
                return null;
            }
        }

        public Guid GetUserId(Guid loginId)
        {
            try
            {
                return UserDAL.GetUserId(loginId);
            }
            catch (Exception e)
            {
                Logger.Logger.CreateLog(e);
                return default(Guid);
            }
        }
    }
}
