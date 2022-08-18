using System;
using System.Collections.Generic;
using System.Text;

namespace DataAcessLayer
{
    public class qualification
    {
        public int id { get; set; }
        public int user_id { get; set; }
        public string institute_name { get; set; }
        public string major_subjects { get; set; }
        public int total_marks { get; set; }
        public int obtained_marks { get; set; }
    }
}
