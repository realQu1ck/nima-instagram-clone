using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using Nima.Instagram.Server.Middleware.IdentityServer;
using Nima.Instagram.Server.Middleware.IdentityServer.Core.Database;
using Nima.Instagram.Server.Middleware.IdentityServer.Core.Database.Migration;
using Nima.Instagram.Server.Middleware.IdentityServer.Core.Database.User;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("InstagramIdentityDBConnectionString");
builder.Services.AddDbContext<InstagramIdentityDBContext>(option => option.UseSqlServer(connectionString));
builder.Services.AddIdentity<InstagramIdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<InstagramIdentityDBContext>()
    .AddDefaultTokenProviders()
    .AddRoles<IdentityRole>();

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("Adminstrator", role => role.RequireRole("Adminstrator"));
    options.AddPolicy("User", role => role.RequireRole("User"));
});

builder.Services.Configure<IdentityOptions>(opt =>
{
    opt.Password.RequiredLength = 8;
    opt.Password.RequireLowercase = true;
    opt.Password.RequireUppercase = true;
    opt.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromSeconds(30);
    opt.Lockout.MaxFailedAccessAttempts = 5;
    opt.SignIn.RequireConfirmedEmail = true;
});

builder.Services.AddAuthentication("MyCookie")
            .AddCookie("MyCookie", options =>
            {
                options.ExpireTimeSpan = TimeSpan.FromMinutes(30);
            });

builder.Services.AddResponseCompression(options =>
{
    options.Providers.Add<GzipCompressionProvider>();
});

builder.Services.AddIdentityServer(options =>
{
    options.IssuerUri = "https://localhost:7178";
    options.InputLengthRestrictions.RedirectUri = 1000;
})
    .AddAspNetIdentity<InstagramIdentityUser>()
     .AddInMemoryClients(Config.Clients)
    .AddInMemoryApiScopes(Config.ApiScopes)
    .AddInMemoryIdentityResources(Config.IdentityResources)
    .AddDeveloperSigningCredential();

IServiceProvider services = builder.Services.BuildServiceProvider();
ContextMigrate s = new ContextMigrate(services);
s.SeedData().Wait();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.UseStaticFiles();
app.UseRouting();
app.UseIdentityServer();

app.UseCookiePolicy(new CookiePolicyOptions
{
    MinimumSameSitePolicy = SameSiteMode.None
});

app.MapControllers();

app.Run();
