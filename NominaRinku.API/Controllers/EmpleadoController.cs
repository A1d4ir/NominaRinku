using MediatR;
using Microsoft.AspNetCore.Mvc;
using NominaRinku.Application.Features.Empleados.Commands.CreateEmpleado;
using NominaRinku.Application.Features.Empleados.Commands.DeleteEmpleado;
using NominaRinku.Application.Features.Empleados.Queries.GetEmpleadosList;

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

        [HttpGet(Name = "GetEmpleados")]
        public async Task<ActionResult<IEnumerable<EmpleadosVm>>> GetEmpleados()
        {
            var query = new GetEmpleadosListQuery();
            var empleados = await _mediator.Send(query);
            return Ok(empleados);
        }

        [HttpPost(Name = "NuevoEmpleado")]
        public async Task<ActionResult<int>> NuevoEmpleado([FromBody] CreateEmpleadoCommand command)
        {
            return await _mediator.Send(command);
        }

        [HttpDelete(Name = "DeleteEmpleado")]
        public async Task<ActionResult<int>> DeleteEmpleado([FromBody] DeleteEmpleadoCommand command)
        {
            return await _mediator.Send(command);
        }
    }
}
