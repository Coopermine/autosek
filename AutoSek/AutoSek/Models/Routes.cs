using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSek.Models
{
    class Routes
    {
        public int routeid
        {
            get;
            set;
        }
        public string devicename
        {
            get;
            set;
        }

        public int deviceid
        {
            get;
            set;
        }
        public string servertime
        {
            get;
            set;
        }
        public string devicetime
        {
            get;
            set;
        }
        public decimal latitude
        {
            get;
            set;
        }
        public decimal longitude
        {
            get;
            set;
        }
        public string speed
        {
            get;
            set;
        }
        public string course
        {
            get;
            set;
        }
        public string address
        {
            get;
            set;
        }
        public string attributes
        {
            get;
            set;
        }
    }
}
