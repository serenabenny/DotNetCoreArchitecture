using DotNetCore.Objects;
using DotNetCoreArchitecture.Model.Models;

namespace DotNetCoreArchitecture.Domain
{
    public interface IAuthenticationDomain
    {
        IResult<string> SignIn(SignInModel signInModel);

        void SignOut(SignOutModel signOutModel);
    }
}
