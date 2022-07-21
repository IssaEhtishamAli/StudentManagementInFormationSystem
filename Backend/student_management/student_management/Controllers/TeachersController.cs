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
       public async Task<ActionResult<Teacher>> GetTeachers()
        {
            return Ok(await _teacherRepositriy.GetTeachers());
        }
        [HttpGet("teacher")]
        public async Task<ActionResult<Teacher>> GetTeacher(int id)
        {
            var result = await _teacherRepositriy.GetTeacher(id);
            if (result ==null)
            {
                return NotFound();
            }
            return result;
        }
        [HttpPost]
        public async Task<ActionResult<string>> PostTeacher(Teacher teacher)
        {
            return await _teacherRepositriy.AddTeacher(teacher);
        }
        [HttpPut("{id:int}")]
        public async Task<ActionResult<string>> UpdateTeacher(int id,Teacher teacher)
        {
             await _teacherRepositriy.GetTeacher(id);
            return await _teacherRepositriy.UpdateTeacher(teacher);
        }
        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Teacher>> DeleteTeacher(int id)
        {
            await _teacherRepositriy.GetTeacher(id);
            return await _teacherRepositriy.DeleteTeacher(id);
        }
        [HttpGet("{search}") ]
        public async Task<ActionResult<Teacher>> SearchTeacher(string name)
        {
             await _teacherRepositriy.SearchTeaher(name);
            return NotFound();
        }

    }
}
