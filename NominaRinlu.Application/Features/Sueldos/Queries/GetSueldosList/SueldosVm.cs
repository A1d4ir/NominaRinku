using NominaRinku.Domain.Common;

namespace NominaRinku.Application.Features.Sueldos.Queries.GetSueldosList
{
    public class SueldosVm
    {
        public int Id { get; set; }
        public Meses Mes { get; set; }
        public int HorasTrabajadas { get; set; }
        public decimal PagoPorEntregas { get; set; }
        public decimal PagoPorBonos { get; set; }
        public decimal Retenciones { get; set; }
        public decimal Vales { get; set; }
        public decimal Sueldo { get; set; }
    }
}
