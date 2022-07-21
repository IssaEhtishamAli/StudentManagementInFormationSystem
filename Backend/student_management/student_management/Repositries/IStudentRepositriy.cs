using DataAcessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace student_management.Repositries
{
    public interface IStudentRepositriy
    {
        Task<List<student>> GetStudents();
        Task<student> GetStudent(int Id);
        Task<string> AddStudent(student std);
        Task<string> UpdateStudent(student std);
        Task<IEnumerable<student>> Search(string name);
        Task<student>  DeleteStudent(int Id);

    }
   
}
