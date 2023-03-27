using MediatR;
using Microsoft.AspNetCore.Mvc;
using NominaRinku.Application.Features.Sueldos.Commands.CreateSueldo;

namespace NominaRinku.API.Controllers
{
    [ApiController]
    [Route("api/sueldo")]
    public class SueldoController
    {
        private readonly IMediator _mediator;

        public SueldoController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost(Name = "NuevoMovimiento")]
        public async Task<ActionResult<int>> NuevoMovimiento([FromBody] CreateSueldoCommand command)
        {
            return await _mediator.Send(command);
        }
    }
}
