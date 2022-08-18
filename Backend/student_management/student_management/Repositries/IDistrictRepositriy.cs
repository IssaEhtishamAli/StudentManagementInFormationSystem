using DataAcessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace student_management.Repositries
{
    public interface IDistrictRepositriy
    {
        Task<object> GetDistrict();
        Task<object> GetDistrictById(int Id);
        Task<object> AddDistrict(districts ds);
        Task<object> UpdateDistrict(districts ds);
        Task<object> DeleteDistrict(int Id);

    }
}
