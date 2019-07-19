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
        
    }
}
