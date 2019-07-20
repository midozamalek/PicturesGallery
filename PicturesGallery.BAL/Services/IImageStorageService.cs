using PicturesGallery.BAL.Azure.Blob;
using PicturesGallery.Infrastructure.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace PicturesGallery.BAL.Services
{
    public interface IImageStorageService
    {
        Task<FilesViewModel> ListAsync();
        Task<byte[]> DownloadAsync(string blobName);
        Task<bool> Delete(string blobName);
        Task<bool> UploadAsync(string blobName, MemoryStream fileStream);
    }
}
