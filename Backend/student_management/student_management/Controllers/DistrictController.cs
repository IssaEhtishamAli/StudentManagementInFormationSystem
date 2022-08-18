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
    [Route("api/districts")]
    [ApiController]
    public class DistrictController : ControllerBase
    {
        private readonly IDistrictRepositriy _districtRepositriy;
        public DistrictController(IDistrictRepositriy districtRepositriy)
        {
            _districtRepositriy = districtRepositriy;
        }
        [HttpGet]
        public async Task<object> GetDistrict()
        {
            try
            {
                var _data = await _districtRepositriy.GetDistrict();
                var modl = new
                {
                    statusCode = 200,
                    message = "District reterive sucessfully",
                    result=_data
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
            catch (Exception )
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error in retriving Data from Database");
            }
        }
        [HttpGet("{id:int}")]
        public async Task<object>GetDistrictById(int Id)
        {
            try
            {
                var _data = await _districtRepositriy.GetDistrictById(Id);
                var modl = new
                {
                    statusCode = 200,
                    message = "Distrcit reterive by id sucessfully",
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
                return StatusCode(StatusCodes.Status500InternalServerError, "Error in retriving Data from Database");
            }
        }
        [HttpPost]
        public async Task<object> AddDistrict(districts ds)
        {
            try
            {
                var _data = await _districtRepositriy.AddDistrict(ds);
                var modl = new
                {
                    statusCode = 200,
                    message = "Disctrict add sucessfully",
                    result=_data
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
            catch (Exception )
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error in retriving Data from Database");
            }
        }
        [HttpPut("{id:int}")]
        public async Task<object> UpdateDistrict(districts ds)
        {
            try
            {
                var _data = await _districtRepositriy.UpdateDistrict(ds);
                var modl = new
                {
                    statusCode = 200,
                    message = "District updated sucessfully",
                    result=_data
                };
                if (_data == null)
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
                return StatusCode(StatusCodes.Status500InternalServerError, "Error in retriving Data from Database");
            }
        }
        [HttpDelete("{id:int}")]
        public async Task<object> DeleteDistrict(int Id)
        {
            try
            {
                var _data = await _districtRepositriy.DeleteDistrict(Id);
                var modl = new
                {
                    statusCode = 200,
                    message = "District delete sucessfully",
                    result=_data
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
                return StatusCode(StatusCodes.Status500InternalServerError, "Error in retriving Data from Database");
            }
        }
    }
}
