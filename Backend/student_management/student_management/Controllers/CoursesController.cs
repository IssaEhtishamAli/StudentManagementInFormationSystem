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
    [Route("api/courses")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly ICourseRepositriy _courseRepositriy;
        public CoursesController(ICourseRepositriy courseRepositriy)
        {
            _courseRepositriy = courseRepositriy;
        }
        [HttpGet]
        public async Task<object> GetCourses()
        {
            try
            {
                var _data = await _courseRepositriy.GetCourses();
                var modl = new
                {
                    statusCode = 200,
                    message = "Courses get sucessfully",
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
        [HttpGet("district")]
        public async Task<object> GetCourse(int id)
        {
            try
            {
                var _data = await _courseRepositriy.GetCourse(id);
                var modl = new
                {
                    statusCode = 200,
                    message = "Course get sucessfully",
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
        public async Task<object> PostCourse(courses cr)
        {
            try
            {
                var _data = await _courseRepositriy.AddCourse(cr);
                var modl = new
                {
                    statusCode = 200,
                    message = "Course add sucessfully",
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
        public async Task<object> UpdateCourse(courses cr)
        {
            try
            {
                var _data = await _courseRepositriy.UpdateCourse(cr);
                var modl = new
                {
                    statusCode = 200,
                    message = "Course  edit sucessfully",
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
        public async Task<object> DeleteCourse(int id)
        {
            try
            {
                var _data = await _courseRepositriy.DeleteCourse(id);
                var modl = new
                {
                    statusCode = 200,
                    message = "Course are delete sucessfully",
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
