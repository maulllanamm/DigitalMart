using DigitalMart.Domain.Common;

namespace DigitalMart.Application.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        IBaseRepository<Entity> GetBaseRepository<Entity>() where Entity : class, IBaseEntity;
        void BeginTransaction();
        void Commit();
        void Rollback();
        int SaveChanges();
        void Dispose();
    }
}
