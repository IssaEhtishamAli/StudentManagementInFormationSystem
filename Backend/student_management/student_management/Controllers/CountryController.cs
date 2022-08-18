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
    [Route("api/country")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        public readonly ICountryRepositriy _countryRepositriy;
        public CountryController(ICountryRepositriy countryRepositriy)
        {
            _countryRepositriy = countryRepositriy;
        }
        [HttpGet]
        public async Task<object> GetCountryies()
        {
            try
            {
                var _data = await _countryRepositriy.GetCountryies();
                var modl = new
                {
                    statusCode = 200,
                    message = "Countryies Get Sucessfully",
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
        [HttpGet("{id:int}")]
        public async Task<object> GetCountryiesById(int id)
        {
            try
            {
                var _data = await _countryRepositriy.GetContryiesById(id);
                var modl = new
                {
                    statusCode = 200,
                    message = "Country reterive get by id sucessfully",
                    result = _data
                };
                return Ok(modl);
                if(_data == null)
                {
                    var model = new
                    {
                        statusCode = 404,
                        message = "Record not found",
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
        public async Task<object> AddCountry(countryies cn)
        {
            try
            {
                var _data = await _countryRepositriy.AddCountry(cn);
                var modl = new
                {
                    statusCode = 200,
                    message = "Country added sucessfully",
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
        public async Task<object> UpdateCountry(countryies cn)
        {
            try
            {
                var _data = await _countryRepositriy.UpdateCountry(cn);
                var modl = new
                {
                    statusCOde = 200,
                    message = "Country updated sucessfully",
                    reult = _data
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
        [HttpDelete]
        public async Task<object> DeleteCountry(int id)
        {
            try
            {
                var _data = await _countryRepositriy.DeleteCountry(id);
                var modl = new
                {
                    statusCode = 200,
                    mssage = "Country deleted sucessfully",
                    result = _data,
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

                throw;
            }
        }
    }
}
