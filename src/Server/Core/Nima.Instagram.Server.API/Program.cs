/* 
MIT License

Copyright (c) 2022 Nima Hosseini

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
*/

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Nima.Instagram.Server.API.Core.Data.Database;
using Nima.Instagram.Server.API.Core.Data.Database.User;
using Nima.Instagram.Server.API.Core.Data.Migration;
using Nima.Instagram.Server.API.Core.Services.UnitOFWork;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var ConnectionString = builder.Configuration.
    GetConnectionString("InstagramDBConnectionString");
builder.Services.AddDbContext<InstagramDB>
    (options => options.UseSqlServer(ConnectionString));
builder.Services.AddIdentity<InstagramUser, IdentityRole>()
    .AddEntityFrameworkStores<InstagramDB>()
    .AddRoles<IdentityRole>()
    .AddDefaultTokenProviders();
builder.Services.AddLogging();
builder.Services.AddScoped<MigrateDatabase>();
builder.Services.AddScoped<IUnitOFWorkRepository, UnitOFWorkRepository>();

MigrateDatabase mig = new MigrateDatabase(builder.Services.BuildServiceProvider());
mig.Opener();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();