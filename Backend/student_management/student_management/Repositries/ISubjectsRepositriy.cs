using DataAcessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace student_management.Repositries
{
    public interface ISubjectsRepositriy
    {
        Task<object> GetSubjects();
        Task<object> GetSubject(int Id);
        Task<object> AddSubject(subjects sr);
        Task<object> UpdateSubject(subjects sr);
        Task<object> DeleteSubject(int Id);
    }
}
