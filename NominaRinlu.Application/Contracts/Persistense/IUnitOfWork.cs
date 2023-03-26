using NominaRinku.Domain.Common;

namespace NominaRinlu.Application.Contracts.Persistense
{
    public interface IUnitOfWork: IDisposable
    {
        IAsyncRepository<TEntity> Repository<TEntity>() where TEntity : BaseDomainModel;

        Task<int> Complete();
    }
}
