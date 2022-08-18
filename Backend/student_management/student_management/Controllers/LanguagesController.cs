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
    [Route("api/language")]
    [ApiController]
    public class LanguagesController : ControllerBase
    {
        private readonly ILanguagesRepositriy _languagesRepositriy;
        public LanguagesController(ILanguagesRepositriy languagesRepositriy)
        {
            _languagesRepositriy = languagesRepositriy;
        }
        [HttpGet]
        public async Task<object> Getguardiandetails()
        {
            try
            {
                var _data = await _languagesRepositriy.Getlanguagedetail();
                var modl = new
                {
                    statusCode = 200,
                    messsage = "User language details reterive sucessfully",
                    result = _data
                };
                return Ok(modl);
                if (_data == null)
                {
                    var model = new
                    {
                        statusCode = 404,
                        message = "Record not found"
                    };
                    return (model);
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error in retriving Data from Database");
            }
        }
        [HttpGet("{id:int}")]
        public async Task<object> Getlanguagedetailsbyid(int id)
        {
            try
            {
                var _data = await _languagesRepositriy.Getlanguagebyid(id);
                var modl = new
                {
                    statusCode = 200,
                    message = "User language detail reterive sucessfully",
                    result = _data
                };
                return Ok(modl);
                if (_data == null)
                {
                    var model = new
                    {
                        statusCode = 404,
                        message = "Record not found"
                    };
                    return (model);
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error in retriving Data from Database");
            }
        }
        [HttpPost]
        public async Task<object> Postguardiandetails(languages lang)
        {
            try
            {
                var _data = await _languagesRepositriy.Postlanguagedetail(lang);
                var modl = new
                {
                    statusCode = 200,
                    message = "User language details save sucessfully",
                    resut = _data
                };
                return Ok(modl);
                if (_data == null)
                {
                    var model = new
                    {
                        statusCode = 404,
                        message = "Record not found"
                    };
                    return (model);
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error in retriving Data from Database");
            }
        }
        [HttpPut("updatelanguage")]
        public async Task<object> Updatelanguagedetail(languages lang)
        {
            try
            {
                var _data = await _languagesRepositriy.Updatelanguagedetail(lang);
                var modl = new
                {
                    statusCode = 200,
                    message = "Update user language details sucessfully",
                    result = _data
                };
                return Ok(modl);
                if (_data != null)
                {
                    var model = new
                    {
                        statusCode = 404,
                        message = "Record not found"
                    };
                    return (modl);
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error in retriving Data from Database");
            }
        }
        [HttpDelete("{id:int}")]
        public async Task<object> Deleteguardiandetail(int id)
        {
            try
            {
                var _data = await _languagesRepositriy.Deletlanguagedetail(id);
                var modl = new
                {
                    statusCode = 200,
                    message = "User language details deleted sucessfully",
                    result = _data
                };
                return Ok(modl);
                if (_data == null)
                {
                    var model = new
                    {
                        statusCode = 404,
                        message = "Record not found"
                    };
                    return (modl);
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error in retriving Data from Database");
            }
        }
    }
}
