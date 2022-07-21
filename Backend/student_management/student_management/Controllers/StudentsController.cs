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

       

        [HttpGet]

        public async Task<ActionResult<student>> GetStudents()
        {

            try
            {
                return Ok(await _studentRepositriy.GetStudents());

            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error in retriving Data from Database");
            }
        }
        [HttpGet("student")]
        public async Task<ActionResult<student>> GetStudent(int id)
        {


            try
            {
                var result = await _studentRepositriy.GetStudent(id);
                if (result == null)
                {
                    return NotFound();
                }
                return result;

            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error in retriving Data from Database");
            }
        }

        [HttpPost]
        public async Task<ActionResult<string>> CreateStudent(student std)
        {
            try
            {
                if (std == null)
                {
                    return BadRequest();
                }
                var result = await _studentRepositriy.AddStudent(std);
                return result;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<string>> UpdateStudent(int id, student std)
        {
            try
            {
                if (id != std.id)
                {
                    return BadRequest("Id MisMatch");
                }
                var employeeUpdate = await _studentRepositriy.GetStudent(id);
                if (employeeUpdate == null)
                {
                    return NotFound($"Employee Id={id} not found");
                }
                return await _studentRepositriy.UpdateStudent(std);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return Ok();
        }
        [HttpDelete("{id:int}")]
        public async Task<ActionResult<student>> DeleteStudent(int id)
        {
            try
            {

                var employeeDelete = await _studentRepositriy.GetStudent(id);
                if (employeeDelete == null)
                {
                    return NotFound($"Employee Id={id} not found");
                }
                return await _studentRepositriy.DeleteStudent(id);
            }
            catch (Exception)
            {

                throw;
            }
            return Ok();
        }

        [HttpGet("{search}")]
        public async Task<ActionResult<student>> Search(string name)
        {
            try
            {

                var result = await _studentRepositriy.Search(name);
                if (result.Any())
                {
                    return Ok(result);
                }
                return NotFound();
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error in Retriving Data from Database");
            }
        }
    }

}