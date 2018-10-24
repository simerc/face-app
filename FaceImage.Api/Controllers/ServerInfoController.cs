using System;
using FaceImage.Api.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace FaceImage.Api.Controllers
{
    [ApiController]
    [Route("api/serverinfo")]
    public class ServerInfoController : ControllerBase
    {
        private readonly IHostingEnvironment _hostingEnvironment;

        public ServerInfoController(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(
                new ServerInfo
                {
                    ServerName = Environment.GetEnvironmentVariable("COMPUTERNAME"),
                    FormattedTime = DateTime.Now.ToShortTimeString(),
                    ServerIP = "123.123.123.123",
                    ServerLocation = "London"
                });
        }
    }
}
