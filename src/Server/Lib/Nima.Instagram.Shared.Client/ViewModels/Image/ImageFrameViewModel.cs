using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nima.Instagram.Shared.Client.ViewModels.Image
{
    public class ImageFrameViewModel : PostViewModel
    {
        public ICollection<IFormFile> Images { get; set; }
    }
}
