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
    [Route("api/cities")]
    [ApiController]
    public class CitiesController : ControllerBase
    {
        private readonly ICitiesRepositriy _icitiesRepositriy;
        public CitiesController(ICitiesRepositriy citiesRepositriy)
        {
            _icitiesRepositriy = citiesRepositriy;
        }
        [HttpGet]
        public async Task<object> GetCities()
        {
            try
            {
                var _data = await _icitiesRepositriy.GetCities();
                var modl = new
                {
                    statusCode = 200,
                    message = "Cities get sucessfully",
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
        [HttpGet("city")]
        public async Task<object>GetCity(int Id)
        {
            try
            {
                var _data = await _icitiesRepositriy.GetCity(Id);
                var modl = new
                {
                    statusCode = 200,
                    message = "City get sucessfully",
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
        public async Task<object> AddCity(cities ct)
        {
            try
            {
                var _data = await _icitiesRepositriy.AddCity(ct);
                var modl = new
                {
                    statusCode = 200,
                    message = "Add city sucessfully",
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
        public async Task<object>UpdateCity(cities ct)
        {
            try
            {
                var _data = await _icitiesRepositriy.UpdateCity(ct);
                var modl = new
                {
                    statusCode = 200,
                    message = "Updated city sucessfully",
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
        public async Task<object>DeleteCity(int Id)
        {
            try
            {
                var _data = await _icitiesRepositriy.DeleteCity(Id);
                var modl = new
                {
                    statusCode = 200,
                    message = "Delete city sucessfully",
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
