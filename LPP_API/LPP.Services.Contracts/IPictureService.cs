using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LPP.Services.Contracts
{
    public interface IPictureService
    {
        public string CreateFilePath(Guid pictureId);
        public Task SaveFileAsync(IFormFile stringPicture, string filePath);
    }
}
