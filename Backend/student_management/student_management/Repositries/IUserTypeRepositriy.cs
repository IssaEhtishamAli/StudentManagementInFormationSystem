using DataAcessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace student_management.Repositries
{
    public interface IUserTypeRepositriy
    {
        Task<object> GetUsersType();
        Task<object> GetUserType(int id);
        Task<object> AddUserType(Usertype user_type);
        Task<object> UpdateUserType(Usertype user_type);
        Task<object> DeleteUserType(int id);
    }
}
