using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using NominaRinku.Domain;
using NominaRinlu.Application.Contracts.Persistense;

namespace NominaRinlu.Application.Features.Empleados.Commands.CreateEmpleado
{
    public class CreateEmpleadoCommandHandler : IRequestHandler<CreateEmpleadoCommand, int>
    {
        private readonly ILogger<CreateEmpleadoCommandHandler> _logger;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public CreateEmpleadoCommandHandler(
            ILogger<CreateEmpleadoCommandHandler> logger, 
            IMapper mapper, 
            IUnitOfWork unitOfWork
        )
        {
            _logger=logger;
            _mapper=mapper;
            _unitOfWork=unitOfWork;
        }

        public async Task<int> Handle(CreateEmpleadoCommand request, CancellationToken cancellationToken)
        {
            var empleadoEntity = _mapper.Map<Empleado>(request);
            
            _unitOfWork.Repository<Empleado>().AddEntity(empleadoEntity);

            var result = await _unitOfWork.Complete();

            if(result <= 0)
            {
                _logger.LogError("No se registro el empleado");
                throw new Exception("No se pudo registrar el empleado");
            }

            return empleadoEntity.Id;
        }
    }
}
