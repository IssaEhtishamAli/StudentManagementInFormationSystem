using DataAcessLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using student_management.Repositries;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace student_management.Controllers
{
    [Route("api/imagefile")]
    [ApiController]
    public class FileController : ControllerBase
    {
        private readonly IFileRepositriy _fileRepositriy;
        public FileController(IFileRepositriy fileRepositriy)
        {
            _fileRepositriy = fileRepositriy;
        }
        [HttpGet]
        public async Task<object> GetFile()
        {
            try
            {
                var _data =await _fileRepositriy.GetFile();
                var modl = new
                {
                    statusCode = 200,
                    message = "User image path get sucessfully",
                    result = _data
                };
                return Ok(modl);
                if(_data == null)
                {
                    var model = new
                    {
                        statusCode = 404,
                        message = "Record not found",
                        result = _data
                    };
                    return Ok(model);
                }
               
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error in retriving data from database");
            }
        }
        [HttpGet("{id:int}")]
        public async Task<object> GetFileById(int Id)
        {
            try
            {
                var _data = await _fileRepositriy.GetFileById(Id);
                var modl = new
                {
                    statusCode = 200,
                    message = "User image path get sucessfully",
                    result = _data
                };
                return Ok(modl);
                if (_data == null)
                {
                    var model = new
                    {
                        statusCode = 404,
                        message = "Record not found",
                        result = _data
                    };
                    return Ok(model);
                }

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error in retriving data from database");
            }
        }
        [HttpPost("storeimagepath")]
        public async Task<object> AddFile(file fi)
        {
            try
            {
                var _data = await _fileRepositriy.AddFile(fi);
                var modl = new
                {
                    statusCode = 200,
                    message = "Student  added sucessfully",
                    result = _data
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
                return StatusCode(StatusCodes.Status500InternalServerError, "Error in retriving data from database");
            }
        }
        [HttpPut("imagepathupdate")]
        public async Task<object> UpdateFile(file fi)
        {
            try
            {
                var _data = await _fileRepositriy.UpdateFile(fi);
                var modl = new
                {
                    statusCode = 200,
                    message = "Student  added sucessfully",
                    result = _data
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
                return StatusCode(StatusCodes.Status500InternalServerError, "Error in retriving data from database");
            }
        }
        [HttpPost("fileupload"), DisableRequestSizeLimit]
        public IActionResult Upload()
        {
            try
            {
                var file = Request.Form.Files[0];
                var folderName = Path.Combine("Resources", "Images");
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
                if (file.Length > 0)
                {
                    var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                    var fullPath = Path.Combine(pathToSave, fileName);
                    var path = Path.Combine(folderName, fileName);
                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }

                    return Ok(path);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }
        }
    }
}
