namespace DotNetCoreArchitecture.Database
{
    public interface IDatabaseUnitOfWork
    {
        void SaveChanges();
    }
}
