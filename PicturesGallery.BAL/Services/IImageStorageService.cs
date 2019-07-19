using PicturesGallery.BAL.Azure.Blob;
using PicturesGallery.Infrastructure.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PicturesGallery.BAL.Services
{
    public interface IImageStorageService
    {
        Task<FilesViewModel> ListAsync();
    }
}
