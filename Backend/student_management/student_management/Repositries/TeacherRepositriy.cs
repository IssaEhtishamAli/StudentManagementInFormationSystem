using DataAcessLayer;
using Microsoft.EntityFrameworkCore;
using student_management.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace student_management.Repositries
{
    public class TeacherRepositriy : ITeacherRepositriy
    {
        public readonly ApplicationDbContext _Context;
        public TeacherRepositriy(ApplicationDbContext Context)
        {
           _Context = Context;
        }
        public async Task<List<Teacher>> GetTeachers()
        {
            try
            {
                var result = await _Context.teacher.ToListAsync();
                if (result.Count > 0)
                {
                    return result;
                }
                return result;
            }
            catch (Exception ex)
            {

                return null;
            }
        }

        public async Task<Teacher> GetTeacher(int id)
        {
            try
            {
                return await _Context.teacher.FirstOrDefaultAsync(a => a.id == id);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<string> AddTeacher(Teacher teacher)
        {
            try
            {
                await _Context.teacher.AddAsync(teacher);
                await _Context.SaveChangesAsync();
                return "Teacher data added sucesssfully";
            }
            catch (Exception ex)
            {

                return ex.Message;
            }
        }
        public async Task<string> UpdateTeacher(Teacher teacher)
        {
            try
            {
                var result = await _Context.teacher.FirstOrDefaultAsync(a => a.id == teacher.id);
                if (result !=null)
                {

                    result.teacher_name = teacher.teacher_name;
                    result.cnic_no = teacher.cnic_no;
                    result.address = teacher.address;
                    result.description = teacher.description;
                    result.contact_no = teacher.contact_no;
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

        public async Task<Teacher> DeleteTeacher(int Id)
        {
            try
            {
                var result = await _Context.teacher.Where(a => a.id == Id).FirstOrDefaultAsync();
                if (result != null)
                {
                    _Context.teacher.Remove(result);
                    await _Context.SaveChangesAsync();
                    return result;
                }
                return null;
            }
            catch (Exception)
            {

                throw;
            }
       
        }

        public async Task<IEnumerable<Teacher>> SearchTeaher(string name)
        {
            IQueryable<Teacher> query = _Context.teacher;
            if (! string.IsNullOrEmpty(name))
            {
                query = query.Where(a => a.teacher_name.Contains(name));
            }
            return await query.ToListAsync();
        }

    }
}
