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
    public class RelationBLL : IRelationBLL
    {
        private IRelationDAL DAL;
 
        public RelationBLL()
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
                        DAL = new _SuperGirl_Auction.DAL.RelationDAL();
                    }
                    catch (DirectoryNotFoundException e)
                    {
                        throw new ConfigurationFileException("Problem whith the data base ", e);
                    }
                    break;
            }
        }

        public bool Create(Relation relation)
        {
            try
            {
                DAL.Create(relation);
                return true;
            }
            catch (Exception e)
            {
                Logger.Logger.CreateLog(e);
                return false;
            }
        }

        public bool Delete(Guid Id)
        {
            try
            {
                DAL.Delete(Id);
                return true;
            }
            catch (Exception e)
            {
                Logger.Logger.CreateLog(e);
                return false;
            }
        }

        public IEnumerable<Relation> GetAll()
        {
            try
            {
                return DAL.GetAll().ToArray();
            }
            catch (Exception e)
            {
                Logger.Logger.CreateLog(e);
                return null;
            }
        }

        public IEnumerable<Guid> GetLotId(Guid UserId)
        {
            try
            {
                return DAL.GetLotId(UserId);
            }
            catch (Exception e)
            {
                Logger.Logger.CreateLog(e);
                return null;
            }
        }

        public Guid GetUserId(Guid LotId)
        {
            try
            {
                return DAL.GetUserId(LotId);
            }
            catch (Exception e)
            {
                Logger.Logger.CreateLog(e);
                return default(Guid);
            }
        }
    }
}
