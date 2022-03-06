using Nima.Instagram.Server.API.Core.Data.Database;
using Nima.Instagram.Server.API.Core.Repositories.Post.Image;
using Nima.Instagram.Server.API.Core.Repositories.Post.Image.Frame;
using Nima.Instagram.Server.API.Core.Repositories.Post.Video;
using Nima.Instagram.Server.API.Core.Repositories.Post.Video.Frame;
using Nima.Instagram.Server.API.Core.Repositories.Post.Video.Long;

namespace Nima.Instagram.Server.API.Core.Services.UnitOFWork
{
    public class UnitOFWorkRepository : IUnitOFWorkRepository, IDisposable
    {
        protected private readonly InstagramDB context;
        protected private readonly ILogger logger;

        public UnitOFWorkRepository(InstagramDB _context, ILoggerFactory loggerFactory)
        {
            context = _context;
            logger = loggerFactory.CreateLogger("UnitOFWork");
            ImagePostRepository = new ImagePostRepository(context, logger);
            ImageFrameRepository = new ImageFrameRepository(context, logger);
            VideoPostRepository = new VideoPostRepository(context, logger);
            VideoFrameRepository = new VideoFrameRepository(context, logger);
            VideoLongRepository = new VideoLongRepository(context, logger);
        }

        public IImagePostRepository ImagePostRepository { get; private set; }
        public IImageFrameRepository ImageFrameRepository { get; private set; }
        public IVideoPostRepository VideoPostRepository { get; private set; }
        public IVideoLongRepository VideoLongRepository { get; private set; }
        public IVideoFrameRepository VideoFrameRepository { get; private set; }

        public async Task ComplateAsync()
        {
            await context.SaveChangesAsync();
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}
