using DataAcessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace student_management.Repositries
{
    public interface IGuardianRepositriy
    {
        Task<object> GetGuardian();
        Task<object> GetGuardianById(int Id);
        Task<object> AddGuardian(guardian gdn);
        Task<object> UpdateGuardian(guardian gdn);
        Task<object> DeleteGuardian(int  id);
    }
}
