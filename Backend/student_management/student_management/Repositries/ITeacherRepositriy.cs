using DataAcessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace student_management.Repositries
{
    public interface ITeacherRepositriy
    {
        Task<List<Teacher>> GetTeachers();
        Task<Teacher> GetTeacher(int id);
        Task<string> AddTeacher(Teacher teacher);
        Task<string> UpdateTeacher(Teacher teacher);
        Task<IEnumerable<Teacher>> SearchTeaher(string name);
        Task<Teacher> DeleteTeacher(int Id);
    }
}
