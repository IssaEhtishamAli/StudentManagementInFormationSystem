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
    [Route("api/qualifications")]
    [ApiController]
    public class QualificationController : ControllerBase
    {
        private readonly IQualificationRepositriy _qualificationRepositriy;
        public QualificationController(IQualificationRepositriy qualificationRepositriy)
        {
            _qualificationRepositriy = qualificationRepositriy;
        }
        [HttpGet]
        public async Task<object> GetQualification()
        {
            try
            {
                var _data = await _qualificationRepositriy.GetQualification();
                var modl = new
                {
                    statusCode = 200,
                    message = "user qualification details get sucess fully",
                    result = _data
                };
                return Ok(modl);
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
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error in retriving Data from Database");
            }
        }
        [HttpGet("{id:int}")]
        public async Task<object> GetQualificationById(int Id)
        {
            try
            {
                List<object> _getdata = new List<object>(); 
                var _data = await _qualificationRepositriy.GetQualificationById(Id);
                if (_data != null)
                {
                    _getdata.Add(_data);
                    var modl = new
                    {
                        statusCode = 200,
                        message = "user qualification detail get sucessfully",
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
        [HttpPost("addqualification")]
        public async Task<object> AddQualification(qualification qaf)
        {
            try
            {
                var _data = await _qualificationRepositriy.AddQualification(qaf);
                var modl = new
                {
                    statusCode = 200,
                    message = "User qualification details added sucessfully",
                    result = _data
                };
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
                return Ok(modl);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error in retriving Data from Database");
            }
        }
        [HttpPut("updatequalifications")]
        public async Task<object> UpdateQualification(qualification qaf)
        {
            try
            {
                var _data = await _qualificationRepositriy.UpdateQualification(qaf);
                var modl = new
                {
                    statusCode = 200,
                    message = "user qualification details updated sucessfully",
                    result = _data
                };
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
                return Ok(modl);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error in retriving Data from Database");
            }
        }
        [HttpDelete("{id:int}")]
        public async Task<object> DeleteQualification(int Id)
        {
            try
            {
                var _data = await _qualificationRepositriy.DeleteQualification(Id);
                var modl = new
                {
                    statusCode = 200,
                    message = "Delete user qualification details sucess fully"
                };
                if (_data == null)
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
