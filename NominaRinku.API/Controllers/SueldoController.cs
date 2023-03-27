using MediatR;
using Microsoft.AspNetCore.Mvc;
using NominaRinku.Application.Features.Sueldos.Commands.CreateSueldo;
using NominaRinku.Application.Features.Sueldos.Queries.GetSueldosList;
using System.Net;

namespace NominaRinku.API.Controllers
{
    [ApiController]
    [Route("api/sueldo")]
    public class SueldoController: ControllerBase
    {
        private readonly IMediator _mediator;

        public SueldoController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}", Name = "GetSueldos")]
        [ProducesResponseType(typeof(IEnumerable<SueldosVm>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<SueldosVm>>> GetSueldosById(int id)
        {
            var query = new GetSueldosListQuery(id);
            var sueldos = await _mediator.Send(query);
            return Ok(sueldos);
        }

        [HttpPost(Name = "NuevoMovimiento")]
        public async Task<ActionResult<int>> NuevoMovimiento([FromBody] CreateSueldoCommand command)
        {
            return await _mediator.Send(command);
        }
    }
}
