using MediatR;

namespace NominaRinku.Application.Features.Empleados.Commands.DeleteEmpleado
{
    public class DeleteEmpleadoCommand: IRequest<int>
    {
        public int Id { get; set; }
    }
}
