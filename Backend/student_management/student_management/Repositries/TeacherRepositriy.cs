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
        public async Task<object> GetTeachers()
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
                return ex.Message;
            }
        }
        public async Task<object> GetTeacher(int Id)
        {
            try
            {
                //return await _Context.teacher.FirstOrDefaultAsync(a => a.id == id);
                var result = (
                    from _teacher in _Context.teacher
                    join _user in _Context.users on _teacher.user_id equals _user.id
                    where _teacher.user_id == Id
                    select new
                    {
                        id = _teacher.id,
                        teacher_name = _teacher.teacher_name,
                        cnic_no = _teacher.cnic_no,
                        address = _teacher.address,
                        description = _teacher.description,
                        contact_no = _teacher.contact_no,
                        user_id = _user.id,
                        email = _user.email
                    }
                    ).FirstOrDefault();
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

        public async Task<object> AddTeacher(Teacher teacher)
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
        public async Task<object> UpdateTeacher(Teacher teacher)
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
        public async Task<object> DeleteTeacher(int Id)
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
            catch (Exception ex)
            {
                return ex.Message;
            }
       
        }
    }
}
