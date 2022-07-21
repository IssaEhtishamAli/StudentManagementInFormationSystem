using DataAcessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace student_management.Repositries
{
    public interface ICourseRepositriy
    {
        Task<object> GetCourses();
        Task<courses> GetCourse(int Id);
        Task<string> AddCourse(courses cr);
        Task<string> UpdateCourse(courses cr);
        Task<courses> DeleteCourse(int Id);
    }
}
