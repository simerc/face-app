using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FaceImage.Api.Infrastructure.Settings
{
    public class AzureStorageAccountOptions
    {
        public string StorageAccountNameOption { get; set; }
        public string StorageAccountKeyOption { get; set; }
        public string ImagesContainerNameOption { get; set; }
        public string ScaledImagesContainerNameOption { get; set; }
    }
}
