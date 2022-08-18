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
    [Route("api/teachers")]
    [ApiController]
    public class TeachersController : ControllerBase
    {
        private readonly ITeacherRepositriy _teacherRepositriy;
        public TeachersController(ITeacherRepositriy teacherRepositriy)
        {
            _teacherRepositriy = teacherRepositriy;
        }
       [HttpGet]
       public async Task<object> GetTeachers()
        {
            try
            {
                var _data = await _teacherRepositriy.GetTeachers();
                var modl = new
                {
                    statusCode = 200,
                    message = "Teachers get sucessfully",
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
        [HttpGet("{id:int}")]
        public async Task<object> GetTeacher(int Id)
        {
            try
            {
                List<object> gettd = new List<object>();
                var _data = await _teacherRepositriy.GetTeacher(Id);
                if(_data != null)
                {
                    gettd.Add(_data);
                    var modl = new
                    {
                        statusCode = 200,
                        message = "Teacher get sucessfully",
                        result = gettd
                    };
                    return Ok(modl);
                }
                if (_data == null)
                {
                    var model = new
                    {
                        statusCode = 404,
                        message = "Record not found"
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
        [HttpPost]
        public async Task<object> PostTeacher(Teacher teacher)
        {
            try
            {
                var _data = await _teacherRepositriy.AddTeacher(teacher);
                var modl = new
                {
                    statusCode = 200,
                    message = "Teacher add sucessfully",
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
        public async Task<object> UpdateTeacher(Teacher teacher)
        {
            try
            {
                var _data = await _teacherRepositriy.UpdateTeacher(teacher);
                var modl = new
                {
                    statusCode = 200,
                    message = "Teacher edit sucessfully",
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
        public async Task<object> DeleteTeacher(int id)
        {
            try
            {
                var _data = await _teacherRepositriy.DeleteTeacher(id);
                var modl = new
                {
                    statusCode = 200,
                    message = "Teacher delete sucessfully",
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
