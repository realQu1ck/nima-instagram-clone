using Nima.Instagram.Server.API.Core.Repositories.Post.Image;
using Nima.Instagram.Server.API.Core.Repositories.Post.Image.Frame;
using Nima.Instagram.Server.API.Core.Repositories.Post.Video;
using Nima.Instagram.Server.API.Core.Repositories.Post.Video.Frame;
using Nima.Instagram.Server.API.Core.Repositories.Post.Video.Long;

namespace Nima.Instagram.Server.API.Core.Services.UnitOFWork
{
    public interface IUnitOFWorkRepository
    {
        public IImagePostRepository ImagePostRepository { get; }
        public IImageFrameRepository ImageFrameRepository { get; }
        public IVideoPostRepository VideoPostRepository { get; }
        public IVideoLongRepository VideoLongRepository { get; }
        public IVideoFrameRepository VideoFrameRepository { get; }

        Task ComplateAsync();
        void Dispose();
    }
}
