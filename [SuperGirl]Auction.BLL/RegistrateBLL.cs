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
    public class RegistrateBLL : IRegistrateBLL
    {
        private IRegistrateDAL RDAL;

        public RegistrateBLL()
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
                        RDAL = new _SuperGirl_Auction.DAL.RegistrateDAL();
                    }
                    catch (DirectoryNotFoundException e)
                    {
                        throw new ConfigurationFileException("Problem whith the data base ", e);
                    }
                    break;
            }
        }

        public bool ChangeRole(Guid LoginId, int roleId)
        {
            try
            {
                RDAL.ChangeRole(LoginId, roleId);
                return true;
            }
            catch (Exception e)
            {
                Logger.Logger.CreateLog(e);
                return false;
            }
        }

        public Guid Create(Registrate registrate)
        {
            try
            {
                return RDAL.Create(registrate);
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
                RDAL.Delete(Id);
                return true;
            }
            catch (Exception e)
            {
                Logger.Logger.CreateLog(e);
                return false;
            }
        }

        public Guid GetLoginId(string log)
        {
            try
            {
                return RDAL.GetLoginId(log);
            }
            catch (Exception e)
            {
                Logger.Logger.CreateLog(e);
                return default(Guid);
            }
        }

        public Guid GetLoginId(Guid uId)
        {
            try
            {
                return RDAL.GetLoginId(uId);
            }
            catch (Exception e)
            {
                Logger.Logger.CreateLog(e);
                return default(Guid);
            }
        }

        public int GetPass(string login)
        {
            try
            {
                return RDAL.GetPass(login);
            }
            catch (Exception e)
            {
                Logger.Logger.CreateLog(e);
                return 0;
            }
        }

        public int GetRole(Guid loginId)
        {
            try
            {
                return RDAL.GetRole(loginId);
            }
            catch (Exception e)
            {
                Logger.Logger.CreateLog(e);
                return 0;
            }
        }

        public string GetRoleName(string login)
        {
           return RDAL.GetRoleName(RDAL.GetRole(RDAL.GetLoginId(login)));
        }

        public Registrate GetUser(Guid loginId)
        {
            try
            {
                return RDAL.GetUser(loginId);
            }
            catch (Exception e)
            {
                Logger.Logger.CreateLog(e);
                return null;
            }
        }
    }
}
