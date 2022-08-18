using DataAcessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace student_management.Repositries
{
    public interface IQualificationRepositriy
    {
        Task<object> GetQualification();
        Task<object> GetQualificationById(int Id);
        Task<object> AddQualification(qualification qaf);
        Task<object> UpdateQualification(qualification qaf);
        Task<object> DeleteQualification(int Id);
    }
}
