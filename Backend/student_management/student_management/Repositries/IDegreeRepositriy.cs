using DataAcessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace student_management.Repositries
{
    public interface IDegreeRepositriy
    {
        Task<object>GetDegree();
        Task<object>GetDegree(int Id);
        Task<object>AddDegree(degree deg);
        Task<object> UpdateDegree(degree deg);
        Task<object> DeleteDegree(int Id);
    }
}
