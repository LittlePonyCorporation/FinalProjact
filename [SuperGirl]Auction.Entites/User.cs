using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _SuperGirl_Auction.Entites
{
    public class User
    {
        public Guid ID { get; set; }
        private string name;
        private string surname;
        private string mail;

        public User( string name, string surname, string mail)
        {
            Name = name;
            Surname = surname;
            Mail = mail;
            ID = Guid.NewGuid();
        }

        public User(Guid id, string name, string surname, string mail)
        {
            Name = name;
            Surname = surname;
            Mail = mail;
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

        public string Surname
        {
            get
            {
                return surname;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value) || string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException();
                }
                surname = value;
            }
        }

        public string Mail
        {
            get
            {
                return mail;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value) || string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException();
                }
                mail = value;
            }
        }

    }
}
