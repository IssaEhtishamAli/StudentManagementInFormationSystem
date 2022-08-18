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
    [Route("api/guardians")]
    [ApiController]
    public class GuardianController : ControllerBase
    {
        private readonly IGuardianRepositriy _guardianRepositriy;
        public GuardianController(IGuardianRepositriy guardianRepositriy)
        {
            _guardianRepositriy = guardianRepositriy;
        }
        [HttpGet]
        public async Task<object> GetGuardian()
        {
            try
            {
                var _data = await _guardianRepositriy.GetGuardian();
                var modl = new
                {
                    statusCode = 200,
                    message = "User guardian details get sucessfully",
                    result = _data
                };
                if(_data == null)
                {
                    var model = new
                    {
                        statusCode = 404,
                        message = "Record not found",
                    };
                    return (model);
                }
                return Ok(modl);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error in retriving Data from Database");
            }
        }
        [HttpGet("{id:int}")]
        public async Task<object> GetGuardianById(int Id)
        {
            try
            {
                List<object> _getgdn = new List<object>();
                var _data = await _guardianRepositriy.GetGuardianById(Id);
                if (_data != null)
                {
                    _getgdn.Add(_data);
                    var modl = new
                    {
                        statusCode = 200,
                        message = "user guardian detail get sucessfully",
                        result = _data
                    };
                    return Ok(modl);
                }
                if (_data == null)
                {
                    var model = new
                    {
                        statusCode = 404,
                        message = "Record not found",
                        result = _data
                    };
                    return (model);
                }
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error in retriving Data from Database");
            }
        }
        [HttpPost("addguardian")]
        public async Task<object> AddGuardian(guardian gdn)
        {
            try
            {
                var _data = await _guardianRepositriy.AddGuardian(gdn);
                var modl = new
                {
                    statusCode=200,
                    message="User guardian details added sucessfully",
                    result=_data
                };
                if(_data == null)
                {
                    var model = new
                    {
                        statusCode = 404,
                        message = "Record not found",
                        result = _data
                    };
                    return (model);
                }
                return Ok(modl);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error in retriving Data from Database");
            }
        }
        [HttpPut("updateguardian")]
        public async Task<object> UpdateGuardian(guardian gdn)
        {
            try
            {
                var _data = await _guardianRepositriy.UpdateGuardian(gdn);
                var modl = new
                {
                    statusCode = 200,
                    message = "user guardians details updated sucessfully",
                    result = _data
                };
                if(_data == null)
                {
                    var model = new
                    {
                        statusCode = 404,
                        message = "Record not found",
                        result = _data
                    };
                    return (model);
                }
                return Ok(modl);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error in retriving Data from Database");
            }
        }
        [HttpDelete]
        public async Task<object> DeleteGuardian(int Id)
        {
            try
            {
                var _data = await _guardianRepositriy.DeleteGuardian(Id);
                var modl = new
                {
                    statusCode = 200,
                    message = "Delete user guardian details sucess fully"
                };
                if(_data == null)
                {
                    var model = new
                    {
                        statusCode = 404,
                        message = "Record not found",
                        result = _data
                    };
                    return (modl);
                }
                return Ok(modl);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error in retriving Data from Database");
            }
        }
    }
}
