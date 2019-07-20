using Microsoft.Extensions.Configuration;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Blob;
using PicturesGallery.BAL.Azure.Blob;
using PicturesGallery.Infrastructure.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace PicturesGallery.BAL.Services
{
    public class ImageStorageService : IImageStorageService
    {
        private readonly IConfiguration _config;
        private readonly IAzureBlobStorage _iAzureBlobStorage;

        public ImageStorageService(IConfiguration config, IAzureBlobStorage iAzureBlobStorage)
        {
            _config = config;
            _iAzureBlobStorage = iAzureBlobStorage;
        }


        public async Task<FilesViewModel> ListAsync()
        {
            var model = new FilesViewModel();
            try
            {
                foreach (var item in await _iAzureBlobStorage.ListAsync())
                {
                    model.Files.Add(
                        new FileDetails { Name = item.Name, BlobName = item.BlobName });
                }
            }
            catch (Exception )
            {
                
            }
            return model;
        }

        public async Task<byte[]> DownloadAsync(string blobName)
        {            
            var stream = await _iAzureBlobStorage.DownloadAsync(blobName);
            return stream.ToArray();
        }

        public async Task<bool> Delete(string blobName)
        {            
            await _iAzureBlobStorage.DeleteAsync(blobName);
            return true;
        }


        public async Task<bool>UploadAsync(string blobName, MemoryStream fileStream)
        {
            await _iAzureBlobStorage.UploadAsync(blobName, fileStream);
            return true;
        }

    }
}
