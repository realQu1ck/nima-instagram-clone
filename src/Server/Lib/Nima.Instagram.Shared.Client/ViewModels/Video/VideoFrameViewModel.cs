using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nima.Instagram.Shared.Client.ViewModels.Video
{
    public class VideoFrameViewModel : PostViewModel
    {
        public ICollection<IFormFile> Videos { get; set; }
    }
}
