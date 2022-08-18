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
    [Route("api/degrees")]
    [ApiController]
    public class DegreesController : ControllerBase
    {
        private readonly IDegreeRepositriy _degreeRepositriy;
        public DegreesController(IDegreeRepositriy degreeRepositriy)
        {
            _degreeRepositriy = degreeRepositriy;
        }
        [HttpGet]
        public async Task<object> GetDegree()
        {
            try
            {
                var _data = await _degreeRepositriy.GetDegree();
                var modl = new
                {
                    statusCode = 200,
                    message = "Degree get sucessfully",
                    result = _data
                };
                if (_data == null)
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
                return StatusCode(StatusCodes.Status500InternalServerError, "Error in retriving Data from Database");
            }
        }
        [HttpGet("degree")]
        public async Task<object>GetDegree(int id)
        {
            try
            {
                var _data = await _degreeRepositriy.GetDegree(id);
                var modl = new
                {
                    statusCode = 200,
                    message = "Degree get sucessfully",
                    result = _data
                };
                if (_data == null)
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
                return StatusCode(StatusCodes.Status500InternalServerError, "Error in retriving Data from Database");
            }
        }
        [HttpPost]
        public async Task<object>PostDegree(degree deg)
        {
            try
            {
                var _data = await _degreeRepositriy.AddDegree(deg);
                var modl = new
                {
                    statusCode = 200,
                    message = "Degree Added sucessfully",
                    result = _data
                };
                if (_data == null)
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
                return StatusCode(StatusCodes.Status500InternalServerError, "Error in retriving Data from Database");
            }
        }
        [HttpPut("{id:int}")]
        public async Task<object> UpdateDegree(degree deg)
        {
            try
            {
                var _data = await _degreeRepositriy.UpdateDegree(deg);
                var modl = new
                {
                    statusCode = 200,
                    message = "Degree updated sucessfully",
                    result = _data
                };
                if (_data == null)
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
                return StatusCode(StatusCodes.Status500InternalServerError, "Error in retriving Data from Database");
            }
        }
        [HttpDelete("{id:int}")]
        public async Task<object>DeleteDegree(int id)
        {
            try
            {
                var _data = await _degreeRepositriy.DeleteDegree(id);
                var modl = new
                {
                    statusCode = 200,
                    message = "Delete data sucessfully",
                    result = _data
                };
                if (_data == null)
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
                return StatusCode(StatusCodes.Status500InternalServerError, "Error in retriving Data from Database");
            }
        }
    }
}
