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
    [Route("api/titles")]
    [ApiController]
    public class UserTitleController : ControllerBase
    {
        private readonly ITitleRepositriy _titleRepositriy;
        public UserTitleController(ITitleRepositriy titleRepositriy)
        {
            _titleRepositriy = titleRepositriy;
        }
        [HttpGet]
        public async Task<object> GetTitle()
        {
            try
            {
                var _data = await _titleRepositriy.GetTitle();
                var modl = new
                {
                    statusCode = 200,
                    message = "Title get sucessfully",
                    result = _data
                };
                if(_data == null)
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
                return StatusCode(StatusCodes.Status500InternalServerError, "Error in reteriving from database");
            }
        }
        [HttpGet("{id:int}")]
        public async Task<object> GetTitleById(int Id)
        {
            try
            {
                var _data = await _titleRepositriy.GetTitleById(Id);
                var modl = new
                {
                    statuCode = 200,
                    message = "Get title get by id sucessfully",
                    result = _data
                };
                if(_data == null)
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
                return StatusCode(StatusCodes.Status500InternalServerError, "Error in reteriving from database");
            }
        }
        [HttpPost("gender")]
        public async Task<object> AddTitle(titles ts)
        {
            try
            {
                var _data = await _titleRepositriy.AddTitle(ts);
                var modl = new
                {
                    statusCode = 22,
                    message = "Title added sucessfully",
                    result = _data
                };
                if(_data == null)
                {
                    var model = new
                    {
                        statusCode = 404,
                        message = "Record not found",
                    };
                    return (modl);
                }
                return (modl);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error in reteriving from database");
            }
        }
        [HttpPut("{id:int}")]
        public async Task<object> UpdateTitle(titles ts)
        {
            try
            {
                var _data = await _titleRepositriy.UpdateTitle(ts);
                var modl = new
                {
                    statuCode = 22,
                    message = "Title updated sucessfully",
                    result = _data
                };
                if(_data == null)
                {
                    var model = new
                    {
                        statusCode = 404,
                        message = "Record not found"
                    };
                    return (model);
                }
                return (modl);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error in reteriving from database");
            }
        }
        [HttpDelete("{id:int}")]
        public async Task<object> TitleDelete(int Id)
        {
            try
            {
                var _data = await _titleRepositriy.DeleteTitle(Id);
                var modl = new
                {
                    statuCode = 200,
                    message = "Title deleted sucessfully",
                    result = _data
                };
                if(_data == null)
                {
                    var model = new
                    {
                        statusCode = 404,
                        message = "Record not found"
                    };
                    return (model);
                }
                return (modl);

            }
            catch (Exception)
            {
               return StatusCode(StatusCodes.Status500InternalServerError, "Error in reteriving from database");
            }
        }
    }
}
