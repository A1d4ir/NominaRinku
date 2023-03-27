using MediatR;
using NominaRinku.Domain.Common;

namespace NominaRinku.Application.Features.Sueldos.Commands.CreateSueldo
{
    public class CreateSueldoCommand: IRequest<int>
    {
        public int EmpleadoId { get; set; }
        public Meses Mes { get; set; }
        public int Entregas { get; set; }
    }
}
