using DotNetCoreArchitecture.Model.Models;

namespace DotNetCoreArchitecture.Domain
{
    public interface IUserLogDomain
    {
        void Save(UserLogModel userLogModel);
    }
}
