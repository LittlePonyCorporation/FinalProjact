using _SuperGirl_Auction.InterfacesBLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _SuperGirl_Auction.Entites;
using System.Configuration;
using _SuperGirl_Auction.DAL;
using System.IO;
using _SuperGirl_Auction.InterfacesDAL;

namespace _SuperGirl_Auction.BLL
{
    public class ImageBLL : IImageBLL
    {
        private IImageDAL ImgDAL;

        public ImageBLL()
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
                        ImgDAL = new _SuperGirl_Auction.DAL.ImageDAL();
                    }
                    catch (DirectoryNotFoundException e)
                    {
                        throw new ConfigurationFileException("Problem whith the data base ", e);
                    }
                    break;
            }
        }

        public bool AddImage(Guid Lot, Guid img)
        {
            try
            {
                ImgDAL.AddImage(Lot, img);
                return true;
            }
            catch (Exception e)
            {
                Logger.Logger.CreateLog(e);
                return false;
            }
        }

        public Guid Create(Image image)
        {
            try
            {
                return ImgDAL.Create(image);
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
                ImgDAL.Delete(Id);
                return true;
            }
            catch (Exception e)
            {
                Logger.Logger.CreateLog(e);
                return false;
            }
        }

        public Image Get(Guid Id)
        {
            try
            {
                return ImgDAL.Get(Id); 
            }
            catch (Exception e)
            {
                Logger.Logger.CreateLog(e);
                return null;
            }
        }

        public Guid GetImageForLot(Guid lotId)
        {
            try
            {
                return ImgDAL.GetImageForLot(lotId);
            }
            catch (Exception e)
            {
                Logger.Logger.CreateLog(e);
                return default(Guid);
            }
        }
    }
}
