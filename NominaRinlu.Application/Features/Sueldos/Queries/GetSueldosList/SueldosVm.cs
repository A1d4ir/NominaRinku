namespace NominaRinku.Application.Features.Sueldos.Queries.GetSueldosList
{
    public class SueldosVm
    {
        public int HorasTrabajadas { get; set; }
        public decimal PagoPorEntregas { get; set; }
        public decimal PagoPorBonos { get; set; }
        public decimal Retenciones { get; set; }
        public decimal Vales { get; set; }
        public decimal Sueldo { get; set; }
    }
}
