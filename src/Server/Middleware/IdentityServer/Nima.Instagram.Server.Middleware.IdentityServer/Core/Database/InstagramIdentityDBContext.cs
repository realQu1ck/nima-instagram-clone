using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Nima.Instagram.Server.Middleware.IdentityServer.Core.Database.User;

namespace Nima.Instagram.Server.Middleware.IdentityServer.Core.Database
{
    public class InstagramIdentityDBContext : IdentityDbContext<InstagramIdentityUser>
    {
        public InstagramIdentityDBContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
