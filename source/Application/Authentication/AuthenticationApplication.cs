using DotNetCore.Objects;
using DotNetCoreArchitecture.Domain;
using DotNetCoreArchitecture.Model.Models;

namespace DotNetCoreArchitecture.Application
{
    public sealed class AuthenticationApplication : IAuthenticationApplication
    {
        public AuthenticationApplication(IAuthenticationDomain authenticationDomain)
        {
            AuthenticationDomain = authenticationDomain;
        }

        private IAuthenticationDomain AuthenticationDomain { get; }

        public IResult<string> SignIn(SignInModel signInModel)
        {
            return AuthenticationDomain.SignIn(signInModel);
        }

        public void SignOut(SignOutModel signOutModel)
        {
            AuthenticationDomain.SignOut(signOutModel);
        }
    }
}
