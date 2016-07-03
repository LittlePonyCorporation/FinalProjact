using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _SuperGirl_Auction.Entites
{
    public class Lot
    {
        public Guid ID { get; set; }
        private string name;
        private string description;

        public Lot(string name, string description)
        {
            Description = description;
            Name = name;
            ID = Guid.NewGuid();
        }

        public Lot(Guid id, string name, string description)
        {
            Description = description;
            Name = name;
            ID = id;
        }

        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                if (string.IsNullOrWhiteSpace(value) || string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException();
                }
                name = value;
            }
        }

        public string Description
        {
            get
            {
                return description;
            }

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    if (value != null)
                    {
                        throw new ArgumentNullException();
                    }
                }
                description = value;
            }
        }

    }
}
