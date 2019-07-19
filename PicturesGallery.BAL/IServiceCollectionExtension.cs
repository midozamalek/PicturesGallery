using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace PicturesGallery.BAL
{
    public static class IServiceCollectionExtension
    {
        public static IServiceCollection configureServices(this IServiceCollection services)
        {
             return services;
        }
    }
}
