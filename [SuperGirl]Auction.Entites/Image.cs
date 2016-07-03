using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _SuperGirl_Auction.Entites
{
    public class Image
    {
        public string ContentType { get; set; }
        public byte[] Content { get; set; }
        public Guid ID { get; set; }

        public Image(byte[] content, string contenttype)
        {
            ID = Guid.NewGuid();
            Content = content;
            ContentType = contenttype;
        }

        public Image(Guid id, byte[] content, string contenttype)
        {
            ID = id;
            Content = content;
            ContentType = contenttype;
        }

    }
}
