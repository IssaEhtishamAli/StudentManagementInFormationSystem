using DataAcessLayer;
using Microsoft.EntityFrameworkCore;
using student_management.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace student_management.Repositries
{
    public class DegreeRepositriy :IDegreeRepositriy
    {
        public readonly ApplicationDbContext _Context;
        public DegreeRepositriy(ApplicationDbContext Context)
        {
            _Context = Context;
        }
        public async Task<object> GetDegree()
        {
            try
            {
                var result = await _Context.degree.ToListAsync();
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
        public async Task<object> GetDegree(int Id)
        {
            try
            {
                return  await _Context.degree.FirstOrDefaultAsync(a => a.id == Id);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public async Task<object> AddDegree(degree deg)
        {
            try
            {
                await _Context.degree.AddAsync(deg);
                await _Context.SaveChangesAsync();
                return "Degree Add Sucessfully";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public async Task<object> UpdateDegree(degree deg)
        {
            try
            {
                var result = await _Context.degree.FirstOrDefaultAsync(a => a.id == deg.id);
                if(result != null)
                {
                    result.degree_title = deg.degree_title;
                    await _Context.SaveChangesAsync();
                    return "Degree Title updated sucessfully";
                }
                return null;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public async Task<object> DeleteDegree(int Id)
        {
            try
            {
                var result = await _Context.degree.Where(a => a.id == Id).FirstOrDefaultAsync();
                if (result != null)
                {
                    _Context.degree.Remove(result);
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
