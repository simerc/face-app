using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FaceImage.Api.Models.Images
{
    public class ImageModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Alt { get; set; }
        public string Src { get; set; }
    }
}
