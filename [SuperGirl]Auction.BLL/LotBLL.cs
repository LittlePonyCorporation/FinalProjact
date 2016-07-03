using _SuperGirl_Auction.InterfacesBLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _SuperGirl_Auction.Entites;
using _SuperGirl_Auction.InterfacesDAL;
using System.Configuration;
using _SuperGirl_Auction.DAL;
using System.IO;

namespace _SuperGirl_Auction.BLL
{
    public class LotBLL : ILotBLL
    {
        private ILotDAL LotDAL;

        public LotBLL()
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
                        LotDAL = new _SuperGirl_Auction.DAL.LotDAL();
                    }
                    catch (DirectoryNotFoundException e)
                    {
                        throw new ConfigurationFileException("Problem whith the data base ", e);
                    }
                    break;
            }
        }

        public bool Change(Guid oldLotId, string newLotName, string newLotDescription)
        {
            try
            {
                LotDAL.Change(oldLotId, newLotName, newLotDescription);
                return true;
            }
            catch (Exception e)
            {
                Logger.Logger.CreateLog(e);
                return false;
            }
        }

        public Guid Create(Lot lot)
        {
            try
            {
                return LotDAL.Create(lot);
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
                LotDAL.Delete(Id);
                return true;
            }
            catch (Exception e)
            {
                Logger.Logger.CreateLog(e);
                return false;
            }
        }

        public Lot Get(Guid Id)
        {
            try
            {
                return LotDAL.Get(Id);
            }
            catch (Exception e)
            {
                Logger.Logger.CreateLog(e);
                return null;
            }
        }

        public IEnumerable<Lot> GetAll()
        {
            try
            {
                return LotDAL.GetAll().ToArray();
            }
            catch (Exception e)
            {
                Logger.Logger.CreateLog(e);
                return null;
            }
        }

        public IEnumerable<Lot> GetAllSortByName()
        {
            try
            {
                return LotDAL.GetAll().OrderBy(x => x.Name).ToArray();
            }
            catch (Exception e)
            {
                Logger.Logger.CreateLog(e);
                return null;
            }
        }
    }
}
