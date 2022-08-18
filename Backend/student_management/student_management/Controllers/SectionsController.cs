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
    [Route("api/sections")]
    [ApiController]
    public class SectionsController : ControllerBase
    {
        private readonly ISectionsRepositriy _sectionsRepositriy;
        public SectionsController(ISectionsRepositriy sectionsRepositriy)
        {
            _sectionsRepositriy = sectionsRepositriy;
        }
        [HttpGet]
        public async Task<object> GetSections()
        {
            try
            {
                var _data = await _sectionsRepositriy.GetSections();
                var modl = new
                {
                    statusCode = 200,
                    message = "Sections get sucessfully",
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
        [HttpGet("cities")]
        public async Task<object> GetSection(int Id)
        {
            try
            {
                var _data = await _sectionsRepositriy.GetSection(Id);
                var modl = new
                {
                    statusCode = 200,
                    message = "Section get sucessfully",
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
        [HttpPost]
        public async Task<object> AddSection(sections sec)
        {
            try
            {
                var _data = await _sectionsRepositriy.AddSection(sec);
                var modl = new
                {
                    statusCode = 200,
                    message = "Section added sucessfully",
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
        public async Task<object>UpdateSection(sections sec)
        {
            try
            {
                var _data = await _sectionsRepositriy.UpdateSection(sec);
                var modl = new
                {
                    statusCode = 200,
                    message = "Section updated sucessfully",
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
        public async Task<object>DeleteSection(int Id)
        {
            try
            {
                var _data = await _sectionsRepositriy.DeleteSection(Id);
                var modl = new
                {
                    statusCode = 200,
                    message = "Section deleted sucessfully",
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
