using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FaceImage.Api.Models.Images;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Net.Http.Headers;
using System.Security.Claims;
using FaceImage.Api.Services.Interfaces;
using Microsoft.IdentityModel.JsonWebTokens;

namespace FaceImage.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class ImagesController : ControllerBase
    {
        private IHostingEnvironment _hostingEnvironment;

        private IImageStorageService _imageStorageService;

        public ImagesController(IHostingEnvironment hostingEnvironment, IImageStorageService imageStorageService)
        {
            _hostingEnvironment = hostingEnvironment;
            _imageStorageService = imageStorageService;
        }

        [HttpGet]
        [Authorize(Policy = "ApiUser")]
        public ActionResult<IEnumerable<ImageModel>> Get()
        {
            var imageList = new List<ImageModel>()
            {
                new ImageModel
                {
                    Id = "1",
                    Name = "Image 1",
                    Alt = "Image 1 alt info",
                    Src = "https://loremflickr.com/150/150/dog"
                },
                new ImageModel
                {
                    Id = "2",
                    Name = "Another image",
                    Alt = "image of parise",
                    Src = "https://loremflickr.com/150/150/paris"
                }
            };

            return new JsonResult(imageList);
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult<ImageModel> Get(string id) 
        {
            return new JsonResult(
                new ImageModel
                    {
                        Id = id,
                        Name = "Image name",
                        Alt = "image alt",
                        Src = "https://loremflickr.com/150/150/london"
                });
        }

        [HttpPost]
        [Route("uploadimage")]
        [DisableRequestSizeLimit]
        [Authorize(Policy = "ApiUser")]
        public IActionResult UploadImage()
        {
            var file = Request.Form.Files[0];
            var userFolderName = "";

            //get userId from security token
            var claimsIdentity = User.Identity as ClaimsIdentity;

            if(claimsIdentity != null)
                userFolderName = claimsIdentity.FindFirst(Constants.Strings.JwtClaimIdentifiers.Id).Value;
             
            if (file.Length > 0)
            {
                string fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                var result = _imageStorageService.UploadImage(userFolderName, fileName, file);

                if (result.Success)
                    return new JsonResult("Success");
                else
                    return new JsonResult("Failed:  " + result.ErrorMessage);
            }

            return new JsonResult("Upload Failed: No file selected");

        }
    }
}