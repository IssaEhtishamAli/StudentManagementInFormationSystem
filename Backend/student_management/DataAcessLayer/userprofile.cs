using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataAcessLayer
{
    public class userprofile
    {
        public int id { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string contact_no { get; set; }
        public string cnic_no { get; set; }
        public string zip_code { get; set; }
        public  DateTime date_of_birth { get; set; }
        public string permanent_address { get; set; }
        public string resedential_address { get; set; }
        public int user_id { get; set; }
        public int gender_id { get; set; }
        public int degree_id { get; set; }
        public int section_id { get; set; }
        public int country_id { get; set; }
        public int city_id { get; set; }
        public int language_id { get; set; }
        [NotMapped]
        public IFormFile coverphoto { get; set; }
    }
}
