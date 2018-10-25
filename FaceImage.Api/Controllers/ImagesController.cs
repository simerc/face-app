using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FaceImage.Api.Models.Images;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FaceImage.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        public ImagesController()
        {

        }

        [HttpGet]
        [EnableCors("AllowAll")]
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
    }
}