using DataAcessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace student_management.Repositries
{
    public interface ISubjectsRepositriy
    {
        Task<List<subjects>> GetSubjects();
        Task<subjects> GetSubject(int Id);
        Task<string> AddSubject(subjects sr);
        Task<string> UpdateSubject(subjects sr);
        Task<IEnumerable<subjects>> SearchSubject(string name);
        Task<subjects> DeleteSubject(int Id);
    }
}
