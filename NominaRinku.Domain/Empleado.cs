using NominaRinku.Domain.Common;

namespace NominaRinku.Domain
{
    public class Empleado: BaseDomainModel
    {
        public string? Nombre { get; set; }
        public Roles Rol { get; set; }
        public ICollection<Sueldo>? Sueldos { get; set; }
    }
}
