
using FaceImage.Api.Models.Images;
using Microsoft.AspNetCore.Http;

namespace FaceImage.Api.Services.Interfaces
{
    public interface IImageStorageService
    {
        ImageUploadResult UploadImage(string folderName, string fileName, IFormFile formFile);
    }
}
