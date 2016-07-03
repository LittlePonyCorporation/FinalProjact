using _SuperGirl_Auction.InterfacesBLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _SuperGirl_Auction.Entites;
using System.Configuration;
using System.IO;
using _SuperGirl_Auction.DAL;
using _SuperGirl_Auction.InterfacesDAL;

namespace _SuperGirl_Auction.BLL
{
    public class BuyBLL : IBuyBLL
    {
        public IBuyDAL BDAL = null;

            public BuyBLL()
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
                        BDAL = new _SuperGirl_Auction.DAL.BuyDAL();
                    }
                    catch (DirectoryNotFoundException e)
                    {
                        throw new ConfigurationFileException("Problem whith the data base ", e);
                    }
                    break;
            }
        }

        public bool AddInArchive(Buy buy)
        {
            try
            {
                BDAL.AddInArchive(buy);
                return true;
            }
            catch (Exception e)
            {
                Logger.Logger.CreateLog(e);
                return false;
            }
        }

        public bool Change(Guid lotId, Guid newUserId)
        {
            try
            {
                BDAL.Change(lotId, newUserId);
                return true;
            }
            catch (Exception e)
            {
                Logger.Logger.CreateLog(e);
                return false;
            }
        }

        public bool Create(Buy buy)
        {
            try
            {
                BDAL.Create(buy);
                return true;
            }
            catch (Exception e)
            {
                Logger.Logger.CreateLog(e);
                return false;
            }
        }

        public bool Delete(Guid lotId)
        {
            try
            {
                BDAL.Delete(lotId);
                return true;
            }
            catch (Exception e)
            {
                Logger.Logger.CreateLog(e);
                return false;
            }
        }

        public Buy Get(Guid LotId)
        {
            try
            {
                return BDAL.Get(LotId);
            }
            catch (Exception e)
            {
                Logger.Logger.CreateLog(e);
                return null;
            }
        }

        public Guid GetLotAr(Guid userId)
        {
            try
            {
                return BDAL.GetLotAr(userId);
            }
            catch (Exception e)
            {
                Logger.Logger.CreateLog(e);
                return default(Guid);
            }
        }

        public Guid GetUserAr(Guid lotId)
        {
            try
            {
                return BDAL.GetUserAr(lotId);
             }
            catch (Exception e)
            {
                Logger.Logger.CreateLog(e);
                return default(Guid);
            }
        }
    }
}
