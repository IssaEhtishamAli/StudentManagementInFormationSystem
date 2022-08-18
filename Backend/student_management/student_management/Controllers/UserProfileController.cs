using DataAcessLayer;
using Microsoft.AspNetCore.Hosting;
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
    [Route("api/userprofile")]
    [ApiController]
    public class UserProfileController : ControllerBase
    {
        private readonly IUserProfileRepositriy _userProfileRepositriy;
        public static IWebHostEnvironment _environment;
        public UserProfileController(IUserProfileRepositriy userProfileRepositriy, IWebHostEnvironment environment)
        {
            _userProfileRepositriy = userProfileRepositriy;
            _environment = environment;
        }
        [HttpGet]
        public async Task<object> GetUserProfile()
        {
            try
            {
                var _data = await _userProfileRepositriy.GetProfile();
                var modl = new
                {
                    statusCode = 200,
                    message = "User profile get sucessfully",
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
        public async Task<object> GetUserprofileById(int Id)
        {
            try
            {
                List<object> _geturp = new List<object>();
                var _data = await _userProfileRepositriy.GteProfileById(Id);
                if (_geturp != null)
                {
                    _geturp.Add(_data);
                    var modl = new
                    {
                        statusCode = 200,
                        message = "User profile  get sucessfully",
                        result = _geturp
                    };
                    return Ok(modl);
                }
                if (_geturp == null)
                {
                    var model = new
                    {
                        statusCode = 404,
                        message = "Record not found"
                    };
                    return Ok(model);
                }
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error in retriving data from database");
            }
        }
        [HttpPost]
        public async Task<object> AddProfile(userprofile urp)
        {
            try
            {
                var _data = await _userProfileRepositriy.AddProfile(urp);
                var file = Request.Form.Files[0];
                string folder = "Service/assets";
                var folderName = Path.Combine(_environment.WebRootPath, folder);
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
                if (file.Length > 0)
                {
                    var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                    var fullPath = Path.Combine(pathToSave, fileName);
                    var dbPath = Path.Combine(folderName, fileName);
                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }
                }
                if (_data == null)
                {
                    var model = new
                    {
                        statusCode = 404,
                        message = "Record not found"
                    };
                    return (model);
                }
                else
                {
                    var modl = new
                    {
                        statusCode = 200,
                        message = "User profile  added sucessfully",
                        result = _data
                    };
                    return Ok(modl);
                }
            }

            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error in retriving data from database");
            }
        }
        [HttpPut("UpdateProfile")]
        public async Task<object> UpdateProfile(userprofile urp)
        {
            try
            {

                var _data = await _userProfileRepositriy.UpdateProfile(urp);
                //var file = Request.Form.Files[0];
                //string folder = "Service/assets";
                //var folderName = Path.Combine(folder);
                //var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folder);
                //if (file.Length > 0)
                //{
                //    var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                //    var fullPath = Path.Combine(pathToSave, fileName);
                //    var dbPath = Path.Combine(folder, fileName);
                //    using (var stream = new FileStream(fullPath, FileMode.Create))
                //    {
                //        file.CopyTo(stream);
                //        return urp.coverimage_url = dbPath;
                //    }
                //    return Ok();
                //}

                //if (urp.coverphoto != null)
                //{
                //    string folder = "Service/assets";
                //    folder += Guid.NewGuid().ToString() + "-" + urp.coverphoto.FileName;
                //    string serverFolder = Path.Combine(_environment.WebRootPath, folder);
                //    return urp.coverimage_url = serverFolder;
                //    await urp.coverphoto.CopyToAsync(new FileStream(serverFolder, FileMode.Create));
                //}
                if (_data == null)
                {
                    var model = new
                    {
                        statusCode = 404,
                        message = "Record not found"
                    };
                    return (model);
                }
                else
                {
                    var modl = new
                    {
                        statusCode = 200,
                        message = "User profile  edit sucessfully",
                        result = _data
                    };
                    return Ok(modl);
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error in retriving data from database");
            }
        }
        //[HttpPut("uploadimg"), DisableRequestSizeLimit]
        //public IActionResult Upload()
        //{
        //    try
        //    {
        //        var file = Request.Form.Files[0];
        //        var folderName = Path.Combine("Resources", "Images");
        //        var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
        //        //var userId = Request
        //        if (file.Length > 0)
        //        {
        //            //var uniqueFileName = $"{userId}_profilepic.png";
        //            var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
        //            var fullPath = Path.Combine(pathToSave, fileName);
        //            var dbPath = Path.Combine(folderName,fileName);
        //            using (var stream = new FileStream(fullPath, FileMode.Create))
        //            {
        //                file.CopyTo(stream);
        //            }
        //            return Ok(dbPath );

        //        }
        //        else
        //        {
        //            return BadRequest();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(500, $"Internal server error: {ex}");
        //    }
        //}
    }
}
