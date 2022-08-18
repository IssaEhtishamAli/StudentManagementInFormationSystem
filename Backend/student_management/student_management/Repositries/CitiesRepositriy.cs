using DataAcessLayer;
using Microsoft.EntityFrameworkCore;
using student_management.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace student_management.Repositries
{
    public class CitiesRepositriy : ICitiesRepositriy
    {
        public readonly ApplicationDbContext _Context;
        public CitiesRepositriy(ApplicationDbContext Context)
        {
            _Context = Context;
        }
        public async Task<object> GetCities()
        {
            try
            {
                var result = await _Context.cities.ToListAsync();
                if (result.Count > 0)
                {
                    return result;
                }
                return null;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public async Task<object> GetCity(int Id)
        {
            try
            {
                return await _Context.cities.FirstOrDefaultAsync(a => a.id == Id);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public async Task<object> AddCity(cities ct)
        {
            try
            {
                await _Context.cities.AddAsync(ct);
                await _Context.SaveChangesAsync();
                return "City added sucessfully";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public async Task<object> UpdateCity(cities ct)
        {
            try
            {
                var result = await _Context.cities.FirstOrDefaultAsync(a => a.id == ct.id);
                if(result != null)
                {
                    result.city = ct.city;
                    await _Context.SaveChangesAsync();
                    return "City updated sucessfully";
                }
                return null;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public async Task<object> DeleteCity(int Id)
        {
            try
            {
                var result = await _Context.cities.Where(a => a.id == Id).FirstOrDefaultAsync();
                if (result != null)
                {
                    _Context.cities.Remove(result);
                    await _Context.SaveChangesAsync();
                    return result;
                }
                return null;
            }
            catch (Exception ex)
            {
                return ex.Message;
            } 
        }
    }
}
