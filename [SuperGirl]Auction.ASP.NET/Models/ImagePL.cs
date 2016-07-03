using _SuperGirl_Auction.Entites;
using _SuperGirl_Auction.InterfacesBLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _SuperGirl_Auction.ASP.NET.Models
{
    public class ImagePL
    {
        private IImageBLL IBLL;

        public ImagePL()
        {
            IBLL = new _SuperGirl_Auction.BLL.ImageBLL();
        }

        public Guid Create(Image image)
        {
            return IBLL.Create(image);
        }

        public bool Delete(Guid Id)
        {
            return IBLL.Delete(Id);
        }

        public Image Get(Guid Id)
        {
            return IBLL.Get(Id);
        }

        public Guid GetImageForLot(Guid lotId)
        {
            return IBLL.GetImageForLot(lotId);
        }
        public bool AddImage(Guid Lot, Guid img)
        {
            return IBLL.AddImage(Lot, img);
        }
    }
}