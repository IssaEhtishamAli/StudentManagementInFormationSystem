using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace student_management.Model
{
    public class saveimagefile
    {
        public int fileId { get; set; }
        public int user_id { get; set; }
        public string image_url { get; set; }

    }

    public class UserLogin
    {
        public string email { get; set; }
        public string password { get; set; }
    }

    public class UserPassword
    {
        public string email { get; set; }
        public string password { get; set; }

    }

}
