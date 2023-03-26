using NominaRinku.Domain;
using NominaRinku.Infrastructure.Persistence;
using NominaRinlu.Application.Contracts.Persistense;

namespace NominaRinku.Infrastructure.Repositories
{
    public class EmpleadoRepository: RepositoryBase<Empleado>, IEmpleadoRepository
    {
        public EmpleadoRepository(NominaRinkuDbContext context): base(context)
        {
            
        }
    }
}
