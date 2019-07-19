using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PicturesGallery.BAL.Azure.Blob;
using PicturesGallery.BAL.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace PicturesGallery.BAL
{
    public static class IServiceCollectionExtension
    {
        public static IServiceCollection configureBALServices(this IServiceCollection services)
        {
            
            services.AddScoped<IImageStorageService, ImageStorageService>();
            return services;
        }
    }
}
