using DataAcessLayer;
using Microsoft.EntityFrameworkCore;
using student_management.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace student_management.Repositries
{
    public class GenderRepositriy : IGenderRepositriy
    {
        private readonly ApplicationDbContext _Context;
        public GenderRepositriy(ApplicationDbContext Context)
        {
            _Context = Context;
        }
        public async Task<object> GetGender()
        {
            try
            {
                var result = await _Context.gender.ToListAsync();
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
        public async Task<object> GetGenderById(int Id)
        {
            try
            {
                return await _Context.gender.FirstOrDefaultAsync(a => a.id == Id);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public async Task<object> AddGender(genders gs)
        {
            try
            {
                 await _Context.gender.AddAsync(gs);
                 await _Context.SaveChangesAsync();
                 return "Gender added sucessfully";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public async Task<object> DeleteGender(int Id)
        {
            try
            {
                var result = await _Context.gender.Where(a => a.id == Id).FirstOrDefaultAsync();
                if (result != null)
                {
                    _Context.gender.Remove(result);
                    await _Context.SaveChangesAsync();
                    return "Delete data sucessfully";
                }
                return null;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }         
        }
        public async Task<object> UpdateGender(genders gs)
        {
            try
            {
                var result = await _Context.gender.FirstOrDefaultAsync(a => a.id == gs.id);
                if(result != null)
                {
                    result.gender_type = gs.gender_type;
                    await _Context.SaveChangesAsync();
                    return "Gender updated sucessfully";
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
