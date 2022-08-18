using DataAcessLayer;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using student_management.Repositries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace student_management.Controllers
{
    [Route("api/Students")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentRepositriy _studentRepositriy;
        public StudentsController(IStudentRepositriy studentRepositriy)
        {
            _studentRepositriy = studentRepositriy;
        }
        //coments addd
        #region students get region
        //sasdasdsa
        //sdasdasd
        #endregion
        [HttpGet]
        public async Task<object> GetStudents()
        {
            try
            {
                var _data = await _studentRepositriy.GetStudents();
                var modl = new
                {
                    statusCode = 200,
                    message = "Students get sucessfully",
                    result = _data
                };
                if (_data == null)
                {
                    var model = new
                    {
                        statusCode=404,
                        message="Record not found",
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
        public async Task<object> GetStudent(int Id)
        {
            try
            {
                List<object> getStd = new List<object>();
                var _data = await _studentRepositriy.GetStudent(Id);
                if (getStd != null)
                {
                    getStd.Add(_data);
                    var modl = new
                    {
                        statusCode = 200,
                        message = "Student  get sucessfully",
                        result = getStd
                    };
                    return Ok(modl);

                }               
                if (getStd == null)
                {
                    var model = new
                    {
                        statusCode = 404,
                        message="Record not found"
                    };
                    return Ok(model);
                }
                return Ok();   
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error in retriving data from database");
            }
        }
        [HttpPost("addstudents")]
        public async Task<object> CreateStudent(student std)
        {
            try
            {                
                var _data = await _studentRepositriy.AddStudent(std);
                var modl = new
                {
                    statusCode=200,
                    message="Student  added sucessfully",
                    result= _data
                };
                if (_data == null)
                {
                    var model = new
                    {
                        statusCode = 404,
                        message = "Record not found"
                    };
                    return(model);
                }
                return Ok(modl);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error in retriving data from database");
            }
        }
        [HttpPut("updatestd")]
        public async Task<object> UpdateStudent(student std)
        {
            try
            {
                var _data = await _studentRepositriy.UpdateStudent(std);
                var modl = new
                {
                  statusCode=200,
                  message="Student  edit sucessfully",
                  result=_data
                };
                if (_data == null)
                {
                    var model = new
                    {
                        statusCode = 404,
                        message = "Record not found"
                    };
                    return(model);
                }
                return Ok(modl);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error in retriving data from database");
            }
        }
        [HttpDelete("{id:int}")]
        public async Task<object> DeleteStudent(int id)
        {
            try
            {
                var _data = await _studentRepositriy.DeleteStudent(id);
                var modl = new
                {
                  statusCode=200,
                  message="Student  deleted sucessfully",
                  result=_data
                };
                if (_data == null)
                {
                    //return NotFound($"Student Id={id} not found");
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
                return StatusCode(StatusCodes.Status500InternalServerError, "Error in retriving data from database");
            }
        }
    }

}