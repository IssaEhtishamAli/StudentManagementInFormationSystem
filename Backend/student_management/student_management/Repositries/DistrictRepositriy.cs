using DataAcessLayer;
using Microsoft.EntityFrameworkCore;
using student_management.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace student_management.Repositries
{
    public class DistrictRepositriy : IDistrictRepositriy
    {
        public readonly ApplicationDbContext _Context;
        public DistrictRepositriy(ApplicationDbContext Context)
        {
            _Context = Context;
        }
        public async Task<object> GetDistrict()
        {
            try
            {
                var result = await _Context.district.ToListAsync();
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
        public async Task<object> GetDistrictById(int Id)
        {
            try
            {
                return await _Context.district.FirstOrDefaultAsync(a => a.id == Id);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public async Task<object> AddDistrict(districts ds)
        {
            try
            {
                await _Context.district.AddAsync(ds);
                await _Context.SaveChangesAsync();
                return "District Added Sucessfully";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public async Task<object> UpdateDistrict(districts ds)
        {
            try
            {
                var result = await _Context.district.FirstOrDefaultAsync(a => a.id == ds.id);
                if (result !=null)
                {
                    result.district_name = ds.district_name;
                    await _Context.SaveChangesAsync();
                    return "District updated sucessfully";
                }
                return null;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public async Task<object> DeleteDistrict(int Id)
        {
            try
            {
                var result = await _Context.district.Where(a => a.id == Id).FirstOrDefaultAsync();
                if (result !=null)
                {
                    _Context.district.Remove(result);
                    await _Context.SaveChangesAsync();
                    return "Record delted sucessfully";
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
