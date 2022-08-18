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
    [Route("api/subjects")]
    [ApiController]
    public class SubjectsController : ControllerBase
    {
        private readonly ISubjectsRepositriy _subjectsRepositriy;
        public SubjectsController(ISubjectsRepositriy subjectsRepositriy)
        {
            _subjectsRepositriy = subjectsRepositriy;
        }
        [HttpGet]
        public async Task<object> GetSubjects()
        {
            try
            {
                var _data = await _subjectsRepositriy.GetSubjects();
                var modl = new
                {
                    statusCode = 200,
                    message = "Subjects get sucessfullt",
                    result = _data
                };
                if (_data == null)
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
        [HttpGet("subject")]
        public async Task<ActionResult<subjects>> GetSubject(int id)
        {
            try
            {
                var _data = await _subjectsRepositriy.GetSubject(id);
                var modl = new
                {
                    statusCode = 200,
                    message = "Subject get sucessfully",
                    result = _data
                };
                if (_data == null)
                {
                    var model = new
                    {
                        statusCode = 404,
                        message = "Record not found",
                    };
                    return Ok(model);
                }
                return Ok(modl);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error in retriving Data from Database");
            }
        }
        [HttpPost]
        public async Task<object> PostCourse(subjects sr)
        {
            try
            {
                var _data = await _subjectsRepositriy.AddSubject(sr);
                var modl = new
                {
                    statusCode = 200,
                    message = "Subject add sucessfully",
                    result = _data
                };
                if (_data == null)
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
        [HttpPut("{id:int}")]
        public async Task<object> UpdateSubject( subjects sr)
        {
            try
            {
                var _data = await _subjectsRepositriy.UpdateSubject(sr);
                var modl = new
                {
                    statusCode = 200,
                    message = "Subject edit sucessfully",
                    result = _data
                };
                if (_data == null)
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
        [HttpDelete("{id:int}")]
        public async Task<object> DeleteSubject(int id)
        {
            try
            {
                var _data = await _subjectsRepositriy.DeleteSubject(id);
                var modl = new
                {
                    statusCode = 200,
                    message = "Subject  deleted sucessfully",
                    result = _data
                };
                if (_data == null)
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
    }
}

