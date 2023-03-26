using MediatR;
using NominaRinku.Domain.Common;

namespace NominaRinlu.Application.Features.Empleados.Commands.CreateEmpleado
{
    public class CreateEmpleadoCommand : IRequest<int>
    {
        public string? Nombre { get; set; } = string.Empty;
        public Roles Rol { get; set; }
    }
}
