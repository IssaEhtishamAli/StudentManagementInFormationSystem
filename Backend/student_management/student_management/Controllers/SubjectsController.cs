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
        public async Task<ActionResult<subjects>> GetSubjects()
        {
            return Ok(await _subjectsRepositriy.GetSubjects());
        }
        [HttpGet("subject")]
        public async Task<ActionResult<subjects>> GetSubject(int id)
        {
            return await _subjectsRepositriy.GetSubject(id);

        }
        [HttpPost]
        public async Task<ActionResult<string>> PostCourse(subjects sr)
        {
            return await _subjectsRepositriy.AddSubject(sr);
        }
        [HttpPut("{id:int}")]
        public async Task<ActionResult<string>> UpdateSubject(int id, subjects sr)
        {
            await _subjectsRepositriy.GetSubject(id);
            return await _subjectsRepositriy.UpdateSubject(sr);
        }
        [HttpDelete("{id:int}")]
        public async Task<ActionResult<subjects>> DeleteSubject(int id)
        {
            await _subjectsRepositriy.GetSubject(id);
            return await _subjectsRepositriy.DeleteSubject(id);
        }
    }
}

