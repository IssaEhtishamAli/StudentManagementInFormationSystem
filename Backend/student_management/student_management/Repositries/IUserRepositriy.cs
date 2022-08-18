using DataAcessLayer;
using student_management.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace student_management.Repositries
{
   public interface IUserRepositriy
    {
        Task<object>GetUsers();
        Task<object> GetUser(int id);
        Task<object>AddUser(User users);
        Task<object>UpdateUser(User users);
        Task<object>DeleteUser(int id);
        Task<object> UserAuthenticate(UserLogin loginDetail);
        Task<object> UpdatePassword(UserPassword userpassword);
    }
}
