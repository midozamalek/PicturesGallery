using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
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
        private readonly ILogger<ImageStorageService> _logger;

        public ImageStorageService(IConfiguration config, IAzureBlobStorage iAzureBlobStorage, ILogger<ImageStorageService> logger)
        {
            _config = config;
            _iAzureBlobStorage = iAzureBlobStorage;
            _logger = logger;
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
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Error, ex.Message);
                throw ;
            }
            return model;
        }

        public async Task<byte[]> DownloadAsync(string blobName)
        {
            try
            {
                var stream = await _iAzureBlobStorage.DownloadAsync(blobName);
                return stream.ToArray();
            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Error, ex.Message);
                throw;
            }
        }

        public async Task<bool> DeleteAsync(string blobName)
        {
            try
            {
                await _iAzureBlobStorage.DeleteAsync(blobName);
                return true;
            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Error, ex.Message);
                throw;
            }
        }


        public async Task<bool>UploadAsync(string blobName, MemoryStream fileStream)
        {
            try
            {
                await _iAzureBlobStorage.UploadAsync(blobName, fileStream);
                return true;
            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Error, ex.Message);
                throw;
            }
        }

        public async Task<bool> DeleteAllAsync()
        {
            try
            {
                foreach (var item in await _iAzureBlobStorage.ListAsync())
                {
                    await _iAzureBlobStorage.DeleteAsync(item.BlobName);
                }                
                return true;
            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Error, ex.Message);
                throw;
            }
        }

    }
}
