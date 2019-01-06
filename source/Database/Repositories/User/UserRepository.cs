using DotNetCore.EntityFrameworkCore;
using DotNetCoreArchitecture.Model.Entities;
using DotNetCoreArchitecture.Model.Enums;
using DotNetCoreArchitecture.Model.Models;

namespace DotNetCoreArchitecture.Database
{
    public sealed class UserRepository : EntityFrameworkCoreRepository<UserEntity>, IUserRepository
    {
        public UserRepository(DatabaseContext context) : base(context)
        {
        }

        public SignedInModel SignIn(SignInModel signInModel)
        {
            return SingleOrDefault<SignedInModel>
            (
                userEntity => userEntity.Login.Equals(signInModel.LoginHash())
                && userEntity.Password.Equals(signInModel.PasswordHash())
                && userEntity.Status == Status.Active
            );
        }
    }
}
