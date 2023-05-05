using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using NominaRinku.Application.Contracts.Persistense;
using NominaRinku.Domain;
using System.Security.Cryptography.X509Certificates;

namespace NominaRinku.Application.Features.Empleados.Commands.DeleteEmpleado
{
    internal class DeleteEmpleadoCommandHandler : IRequestHandler<DeleteEmpleadoCommand, int>
    {
        private readonly ILogger<DeleteEmpleadoCommand> _logger;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteEmpleadoCommandHandler(ILogger<DeleteEmpleadoCommand> logger, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<int> Handle(DeleteEmpleadoCommand request, CancellationToken cancellationToken)
        {
            var empleadoEntity = _mapper.Map<Empleado>(request);

            var sueldos = _unitOfWork.Repository<Sueldo>().GetAllAsync()

            _unitOfWork.Repository<Empleado>().DeleteEntity(empleadoEntity);

            var respuesta = await _unitOfWork.Complete();

            if(respuesta <= 0 )
            {
                _logger.LogError("No se pudo borrar el empleado");
                throw new Exception("No se pudo borrar el emplado");
            }

            return respuesta;

        }
    }
}
