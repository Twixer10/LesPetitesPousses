using LPP.DAL.Contracts.Repositories;
using LPP.DTO;
using LPP.Entities;
using LPP.Services.Contracts;
using Microsoft.AspNetCore.Http;
using System.Buffers.Text;

namespace LPP.Services
{
    public class PictureService : IPictureService
    {
        public string CreateFilePath(Guid pictureId)
        {
            var directoryPath = Path.Combine(Environment.CurrentDirectory, "storage");
            Directory.CreateDirectory(directoryPath);
            var filePath = Path.Combine(directoryPath, pictureId + ".png");
            return filePath;
        }

        public async Task SaveFileAsync(IFormFile picture, string filePath)
        {
            using var stream = File.Create(filePath);
            await picture.CopyToAsync(stream);
        }
    }
}
