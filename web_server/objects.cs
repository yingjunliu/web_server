using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace web_server
{
    public class objects
    {
        private string site_name = "";
        private string IP_address = "";
        private int port = 0;
        private string dir_path = "";

        public string Site_Name
        {
            get { return site_name; }
            set { site_name = value; }
        }

        public string IP_Address
        {
            get{ return IP_address; }
            set { IP_address = value; }
        }

        public int Port
        {
            get { return port; }
            set { port = value; }
        }

        public string Dir_Path
        {
            get { return dir_path; }
            set { dir_path = value; }
        }
    }
}
