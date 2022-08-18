using DataAcessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace student_management.Repositries
{
   public interface IUserProfileRepositriy
    {
        Task<object> GetProfile();
        Task<object> GteProfileById(int Id);
        Task<object> AddProfile(userprofile urp);
        Task<object> UpdateProfile(userprofile urp);
        Task<object> DeleteProfile(int Id);
    }
}
