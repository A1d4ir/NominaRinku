using NominaRinku.Domain.Common;

namespace NominaRinku.Domain
{
    public class Empleado: BaseDomainModel
    {
        public int Numero { get; set; }
        public string? Nombre { get; set; }
        public Enum Rol { get; set; }
    }
}
