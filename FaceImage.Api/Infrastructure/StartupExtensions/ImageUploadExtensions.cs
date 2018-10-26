using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FaceImage.Api.Infrastructure.Settings;
using FaceImage.Api.Services;
using FaceImage.Api.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace FaceImage.Api.Infrastructure.StartupExtensions
{
    public static class ImageUploadExtensions
    {
        public static void ConfigureImageUploadOptions(this IServiceCollection services, IConfiguration configuration)
        {
            var storageType = configuration["ImageStorageOptions:StorageType"];

            if (storageType == "AzureBlob")
            {
                services.Configure<AzureStorageAccountOptions>(
                    configuration.GetSection("ImageStorageOptions:AzureStorageOptions"));
                services.AddSingleton<IImageStorageService, AzureBlobImageStorageService>();
            }
            else if (storageType == "local")
            {
                services.AddSingleton<IImageStorageService, LocalImageStorageService>();
            }


        }
    }
}
