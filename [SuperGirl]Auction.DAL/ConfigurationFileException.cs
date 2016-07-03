using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _SuperGirl_Auction.DAL
{
    public class ConfigurationFileException: Exception
    {
        public ConfigurationFileException()
        {

        }

        public ConfigurationFileException(string massage) : base(massage)
        {

        }

        public ConfigurationFileException(string massage, Exception innerExeption) : base(massage, innerExeption)
        {

        }
    }
}
