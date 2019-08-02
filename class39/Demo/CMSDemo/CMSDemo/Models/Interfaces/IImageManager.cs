using Microsoft.Azure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMSDemo.Models.Interfaces
{
    public interface IImageManager
    {
        Task<CloudBlobContainer> GetContainer(string containerName);

        Task<CloudBlob> GetBlob(string imageName, string containerName);

        void UploadFile(CloudBlobContainer container, string fileName, string filePath);
        
    }
}
