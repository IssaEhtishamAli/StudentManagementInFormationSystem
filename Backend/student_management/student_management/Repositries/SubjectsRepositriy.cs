using DataAcessLayer;
using Microsoft.EntityFrameworkCore;
using student_management.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace student_management.Repositries
{
    public class SubjectRepositriy : ISubjectsRepositriy
    {
        public readonly ApplicationDbContext _Context;
        public SubjectRepositriy(ApplicationDbContext Context)
        {
            _Context = Context;
        }
        public async Task<List<subjects>> GetSubjects()
        {
            try
            {
                var result = await _Context.subjects.ToListAsync();
                if (result.Count > 0)
                {
                    return result;
                }
                return result;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<subjects> GetSubject(int id)
        {
            try
            {
                return await _Context.subjects.FirstOrDefaultAsync(a => a.id == id);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<string> AddSubject(subjects sr)
        {
            try
            {
                await _Context.subjects.AddAsync(sr);
                await _Context.SaveChangesAsync();
                return "Courses data added sucesssfully";
            }
            catch (Exception ex)
            {

                return ex.Message;
            }
        }
        public async Task<string> UpdateSubject(subjects sr)
        {
            try
            {
                var result = await _Context.subjects.FirstOrDefaultAsync(a => a.id == sr.id);
                if (result != null)
                {

                    result.subject_name = sr.subject_name;

                    await _Context.SaveChangesAsync();
                    return "student updated sucessfully";
                }
                return null;
            }
            catch (Exception ex)
            {

                return ex.Message;
            }
        }

        public async Task<subjects> DeleteSubject(int Id)
        {
            try
            {
                var result = await _Context.subjects.Where(a => a.id == Id).FirstOrDefaultAsync();
                if (result != null)
                {
                    _Context.subjects.Remove(result);
                    await _Context.SaveChangesAsync();
                    return result;
                }
                return null;
            }
            catch (Exception ex)
            {

                throw;
            }

        }
       
        public async Task<IEnumerable<subjects>> SearchSubject(string name)
        {
            IQueryable<subjects> query = _Context.subjects;
            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(a => a.subject_name.Contains(name));
            }
            return await query.ToListAsync();
        }

       
    }
}