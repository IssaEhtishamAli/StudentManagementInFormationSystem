using DataAcessLayer;
using Microsoft.EntityFrameworkCore;
using student_management.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace student_management.Repositries
{
    public class CountryRepositriy : ICountryRepositriy
    {
        public readonly ApplicationDbContext _Context;
        public CountryRepositriy(ApplicationDbContext Context)
        {
            _Context = Context;
        }
        public async Task<object> AddCountry(countryies cn)
        {
            try
            {
                await _Context.country.AddAsync(cn);
                await _Context.SaveChangesAsync();
                return "Country Added Sucessfully";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public async Task<object> DeleteCountry(int Id)
        {
            try
            {
                var result = await _Context.country.Where(a => a.id == Id).FirstOrDefaultAsync();
                if(result != null)
                {
                    _Context.country.Remove(result);
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

        public async Task<object> GetContryiesById(int Id)
        {
            try
            {
                return await _Context.country.FirstOrDefaultAsync(a => a.id == Id);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public async Task<object> GetCountryies()
        {
            try
            {
                var result = await _Context.country.ToListAsync();
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

        public async Task<object> UpdateCountry(countryies cn)
        {
            try
            {
                var result = await _Context.country.FirstOrDefaultAsync(a => a.id == cn.id);
                if (result !=null)
                {
                    result.name = cn.name;
                    await _Context.SaveChangesAsync();
                    return "Country updated sucessfully";
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
