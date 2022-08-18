using DataAcessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace student_management.Repositries
{
    public interface IStudentRepositriy
    {
        Task<object> GetStudents();
        Task<object> GetStudent(int Id);
        Task<object> AddStudent(student std);
        Task<object> UpdateStudent(student std);
        Task<object>  DeleteStudent(int Id);

    }
   
}
