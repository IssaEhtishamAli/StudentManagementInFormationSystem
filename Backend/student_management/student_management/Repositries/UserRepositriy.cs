using DataAcessLayer;
using Microsoft.EntityFrameworkCore;
using student_management.DataContext;
using student_management.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace student_management.Repositries
{
    public class UserRepositriy : IUserRepositriy
    {
        public readonly ApplicationDbContext _Context;

        public UserRepositriy(ApplicationDbContext Context)
        {
            _Context = Context;
        }
        public async Task<object> UserAuthenticate(UserLogin loginDetail)
        {
            try
            {
                var _data = await _Context.users.Where(a => a.email == loginDetail.email && a.password == loginDetail.password).FirstOrDefaultAsync();
                if (_data == null)
                {
                    return _data;
                }
                else
                {
                    var _resulData = (from _users in _Context.users
                                      join _usertype in _Context.user_type on _users.user_type equals _usertype.id
                                      where _users.id==_data.id
                                      select new
                                      {
                                          id = _users.id,
                                          user_name = _users.user_name,
                                          email = _users.email,
                                          user_type = _usertype.type,
                                          status = _users.status

                                      }).FirstOrDefault();
                    return _resulData;
                }
               
              
            }
            catch (Exception ex)
            {
               
                return ex.Message;
            }
        }

        public async Task<object> UpdatePassword(UserPassword userPassword)
        {
            try
            {
                var result = await _Context.users.Where(a => a.email == userPassword.email).FirstOrDefaultAsync();
                if(result != null)
                {
                       result.password = userPassword.password;
                       await _Context.SaveChangesAsync();
                       return "user password updated sucessfully";
                       return result;
                }
                return null;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public async Task<object> GetUsers()
        {
            try
            {
                var result = (from _users in _Context.users
                              join _usertype in _Context.user_type on _users.user_type equals _usertype.id
                              select new
                              {
                                  id = _users.id,
                                  user_name = _users.user_name,
                                  password = _users.password,
                                  email = _users.email,
                                  user_type = _usertype.type,
                                  status=_users.status

                              }).Distinct().ToList();

                if (result.Count > 0)
                {
                    return result;
                }
                return "Get data sucessfully";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public async Task<object> GetUser(int id)
        {
            try
            {
                return await _Context.users.Where(a => a.id == id && a.status == 1).FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public async Task<object> AddUser(User users)
        {
            try
            {
                await _Context.users.AddAsync(users);
                await _Context.SaveChangesAsync();
                return "User data added sucesssfully";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
      
        public async Task<object> UpdateUser(User users)
        {
            try
            {
                var result = await _Context.users.FirstOrDefaultAsync(a => a.id == users.id);
                if (result != null)
                {

                    result.user_name = users.user_name;
                    result.password = users.password;
                    result.email = users.email;
                    result.user_type = users.user_type;
                    result.status = users.status;
                    await _Context.SaveChangesAsync();
                    return "student updated sucessfully";
                }
                return null;
            }
            catch (Exception ex)
            {

                return ex.Message;
            }
        }

        public async Task<object> DeleteUser(int id)
        {
            try
            {
                var getuser = await _Context.users.Where(a => a.id == id).FirstOrDefaultAsync();
                if(getuser != null)
                {
                    //getuser.status = 0;
                    //_Context.users.Update(getuser);
                    _Context.users.Remove(getuser);
                    await _Context.SaveChangesAsync();
                }
                return getuser;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
