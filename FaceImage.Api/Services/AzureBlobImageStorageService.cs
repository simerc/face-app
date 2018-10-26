using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using FaceImage.Api.Infrastructure.Settings;
using FaceImage.Api.Models.Images;
using FaceImage.Api.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Blob;

namespace FaceImage.Api.Services
{
    public class AzureBlobImageStorageService : IImageStorageService
    {
        private readonly CloudStorageAccount _storageAccount;
        private readonly string _containerName;

        public AzureBlobImageStorageService(IOptions<AzureStorageAccountOptions> storageOptions)
        {
            //get containername for image uploads
            _containerName = storageOptions.Value.ImagesContainerNameOption;

            //get settings from configuration options
            var accountName = storageOptions.Value.StorageAccountNameOption;
            var accountKey = storageOptions.Value.StorageAccountKeyOption;

            var storageCredentials = new StorageCredentials(accountName, accountKey);

            //create storage account connection
            _storageAccount = new CloudStorageAccount(storageCredentials, true);

        }

        public ImageUploadResult UploadImage(string folderName, string filename, IFormFile file)
        {
            var blobClient = _storageAccount.CreateCloudBlobClient();

            //Extract the filename from the formfile
            int fileNameStart = file.FileName.LastIndexOf("\\") + 1;
            var fileName = file.FileName.Substring(fileNameStart);

            //get the specific uploads blob container, create if it doesn't exist
            var blobContainer = blobClient.GetContainerReference(_containerName);
            blobContainer.CreateIfNotExists();

            blobContainer.SetPermissions(new BlobContainerPermissions
            {
                PublicAccess = BlobContainerPublicAccessType.Blob
            });

            //get the new blob container and stream the uploaded file
            //use the folder name provided by the settings
            var newBlob = blobContainer.GetBlockBlobReference(folderName + @"\" + fileName);
            newBlob.UploadFromStream(file.OpenReadStream());
            

            var result = new ImageUploadResult();
            result.Success = true;

            return result;
        }
    }
}
