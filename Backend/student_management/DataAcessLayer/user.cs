using System;
using System.Collections.Generic;
using System.Text;

namespace DataAcessLayer
{
    public class User
    {
        public int id { get; set; }
        public string user_name { get; set; }
        public string password { get; set; }
        public string email { get; set; }
        public int user_type { get; set; }
        public int status { get; set; }

    }
}
