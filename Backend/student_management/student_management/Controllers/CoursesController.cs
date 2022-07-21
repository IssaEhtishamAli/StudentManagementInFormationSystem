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
        public async Task<ActionResult<courses>> GetCourses()
        {
            return Ok(await _courseRepositriy.GetCourses());
        }
        [HttpGet("course")]
        public async Task<ActionResult<courses>> GetCourse(int id)
        {
            return await _courseRepositriy.GetCourse(id);

        }
        [HttpPost]
        public async Task<ActionResult<string>> PostCourse(courses cr)
        {
            return await _courseRepositriy.AddCourse(cr);
        }
        [HttpPut("{id:int}")]
        public async Task<ActionResult<string>> UpdateCourse(int id, courses cr)
        {
            await _courseRepositriy.GetCourse(id);
            return await _courseRepositriy.UpdateCourse(cr);
        }
        [HttpDelete("{id:int}")]
        public async Task<ActionResult<courses>> DeleteCourse(int id)
        {
            await _courseRepositriy.GetCourse(id);
            return await _courseRepositriy.DeleteCourse(id);
        }
    }
}
