using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _SuperGirl_Auction.Entites
{
    public class Registrate
    {
        public Guid ID { get; set; }
        private string login;
        private string password;
        private int pass = 0;
        private int roleId;

        public Registrate(string login, string stringpassword, int role=2)
        {
            RoleId = role;
            ID = Guid.NewGuid();
            Login = login;
            Password = stringpassword;
        }

        public Registrate(Guid id, string login, int intpass, int role)
        {
            RoleId = role;
            ID = id;
            Login = login;
            Pass = intpass;
        }

        public string Login
        {
            get
            {
                return login;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value) || string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException();
                }
                login = value;
            }
        }

        public string Password
        {
            get
            {
                return password;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value) || string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException();
                }
                password = value;
            }
        }

        public int Pass
        {
            get
            {
                return pass;
            }
            set
            {
                if (value == 0)
                {
                    throw new Exception();
                }
                pass = value;
            }
        }

        public int RoleId
        {
            get
            {
                return roleId;
            }
            set
            {
                if (value == 1 || value == 2)
                {
                    roleId = value;
                }
                else
                {
                    throw new ArgumentException();
                }
            }
        }
    }
}
