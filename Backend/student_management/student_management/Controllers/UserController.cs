using DataAcessLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using student_management.Model;
using student_management.Repositries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace student_management.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepositriy _userRepositriy;
        public UserController(IUserRepositriy userRepositriy)
        {
            _userRepositriy = userRepositriy;
        }
        [HttpGet]
        public async Task<object> GetUsers()
        {
            try
            {
                var _data = await _userRepositriy.GetUsers();
                if (_data == null)
                {
                    var modl = new
                    {
                        statusCode = 409,
                        message = "Invalid email",
                        result = _data
                    };
                    return modl;
                }
                else
                {
                    var modl = new
                    {
                        statusCode = 200,
                        message = "Users get sucessfully",
                        result = _data
                    };
                    return Ok(modl);
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error in retriving Data from Database");
            }
        }
        [HttpGet("{id:int}")]
        public async Task<object> GetUser(int id)
        {
            try
            {
                var _data = await _userRepositriy.GetUser(id);
                if (_data == null)
                {
                    var modl = new
                    {
                        statusCode = 409,
                        message = "Invalid email",
                        result = _data
                    };
                    return modl;
                }
                else
                {
                    var modl = new
                    {
                        statusCode = 200,
                        message = "User get sucessfully",
                        result = _data
                    };
                    return Ok(modl);
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error in retriving Data from Database");
            }
        }
        [HttpPost("Login")]
        public async Task<object> UserAuthenticate(UserLogin loginDetail)
        {
            try
            {
                var _data = await _userRepositriy.UserAuthenticate(loginDetail);
                if (_data == null)
                {
                    var modl = new
                    {
                        statusCode = 409,
                        message = "Internal server error",
                    };
                    return modl;
                }
                else
                {
                    var modl = new
                    {
                        statusCode = 200,
                        message = "Login sucessfully",
                        result = _data
                    };
                    return Ok(modl);
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error in retriving Data from Database");
            }
        }
        [HttpPut("password")]
        public async Task<object> UpdatePassword(UserPassword userPassword)
        {
            try
            {
                var _data = await _userRepositriy.UpdatePassword(userPassword);
                if (_data == null)
                {
                    var modl = new
                    {
                        statusCode = 409,
                        message = "Invalid email",
                        result = _data
                    };
                    return modl;
                }
                else
                {
                    var modl = new
                    {
                        statusCode = 200,
                        message = "User password is updated sucessfully",
                        result = _data
                    };
                    return Ok(modl);
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error in retriving Data from Database");
            }
        }
       
        [HttpPost]
        public async Task<object> AddUser(User users)
        {
            try
            {
                users.status = 1; //1 means default is always active. To deactivate coordinate with DBA.
                var _data = await _userRepositriy.AddUser(users);
                if (_data == null)
                {
                    var modl = new
                    {
                        statusCode = 409,
                        message = "Invalid email",
                        result = _data
                    };
                    return modl;
                }
                else{
                    var modl = new
                    {
                        statusCode = 200,
                        message = "Add User sucessfully",
                        result = _data
                    };
                    return Ok(modl);
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error in retriving Data from Database");
            }
        }
        [HttpPut("{id:int}")]
        public async Task<object> UpdateUser(User users)
        {
            try
            {
                var _data = await _userRepositriy.UpdateUser(users);
                if (_data == null)
                {
                    var modl = new
                    {
                        statusCode = 409,
                        message = "Invalid email",
                        result = _data
                    };
                    return modl;
                }
                else
                {
                    var modl = new
                    {
                        statusCode = 200,
                        message = "Update user sucessfully",
                        result = _data
                    };
                    return Ok(modl);
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error in retriving Data from Database");
            }
        }
        [HttpDelete("{id:int}")]
        public async Task<object> DeleteUser(int id)
        {
            try
            {
                var _data = await _userRepositriy.DeleteUser(id);
                if (_data == null)
                {
                    var modl = new
                    {
                        statusCode = 409,
                        message = "Invalid email",
                        result = _data
                    };
                    return modl;
                }
                else
                {
                    var modl = new
                    {
                        statusCode = 200,
                        message = "Delete user sucesssfully",
                        result = _data
                    };
                    return Ok(modl);
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error in retriving Data from Database");
            }
        }
    }
}
