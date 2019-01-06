using DotNetCore.AspNetCore;
using DotNetCore.Extensions;
using DotNetCoreArchitecture.Application;
using DotNetCoreArchitecture.Model.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DotNetCoreArchitecture.Web
{
    [ApiController]
    [RouteController]
    public class AuthenticationController : ControllerBase
    {
        public AuthenticationController(IAuthenticationApplication authenticationApplication)
        {
            AuthenticationApplication = authenticationApplication;
        }

        private IAuthenticationApplication AuthenticationApplication { get; }

        [AllowAnonymous]
        [HttpPost("[action]")]
        public IActionResult SignIn(SignInModel signInModel)
        {
            return new Result(AuthenticationApplication.SignIn(signInModel));
        }

        [HttpPost("[action]")]
        public void SignOut()
        {
            var signOutModel = new SignOutModel(User.Id());
            AuthenticationApplication.SignOut(signOutModel);
        }
    }
}
