using Ocelot.DependencyInjection;
using Ocelot.Cache.CacheManager;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddOcelot().AddCacheManager(options =>
{
    options.WithDictionaryHandle();
});
builder.WebHost.ConfigureAppConfiguration((hosingContext, config) =>
{
    config.AddJsonFile("ocelot.Loacl.json", true, true);
});

var app = builder.Build();
app.UseOcelot();
app.Run();
