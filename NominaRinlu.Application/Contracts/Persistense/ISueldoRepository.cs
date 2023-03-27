using NominaRinku.Domain;

namespace NominaRinku.Application.Contracts.Persistense
{
    public interface ISueldoRepository : IAsyncRepository<Sueldo>
    {
        Task<IEnumerable<Sueldo>> GetSueldoByEmpleado(int id);
    }
}
