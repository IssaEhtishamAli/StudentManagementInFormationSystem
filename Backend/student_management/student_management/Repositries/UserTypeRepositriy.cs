using DataAcessLayer;
using Microsoft.EntityFrameworkCore;
using student_management.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace student_management.Repositries
{
    public class UserTypeRepositriy : IUserTypeRepositriy
    {
        public readonly ApplicationDbContext _Context;
        public UserTypeRepositriy(ApplicationDbContext Context)
        {
            _Context = Context;
        }
        public async Task<object> GetUsersType()
        {
            try
            {
                var result = await _Context.user_type.ToListAsync();
                if (result.Count > 0)
                {
                    return result;
                }
                return "Get userstype data sucessfully";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public async Task<object> GetUserType(int id)
        {
            try
            {
                return await _Context.user_type.FirstOrDefaultAsync(a => a.id == id);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public async Task<object> AddUserType(Usertype user_type)
        {
            try
            {
                await _Context.user_type.AddAsync(user_type);
                await _Context.SaveChangesAsync();
                return "User data added sucesssfully";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public async Task<object> UpdateUserType(Usertype user_type)
        {
            try
            {
                var result = await _Context.user_type.FirstOrDefaultAsync(a => a.id == user_type.id);
                if (result != null)
                {
                    result.type = user_type.type;
                    await _Context.SaveChangesAsync();
                    return "Usertype updated sucessfully";
                }
                return null;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public async Task<object> DeleteUserType(int id)
        {
            try
            {
                var result = await _Context.user_type.Where(a => a.id == id).FirstOrDefaultAsync();
                if (result != null)
                {
                    _Context.user_type.Remove(result);
                    await _Context.SaveChangesAsync();
                    return result;
                }
                return null;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
