using DataAcessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace student_management.Repositries
{
    public interface IGenderRepositriy
    {
        Task<object> GetGender();
        Task<object> GetGenderById(int Id);
        Task<object> AddGender(genders gs);
        Task<object> UpdateGender(genders gs);
        Task<object> DeleteGender(int Id);
    }
}
