using Nima.Instagram.Server.API.Core.Data.Database;
using Nima.Instagram.Server.API.Core.Services.UnitOFWork.Generic;
using Nima.Instagram.Shared.Server.Models.Posts.Image;

namespace Nima.Instagram.Server.API.Core.Repositories.Post.Image;

public class ImagePostRepository : GenericRepository<ImageModel>, IImagePostRepository
{
    public ImagePostRepository(InstagramDB _context, ILogger logger) : base(_context, logger)
    {
    }
}