using DotNetCore.Objects;
using DotNetCore.Security;
using DotNetCoreArchitecture.Database;
using DotNetCoreArchitecture.Model.Enums;
using DotNetCoreArchitecture.Model.Models;
using DotNetCoreArchitecture.Model.Validators;

namespace DotNetCoreArchitecture.Domain
{
    public sealed class AuthenticationDomain : IAuthenticationDomain
    {
        public AuthenticationDomain(
            IJsonWebToken jsonWebToken,
            IUserLogDomain userLogDomain,
            IUserRepository userRepository)
        {
            JsonWebToken = jsonWebToken;
            UserLogDomain = userLogDomain;
            UserRepository = userRepository;
        }

        private IJsonWebToken JsonWebToken { get; }
        private IUserLogDomain UserLogDomain { get; }
        private IUserRepository UserRepository { get; }

        public IResult<string> SignIn(SignInModel signInModel)
        {
            var validation = new SignInModelValidator().Valid(signInModel);
            if (!validation.Success)
            {
                return validation;
            }

            var signedInModel = UserRepository.SignIn(signInModel);

            validation = new SignedInModelValidator().Valid(signedInModel);
            if (!validation.Success)
            {
                return validation;
            }

            var userLogModel = new UserLogModel(signedInModel.UserId, LogType.Login);
            UserLogDomain.Save(userLogModel);

            var jwt = CreateJwt(signedInModel);

            return new SuccessResult<string>(jwt);
        }

        public void SignOut(SignOutModel signOutModel)
        {
            var userLogModel = new UserLogModel(signOutModel.UserId, LogType.Logout);
            UserLogDomain.Save(userLogModel);
        }

        private string CreateJwt(SignedInModel signedInModel)
        {
            var sub = signedInModel.UserId.ToString();
            var roles = signedInModel.Roles.ToString().Split(", ");

            return JsonWebToken.Encode(sub, roles);
        }
    }
}
