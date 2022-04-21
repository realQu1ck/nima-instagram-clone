using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nima.Instagram.Shared.Client.ViewModels
{
    public abstract class PostViewModel
    {
        public Guid Id { get; set; }
        public string UserId { get; set; }
        public string Description { get; set; }
    }
}
