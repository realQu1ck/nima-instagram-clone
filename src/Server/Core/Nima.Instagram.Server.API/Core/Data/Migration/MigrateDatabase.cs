using Microsoft.EntityFrameworkCore;
using Nima.Instagram.Server.API.Core.Data.Database;

namespace Nima.Instagram.Server.API.Core.Data.Migration;

public class MigrateDatabase
{
    private readonly IServiceProvider _serviceProvider;
    public MigrateDatabase(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public void Opener()
    {
        CreateDatabaseIFNotExists().Wait();
    }
    
    public async Task CreateDatabaseIFNotExists()
    {
        var context = _serviceProvider.GetService<InstagramDB>();
        await context.Database.MigrateAsync();
        await context.Database.EnsureCreatedAsync();
    }
}