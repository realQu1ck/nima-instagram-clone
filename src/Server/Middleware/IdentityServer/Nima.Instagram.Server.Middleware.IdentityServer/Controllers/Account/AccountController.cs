using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nima.Instagram.Server.Middleware.IdentityServer.Attributes;

namespace Nima.Instagram.Server.Middleware.IdentityServer.Controllers.Account
{
    [Route("api/[controller]")]
    [ApiController]
    [SecurityHeaders]
    [AllowAnonymous]
    public class AccountController : ControllerBase
    {
    }
}
