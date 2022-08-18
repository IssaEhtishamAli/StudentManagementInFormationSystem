using DataAcessLayer;
using Microsoft.EntityFrameworkCore;
using student_management.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace student_management.Repositries
{
    public class LanguageRepositriy :ILanguagesRepositriy
    {
        private readonly ApplicationDbContext _Context;
        public LanguageRepositriy(ApplicationDbContext Context)
        {
            _Context = Context;
        }
        public async Task<object> Getlanguagebyid(int id)
        {
            try
            {
                var result = await _Context.language.FirstOrDefaultAsync(a => a.id == id);
                if (result != null)
                {
                    return result;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public async Task<object> Getlanguagedetail()
        {
            try
            {
                var result = await _Context.language.ToListAsync();
                if (result.Count > 0)
                {
                    return result;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public async Task<object> Postlanguagedetail(languages lang)
        {
            try
            {
                await _Context.language.AddAsync(lang);
                await _Context.SaveChangesAsync();
                return "Language detail save sucessfully";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public async Task<object> Updatelanguagedetail(languages lang)
        {
            try
            {
                var result = await _Context.language.FirstOrDefaultAsync(a => a.id == lang.id);
                if (result != null)
                {
                    result.language_name = lang.language_name;
                    await _Context.SaveChangesAsync();
                    return "Language details updated sucessfull";
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public async Task<object> Deletlanguagedetail(int id)
        {
            try
            {
                var result = await _Context.language.Where(a => a.id == id).FirstOrDefaultAsync();
                if (result != null)
                {
                    _Context.language.Remove(result);
                    await _Context.SaveChangesAsync();
                    return "Language detail deleted sucessfully";
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

    }
}
