using DataAcessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace student_management.Repositries
{
    public interface ICountryRepositriy
    {
        Task<object> GetCountryies();
        Task<object> GetContryiesById(int Id);
        Task<object> AddCountry(countryies cn);
        Task<object> UpdateCountry(countryies cn);
        Task<object> DeleteCountry(int Id);
    }
}
