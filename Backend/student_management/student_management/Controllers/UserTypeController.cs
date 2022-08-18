using DataAcessLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using student_management.Repositries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace student_management.Controllers
{
    [Route("api/usertype")]
    [ApiController]
    public class UserTypeController : ControllerBase
    {
        private readonly IUserTypeRepositriy _userTypeRepositriy;
        public UserTypeController(IUserTypeRepositriy userTypeRepositriy)
        {
            _userTypeRepositriy = userTypeRepositriy;
        }
        [HttpGet]
        public async Task<object> GetUsersType()
        {
            try
            {
                var _data = await _userTypeRepositriy.GetUsersType();
                if (_data == null)
                {
                    var modl = new
                    {
                        statusCode = 404,
                        message = "Record not found",
                    };
                    return modl;
                }
                else
                {
                    var modl = new
                    {
                        statusCode = 200,
                        message = "Userstype get sucessfully",
                        result = _data
                    };
                    return Ok(modl);
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error in retriving data from database");
            }
            }
        [HttpGet("{id:int}")]
        public async Task<object> GetUserType(int id)
        {
            try { 
            var _data = await _userTypeRepositriy.GetUserType(id);
            if (_data == null)
            {
                var modl = new
                {
                    statusCode = 404,
                    message = "Record not found",
                };
                return modl;
            }
            else
            {
                var modl = new
                {
                    statusCode = 200,
                    message = "Usertype get sucessfully",
                    result = _data
                };
                return Ok(modl);
            }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error in retriving data from database");
            }
        }
        [HttpPost]
        public async Task<object> AddUserType(Usertype user_type)
        {
            try
            {
                var _data = await _userTypeRepositriy.AddUserType(user_type);
                if (_data == null)
                {
                    var modl = new
                    {
                        statusCode = 404,
                        message = "Record not found"
                    };
                    return modl;
                }
                else
                {
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
                return StatusCode(StatusCodes.Status500InternalServerError, "Error in retriving data from database");
            }
        }
        [HttpPut("{id:int}")]
        public async Task<object> UpdateUserType(Usertype user_type)
        {
            try
            {
                var _data = await _userTypeRepositriy.UpdateUserType(user_type);
                if (_data == null)
                {
                    var modl = new
                    {
                        statusCode = 409,
                        message = "Record not found"
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
                return StatusCode(StatusCodes.Status500InternalServerError, "Error in retriving data from database");
            }
        }
        [HttpDelete("{id:int}")]
        public async Task<object> DeleteUser(int id)
        {
            try
            {
                var _data = await _userTypeRepositriy.DeleteUserType(id);
                if (_data == null)
                {
                    var modl = new
                    {
                        statusCode = 404,
                        messsage = "Record not found",
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
                return StatusCode(StatusCodes.Status500InternalServerError, "Error in retriving data from database");
            }
        }
    }
}
