using NominaRinku.Domain.Common;
using NominaRinku.Infrastructure.Persistence;
using NominaRinlu.Application.Contracts.Persistense;
using System.Collections;

namespace NominaRinku.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private Hashtable _repositories;
        private readonly NominaRinkuDbContext _context;

        IEmpleadoRepository _empleadoRepository;
        ISueldoRepository _sueldoRepository;

        public IEmpleadoRepository EmpleadoRepository => _empleadoRepository ??= new EmpleadoRepository(_context);

        public ISueldoRepository SueldoRepository => _sueldoRepository ??= new SueldoReporitory(_context);

        public UnitOfWork(NominaRinkuDbContext context)
        {
            _context=context;
        }

        public async Task<int> Complete()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public IAsyncRepository<TEntity> Repository<TEntity>() where TEntity : BaseDomainModel
        {
           if(_repositories == null)
           {
                _repositories = new Hashtable();
           }

            var type = typeof(TEntity).Assembly;

            if (!_repositories.ContainsKey(type))
            {
                var repositoryType = typeof(RepositoryBase<>);
                var repositoryInstance = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(TEntity)), _context);
                _repositories.Add(type, repositoryInstance);
            }

            return (IAsyncRepository<TEntity>)_repositories[type];
        }
    }
}
