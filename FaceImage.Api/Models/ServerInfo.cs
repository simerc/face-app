using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace FaceImage.Api.Models
{
    public class ServerInfo
    {
        [JsonProperty("serverName")]
        public string ServerName { get; set; }

        [JsonProperty("serverIp")]
        public string ServerIP { get; set; }

        [JsonProperty("serverLocation")]
        public string ServerLocation { get; set; }

        [JsonProperty("formattedTime")]
        public string FormattedTime { get; set; }
    }
}
