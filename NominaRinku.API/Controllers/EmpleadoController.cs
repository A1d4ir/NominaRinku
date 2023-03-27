using MediatR;
using Microsoft.AspNetCore.Mvc;
using NominaRinku.Application.Features.Empleados.Commands.CreateEmpleado;

namespace NominaRinku.API.Controllers
{
    [ApiController]
    [Route("api/empleado")]
    public class EmpleadoController: ControllerBase
    {
        private readonly IMediator _mediator;

        public EmpleadoController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost(Name = "NuevoEmpleado")]
        public async Task<ActionResult<int>> NuevoEmpleado([FromBody] CreateEmpleadoCommand command)
        {
            return await _mediator.Send(command);
        }
    }
}
