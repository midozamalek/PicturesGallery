using PicturesGallery.BAL.Azure.Blob;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PicturesGallery.BAL.Services
{
    public interface IImageStorageService
    {
        Task<string> StoreImage(string filename, byte[] image);
        Task<List<AzureBlobItem>> ListAsync();
    }
}
