using DataAcessLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using student_management.DataContext;
using student_management.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace student_management.Repositries
{
    public class FileRepositriy : IFileRepositriy
    {
        private readonly ApplicationDbContext _Context;
        public FileRepositriy (ApplicationDbContext Context)
        {
            _Context = Context;
        }
       
        public async Task<object> GetFile()
        {
            try
            {
                var result = (
                    from _imageFile in _Context.files
                    join _usr in _Context.users on _imageFile.user_id equals _usr.id
                    select new
                    {
                        fileId=_imageFile.fileId,
                        user_id=_usr.id,
                        image_url=_imageFile.image_url
                    }
                    ).Distinct().ToList();
               if(result != null)
                {
                    return result;
                }
                else
                {
                    return null;
                }

            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public async Task<object> GetFileById(int Id)
        {
            try
            {
                var result = (
                    from _imageFile in _Context.files
                    join _usr in _Context.users on _imageFile.user_id equals _usr.id
                    select new
                    {
                        fileId = _imageFile.fileId,
                        user_id = _usr.id,
                        image_url = _imageFile.image_url
                    }
                    ).FirstOrDefault();
                if(result != null)
                {
                    return result;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public async Task<object> AddFile(file fi)
        {


            var _getFile = await _Context.files.Where(a => a.user_id == fi.user_id).FirstOrDefaultAsync();
            if (_getFile == null)
            {
                var modl = new
                {
                    statusCode = 409,
                    message = "This user is already exist",
                    result = _getFile
                };
                return (modl);
            }
            else
            {
                await _Context.files.AddAsync(fi);
                await _Context.SaveChangesAsync();
            }
            return "User added sucessfully";


        }
        public async Task<object> UpdateFile(file fi)
        {
            try
            {
                var result = await _Context.files.FirstOrDefaultAsync(a => a.fileId == fi.fileId);
                if(result != null)
                {
                    result.user_id = fi.fileId;
                    result.user_id = fi.user_id;
                    result.image_url = fi.image_url;
                    await _Context.SaveChangesAsync();
                    return "User image url updated sucessfully";
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
      
    }
}
