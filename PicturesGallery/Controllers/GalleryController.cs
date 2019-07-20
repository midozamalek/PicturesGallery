using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PicturesGallery.BAL.Services;
using PicturesGallery.Infrastructure.ViewModels;

namespace PicturesGallery.Controllers
{
    [Route("api/[controller]")]
    public class GalleryController : Controller
    {
        private readonly ILogger<SampleDataController> _logger;

        private readonly IImageStorageService _imageStorageService;

        public GalleryController(ILogger<SampleDataController> logger, IImageStorageService imageStorageService)
        {
            _logger = logger;
            _imageStorageService = imageStorageService;
        }

        [HttpGet("[action]")]
        public async Task<FilesViewModel> List()
        {
            return await _imageStorageService.ListAsync();           
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> Download(string blobName, string name)
        {            
            var byteImg = await _imageStorageService.DownloadAsync(blobName);
            return File(byteImg, "application/octet-stream", name);
        }

        [HttpGet("[action]")]
        public async Task<bool> Delete(string blobName)
        {
            await _imageStorageService.Delete(blobName);
            return true;
        }

        [HttpPost("[action]"), DisableRequestSizeLimit]
        public async Task<ContentResult> UploadAsync()
        {
            try
            {
                var file = Request.Form.Files[0];
                var blobName = file.FileName;
                MemoryStream filestream = new MemoryStream();
                await file.CopyToAsync(filestream);                 
                await _imageStorageService.UploadAsync(blobName, filestream);
                return Content(file.FileName);
            }
            catch (System.Exception ex)
            {
                return Content(ex.Message);
            }
        }

    }
}
