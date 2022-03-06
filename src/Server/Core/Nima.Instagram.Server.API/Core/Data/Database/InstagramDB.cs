using System.Diagnostics;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Nima.Instagram.Server.API.Core.Data.Database.User;
using Nima.Instagram.Shared.Server.Models.Posts.Image;
using Nima.Instagram.Shared.Server.Models.Posts.Video.Frame;
using Nima.Instagram.Shared.Server.Models.Posts.Video.Long;

namespace Nima.Instagram.Server.API.Core.Data.Database;

public class InstagramDB : IdentityDbContext<InstagramUser>
{
    public InstagramDB(DbContextOptions<InstagramDB> options) : base(options)
    {
        
    }
    
    public virtual DbSet<ImageFrameModel> ImageFrameModels { get; set; }
    public virtual DbSet<ImageModel> ImageModels { get; set; }
    public virtual DbSet<VideoFrameModel> VideoFrameModels { get; set; }
    public virtual DbSet<VideoModel> VideoModels { get; set; }
    public virtual DbSet<VideoLongModel> VideoLongModels { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
    }
}