using DataAcessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace student_management.Repositries
{
    public interface ILanguagesRepositriy
    {
        Task<object> Getlanguagedetail();
        Task<object> Getlanguagebyid(int id);
        Task<object> Postlanguagedetail(languages lang);
        Task<object> Updatelanguagedetail(languages lang);
        Task<object> Deletlanguagedetail(int id);
    }
}
