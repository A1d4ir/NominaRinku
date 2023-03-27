using NominaRinku.Domain;
using NominaRinku.Infrastructure.Persistence;
using NominaRinku.Application.Contracts.Persistense;
using Microsoft.EntityFrameworkCore;

namespace NominaRinku.Infrastructure.Repositories
{
    public class SueldoReporitory: RepositoryBase<Sueldo>, ISueldoRepository
    {
        public SueldoReporitory(NominaRinkuDbContext context): base(context)
        {
            
        }

        public async Task<IEnumerable<Sueldo>> GetSueldoByEmpleado(int id)
        {
            return await _context.Sueldos!.Where( s => s.Id == id).ToListAsync();
        }
    }
}
