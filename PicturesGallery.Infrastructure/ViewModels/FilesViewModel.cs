using System;
using System.Collections.Generic;
using System.Text;

namespace PicturesGallery.Infrastructure.ViewModels
{
    public class FilesViewModel
    {
        public List<FileDetails> Files { get; set; }
       = new List<FileDetails>();
    }
}
