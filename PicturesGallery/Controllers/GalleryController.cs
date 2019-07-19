using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PicturesGallery.BAL.Services;
using PicturesGallery.Infrastructure.ViewModels;

namespace PicturesGallery.Controllers
{
    [Route("api/[controller]")]
    public class GalleryController
    {
        private readonly ILogger<SampleDataController> _logger;

        private readonly IImageStorageService _imageStorageService;

        public GalleryController(ILogger<SampleDataController> logger, IImageStorageService imageStorageService)
        {
            _logger = logger;
            _imageStorageService = imageStorageService;
        }

        [HttpGet("[action]")]
        public async Task<FilesViewModel> ListAsync()
        {
            return await _imageStorageService.ListAsync();           
        }


    }
}
