using DataAcessLayer;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace student_management.Repositries
{
    public interface IFileRepositriy
    {
        Task<object> GetFile();
        Task<object> GetFileById(int Id);
        Task<object> AddFile(file fi);
        Task<object> UpdateFile(file fi);
    }
}
