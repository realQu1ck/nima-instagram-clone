using Microsoft.AspNetCore.Identity;

namespace Nima.Instagram.Server.API.Core.Data.Database.User;

public class InstagramUser : IdentityUser
{
    public string Name { get; set; }
    public string Family { get; set; }
    public string IdentityID { get; set; }
}