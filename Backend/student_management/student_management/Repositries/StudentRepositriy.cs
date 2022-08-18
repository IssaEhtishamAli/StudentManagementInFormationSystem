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
            public async Task<object> GetStudents()
            {
            try{ 
            var result = (
                    from _student in _Context.Student
                          join _degree in _Context.degree on _student.degree_id equals _degree.id
                          join _cities in _Context.cities on _student.city_id equals _cities.id
                          join _section in _Context.section on _student.section_id equals _section.id
                          join _user in _Context.users on _student.user_id equals _user.id
                          //where _user.id == _student.id
                    select new
                          {
                              id = _student.id,
                              roll_no = _student.roll_no,
                              full_name = _student.full_name,
                              father_name = _student.father_name,
                              address = _student.address,
                              cnic_no = _student.cnic_no,
                              contact_no = _student.contact_no,
                              entry_date_time = _student.entry_date_time,
                              degree_id = _student.degree_id,
                              degree_title = _degree.degree_title,
                              city_id = _student.city_id,
                              city = _cities.city,
                              section_id = _section.id,
                              user_id = _user.id,
                              email=_user.email,
                              section_name = _section.section_name,
                          }
                         ).Distinct().ToList();
            if (result == null)
            {
                return null;
            }
            else
            {
                return result;
            }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            }
            public async Task<object> GetStudent(int Id)
            {
            try
            {
                //return await _Context.Student.FirstOrDefaultAsync(a => a.user_id == Id);
                var result=(
                    from _student in _Context.Student
                    join _degree in _Context.degree on _student.degree_id equals _degree.id
                    join _cities in _Context.cities on _student.city_id equals _cities.id
                    join _section in _Context.section on _student.section_id equals _section.id
                    join _user in _Context.users on _student.user_id equals _user.id
                    where _student.user_id == Id
                    select new
                    {
                        id = _student.id,
                        roll_no = _student.roll_no,
                        full_name = _student.full_name,
                        father_name = _student.father_name,
                        address = _student.address,
                        cnic_no = _student.cnic_no,
                        contact_no = _student.contact_no,
                        entry_date_time = _student.entry_date_time,
                        degree_id = _student.degree_id,
                        degree_title = _degree.degree_title,
                        city_id = _student.city_id,
                        city = _cities.city,
                        section_id = _section.id,
                        user_id = _user.id,
                        email = _user.email,
                        section_name = _section.section_name,
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
            public async Task<object> AddStudent(student std)
            {
            try
            {
                var _getstd = _Context.Student.Where(a => a.roll_no == std.roll_no).FirstOrDefault();
                if (_getstd != null)
                {
                    var modl = new
                    {
                      statusCode=409,
                      message="This rollno is already taken  student",
                      result=_getstd
                    };
                }
                else
                {
                    await _Context.Student.AddAsync(std);
                    await _Context.SaveChangesAsync();
                }
                return "student  added sucessfully";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            }
            public async Task<object> UpdateStudent(student std)
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
                    result.degree_id = std.degree_id;
                    result.city_id = std.city_id;
                    result.section_id = std.section_id;
                    result.user_id = std.user_id;
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
            public async Task<object> DeleteStudent(int Id)
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
                return ex.Message;
            }
        }
    }
}

