using DataAcessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace student_management.Repositries
{
    public interface ITitleRepositriy
    {
        Task<object> GetTitle();
        Task<object> GetTitleById(int Id);
        Task<object> AddTitle(titles ts);
        Task<object> UpdateTitle(titles ts);
        Task<object> DeleteTitle(int Id);
    }
}
