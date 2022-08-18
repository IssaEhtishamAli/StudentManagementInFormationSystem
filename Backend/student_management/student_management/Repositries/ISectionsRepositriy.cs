using DataAcessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace student_management.Repositries
{
    public interface ISectionsRepositriy
    {
        Task<object>GetSections();
        Task<object>GetSection(int Id);
        Task<object>AddSection(sections sec);
        Task<object> UpdateSection(sections sec);
        Task<object> DeleteSection(int id);
    }
}
