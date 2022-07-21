using DataAcessLayer;
using Microsoft.EntityFrameworkCore;
using student_management.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace student_management.Repositries
{
  
        public class StudentRepositriy : IStudentRepositriy
        {
            public readonly ApplicationDbContext _Context;

            public StudentRepositriy(ApplicationDbContext Context)
            {
                _Context = Context;
            }

            public async Task<List<student>> GetStudents()
            {
                try
                {
                    var getData = await _Context.Student.ToListAsync();
                    if(getData.Count > 0)
                    {
                        return getData;

                    }
                    return getData;
                }
                catch(Exception ex)
                {
                return null;
                }
            }
            public async Task<student> GetStudent(int Id)
        {
            return await _Context.Student.FirstOrDefaultAsync(a => a.id == Id);

        }

            public async Task<string> AddStudent(student std)
        {
            try
            {
                await _Context.Student.AddAsync(std);
                await _Context.SaveChangesAsync();
                return "student  added sucessfully";
            }
            catch (Exception ex)
            {

                return ex.Message;
            }

        }

            public async Task<IEnumerable<student>> Search(string name)
            {
                IQueryable<student> query = _Context.Student;
                if (!string.IsNullOrEmpty(name))
                {
                    query = query.Where(a => a.full_name.Contains(name));
                }
                return await query.ToListAsync();
            }

            public async Task<string> UpdateStudent(student std)
            {
            try
            {
                var result = await _Context.Student.FirstOrDefaultAsync(a => a.id == std.id);
                if (result != null)
                {
                    
                    result.full_name = std.full_name;
                    result.father_name = std.father_name;
                    result.cnic_no = std.cnic_no;
                    result.address = std.address;
                    result.contact_no = std.contact_no;
                    result.entry_date_time = std.entry_date_time;
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

            public async Task<student> DeleteStudent(int Id)
        {
            try
            {
                var result = await _Context.Student.Where(a => a.id == Id).FirstOrDefaultAsync();
                if (result != null)
                {
                    _Context.Student.Remove(result);
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






    }

}

