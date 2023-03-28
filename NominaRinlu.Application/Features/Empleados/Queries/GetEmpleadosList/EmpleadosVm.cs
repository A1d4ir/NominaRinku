using NominaRinku.Domain.Common;

namespace NominaRinku.Application.Features.Empleados.Queries.GetEmpleadosList
{
    public class EmpleadosVm
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public Roles Rol { get; set; }
    }
}
