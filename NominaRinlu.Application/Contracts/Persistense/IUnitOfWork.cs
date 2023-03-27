using NominaRinku.Domain.Common;

namespace NominaRinku.Application.Contracts.Persistense
{
    public interface IUnitOfWork: IDisposable
    {
        IEmpleadoRepository EmpleadoRepository { get; }
        ISueldoRepository SueldoRepository { get; }

        IAsyncRepository<TEntity> Repository<TEntity>() where TEntity : BaseDomainModel;

        Task<int> Complete();
    }
}
