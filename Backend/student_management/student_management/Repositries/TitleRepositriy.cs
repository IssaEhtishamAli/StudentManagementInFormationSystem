using DataAcessLayer;
using Microsoft.EntityFrameworkCore;
using student_management.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace student_management.Repositries
{
    public class TitleRepositriy : ITitleRepositriy
    {
        private readonly ApplicationDbContext _Context;
        public TitleRepositriy(ApplicationDbContext Context)
        {
            _Context = Context;
        }
        public async Task<object> GetTitle()
        {
            try
            {
                var result = await _Context.title.ToListAsync();
                if(result.Count > 0)
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
        public async Task<object> GetTitleById(int Id)
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
        public async Task<object> AddTitle(titles ts)
        {
            try
            {
                await _Context.title.AddAsync(ts);
                await _Context.SaveChangesAsync();
                return "Title added sucessfully";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public async Task<object> DeleteTitle(int Id)
        {
            try
            {
                var result = await _Context.title.Where(a => a.id == Id).FirstOrDefaultAsync();
                if (result != null)
                {
                    _Context.title.Remove(result);
                    await _Context.SaveChangesAsync();
                    return "Title deleted sucessfully";
                }
                return null;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public async Task<object> UpdateTitle(titles ts)
        {
            try
            {
                var result = await _Context.title.FirstOrDefaultAsync(a => a.id == ts.id);
                if(result ! == null)
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
    }
}
