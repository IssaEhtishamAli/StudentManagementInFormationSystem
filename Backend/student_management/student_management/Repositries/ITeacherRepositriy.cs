using DataAcessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace student_management.Repositries
{
    public interface ITeacherRepositriy
    {
        Task<object> GetTeachers();
        Task<object> GetTeacher(int id);
        Task<object> AddTeacher(Teacher teacher);
        Task<object> UpdateTeacher(Teacher teacher);
        Task<object> DeleteTeacher(int Id);
    }
}
