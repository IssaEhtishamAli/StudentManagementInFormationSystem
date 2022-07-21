using DataAcessLayer;
using Microsoft.EntityFrameworkCore;
using student_management.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace student_management.Repositries
{
    public class CourseRepositriy : ICourseRepositriy
    {
        public readonly ApplicationDbContext _Context;
        public CourseRepositriy(ApplicationDbContext Context)
        {
            _Context = Context;
        }
        public async Task<object> GetCourses()
        {
            try
            {
                //var result = await _Context.courses.ToListAsync();
                var result = (from _course in _Context.courses
                                 //join _teacher in _Context.teacher on _course.teacher_id equals _teacher.id into teacherDetail
                                 //join _student in _Context.Student on _course.student_id equals _student.id into studentDetail
                                 //from t in teacherDetail.DefaultIfEmpty()
                                 //from s in studentDetail.DefaultIfEmpty()
                             join _teacher in _Context.teacher on _course.teacher_id equals _teacher.id 
                             join _student in _Context.Student on _course.student_id equals _student.id
                             join _subject in _Context.subjects on _course.subject_id equals _subject.id
                              //from t in teacherDetail.DefaultIfEmpty()
                              //from s in studentDetail.DefaultIfEmpty()
                              select new
                                {
                                    id = _course.id,
                                    teacher_id = _course.teacher_id,
                                    teacher_name= _teacher.teacher_name,
                                    student_id = _course.student_id,
                                    student_name = _student.full_name,
                                    subject_id = _subject.id,
                                    subject_name = _subject.subject_name


                                }).Distinct().ToList();
                if (result !=null)
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

                throw ex;
            }
        }

        
        public async Task<courses> GetCourse(int id)
        {
            try
            {
                return await _Context.courses.FirstOrDefaultAsync(a => a.id == id);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<string> AddCourse(courses cr)
        {
            try
            {
                await _Context.courses.AddAsync(cr);
                await _Context.SaveChangesAsync();
                return "course added sucessfully";
            }
            catch (Exception ex)
            {

                return ex.Message;
            }
        }
        public async Task<string> UpdateCourse(courses cr)
        {
            try
            {
                var result = await _Context.courses.FirstOrDefaultAsync(a => a.id == cr.id);
                if (result != null)
                {

                    result.teacher_id = cr.teacher_id;
                    result.subject_id = cr.subject_id;
                    result.student_id = cr.student_id;
                    await _Context.SaveChangesAsync();
                    return "Courses updated sucessfully";
                }
                return null;
            }
            catch (Exception ex)
            {

                return ex.Message;
            }
        }

        public async Task<courses> DeleteCourse(int Id)
        {
            try
            {
                var result = await _Context.courses.Where(a => a.id == Id).FirstOrDefaultAsync();
                if (result != null)
                {
                    _Context.courses.Remove(result);
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



    }
}
