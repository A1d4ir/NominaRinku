using MediatR;
using Microsoft.AspNetCore.Mvc;

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


    }
}
