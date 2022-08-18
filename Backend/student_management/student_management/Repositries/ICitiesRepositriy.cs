using DataAcessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace student_management.Repositries
{
    public interface ICitiesRepositriy
    {
        Task<object>GetCities();
        Task<object>GetCity(int Id);
        Task<object>AddCity(cities ct);
        Task<object>UpdateCity(cities ct);
        Task<object> DeleteCity(int Id);
    }
}
