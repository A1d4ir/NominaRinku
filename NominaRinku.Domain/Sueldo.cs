using NominaRinku.Domain.Common;

namespace NominaRinku.Domain
{
    public class Sueldo: BaseDomainModel
    {
        public int EmpleadoId { get; set; }
        public Meses Mes { get; set; }
        public int Entregas { get; set; }
        public virtual Empleado? Empleado { get; set; }

    }
}
