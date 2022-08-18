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
    [Route("api/genders")]
    [ApiController]
    public class GenderController : ControllerBase
    {
        private readonly IGenderRepositriy _genderRpositriy;
        public GenderController(IGenderRepositriy genderRepositriy)
        {
            _genderRpositriy = genderRepositriy;
        }
        [HttpGet]
        public async Task<object> GetGender()
        {
            try
            {
                var _data = await _genderRpositriy.GetGender();
                    var modl = new
                    {
                        statusCode = 200,
                        message = "Gender get sucessfully",
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
                return StatusCode(StatusCodes.Status500InternalServerError, "Error in reteriving from database");
            }
        }
        [HttpGet("{id:int}")]
        public async Task<object> GetGenderById(int Id)
        {
            try
            {
                var _data = await _genderRpositriy.GetGenderById(Id);
                var modl = new
                {
                    statusCode = 200,
                    message = "Gender get by id sucessfully",
                    result = _data
                };
                if(_data == null)
                {
                    var model = new
                    {
                        statusCode = 404,
                        message = "Record not found"
                    };
                    return (model);
                }
                return Ok(modl);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error in retriving from database");
            }
        }
        [HttpPost("gender")]
        public async Task<object> AddGender(genders gs)
        {
            try
            {
                var _data = await _genderRpositriy.AddGender(gs);
                var modl = new
                {
                    statusCode = 200,
                    message = "Gender added sucessfully",
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
                return StatusCode(StatusCodes.Status500InternalServerError, "Error in reteriving from database");
            }
        }
        [HttpPut("{id:int}")]
        public async Task<object> UpdateGender(genders gs)
        {
            try
            {
                var _data = await _genderRpositriy.UpdateGender(gs);
                var modl = new
                {
                    statusCode = 200,
                    message = "Update gender sucessfully",
                    result = _data
                };
                if(_data == null)
                {
                    var model = new
                    {
                        statusCode = 404,
                        message = "Recordnot found"
                    };
                    return (model);
                }
                return Ok(modl);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error in reteriving from database");
            }
        }
        [HttpDelete("{id:int}")]
        public async Task<object> DeleteGender(int Id)
        {
            try
            {
                var _data = await _genderRpositriy.DeleteGender(Id);
                var modl = new
                {
                    statusCode = 200,
                    message = "Gender deleted sucessfully",
                    result=_data
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
                return StatusCode(StatusCodes.Status500InternalServerError, "Error in reteriving from database");
            }
        }
    }
}
