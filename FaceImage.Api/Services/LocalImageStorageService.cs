using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using FaceImage.Api.Models.Images;
using FaceImage.Api.Services.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace FaceImage.Api.Services
{
    public class LocalImageStorageService : IImageStorageService
    {
        private readonly IHostingEnvironment _hostingEnvironment;

        private string _folderName = "Upload";
        private string _webRoot;
        private string _uploadPath;

        public LocalImageStorageService(IHostingEnvironment env)
        {
            _hostingEnvironment = env;

            //set the save location for the uploaded file
            _webRoot = _hostingEnvironment.WebRootPath;
            _uploadPath = Path.Combine(_webRoot, _folderName);

            if (!Directory.Exists(_uploadPath))
            {
                Directory.CreateDirectory(_uploadPath);
            }
        }

        public ImageUploadResult UploadImage(string folderName, string filename, IFormFile file)
        {
            var result = new ImageUploadResult();

            try
            {
                string fullPath = Path.Combine(_uploadPath, folderName, filename);
                using (var stream = new FileStream(fullPath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }

                result.Success = true;
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.ErrorMessage = ex.Message;
            }

            return result;
        }
    }
}
