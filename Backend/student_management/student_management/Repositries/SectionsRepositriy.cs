using DataAcessLayer;
using Microsoft.EntityFrameworkCore;
using student_management.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace student_management.Repositries
{
    public class SectionsRepositriy : ISectionsRepositriy
    {
        private readonly ApplicationDbContext _Context;
        public SectionsRepositriy(ApplicationDbContext Context)
        {
            _Context = Context;
        }

        public async Task<object> GetSections()
        {
            try
            {
                var result= await _Context.section.ToListAsync();
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
        public async Task<object> GetSection(int Id)
        {
            try
            {
                return await _Context.section.FirstOrDefaultAsync(a => a.id == Id);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public async Task<object> AddSection(sections sec)
        {
            try
            {
                await _Context.section.AddAsync(sec);
                await _Context.SaveChangesAsync();
                return "Section added sucessfully";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public async Task<object> UpdateSection(sections sec)
        {
            try
            {
                var result = await _Context.section.FirstOrDefaultAsync(a => a.id == sec.id);
                if(result != null)
                {
                    result.section_name = sec.section_name;
                    await _Context.SaveChangesAsync();
                    return "Section updated sucessfully";
                }
                return null;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public async Task<object> DeleteSection(int Id)
        {
            try
            {
                var result = await _Context.section.Where(a => a.id == Id).FirstOrDefaultAsync();
                if(result != null)
                {
                    _Context.section.Remove(result);
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
