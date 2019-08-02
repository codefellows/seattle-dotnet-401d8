using CMSDemo.Models.Interfaces;
using Microsoft.Azure.Storage;
using Microsoft.Azure.Storage.Blob;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;

namespace CMSDemo.Models.Services
{
    public class BlobStorage : IImageManager
    {
        public IConfiguration Configuration { get; }

        public CloudStorageAccount CloudStorage { get; set; }
        public CloudBlobClient CloudBlob { get; set; }

        public BlobStorage(IConfiguration configuration)
        {
            Configuration = configuration;

            CloudStorage = CloudStorageAccount.Parse(Configuration["AzureBlobConnString"]);
            CloudBlob = CloudStorage.CreateCloudBlobClient();

        }

        public async Task<CloudBlobContainer> GetContainer(string containerName)
        {
           CloudBlobContainer cbc = CloudBlob.GetContainerReference(containerName);
            await cbc.CreateIfNotExistsAsync();
            await cbc.SetPermissionsAsync(new BlobContainerPermissions { PublicAccess = BlobContainerPublicAccessType.Blob });

            return cbc;
        }

        public async Task<CloudBlob> GetBlob(string imageName, string containerName)
        {
            var container = await GetContainer(containerName);
            CloudBlob blob = container.GetBlobReference(imageName);
            return blob;
            
        }
               
        public void UploadFile(CloudBlobContainer container, string fileName, string filePath)
        {
            CloudBlockBlob blobby = container.GetBlockBlobReference(fileName);
            blobby.UploadFromFileAsync(filePath);
        }
    }
}
