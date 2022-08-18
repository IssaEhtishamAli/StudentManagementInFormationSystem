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
        Task<object> GetCourse(int Id);
        Task<object> AddCourse(courses cr);
        Task<object> UpdateCourse(courses cr);
        Task<object> DeleteCourse(int Id);
    }
}
