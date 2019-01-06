using DotNetCore.Objects;
using DotNetCoreArchitecture.Database;
using DotNetCoreArchitecture.Model.Models;
using System.Collections.Generic;

namespace DotNetCoreArchitecture.Domain
{
    public sealed class UserDomain : IUserDomain
    {
        public UserDomain(IUserRepository userRepository)
        {
            UserRepository = userRepository;
        }

        private IUserRepository UserRepository { get; }

        public PagedList<UserModel> List(PagedListParameters parameters)
        {
            return UserRepository.List<UserModel>(parameters);
        }

        public IEnumerable<UserModel> List()
        {
            return UserRepository.List<UserModel>();
        }

        public UserModel Select(long userId)
        {
            return UserRepository.Select<UserModel>(userId);
        }
    }
}
