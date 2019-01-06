using DotNetCore.Objects;
using DotNetCoreArchitecture.Model.Models;

namespace DotNetCoreArchitecture.Application
{
    public interface IAuthenticationApplication
    {
        IResult<string> SignIn(SignInModel signInModel);

        void SignOut(SignOutModel signOutModel);
    }
}
