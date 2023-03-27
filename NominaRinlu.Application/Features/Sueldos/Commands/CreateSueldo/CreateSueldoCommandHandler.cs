using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using NominaRinku.Application.Contracts.Persistense;
using NominaRinku.Domain;

namespace NominaRinku.Application.Features.Sueldos.Commands.CreateSueldo
{
    public class CreateSueldoCommandHandler : IRequestHandler<CreateSueldoCommand, int>
    {
        private readonly ILogger<CreateSueldoCommandHandler> _logger;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public CreateSueldoCommandHandler(ILogger<CreateSueldoCommandHandler> logger, 
            IMapper mapper, 
            IUnitOfWork unitOfWork)
        {
            _logger=logger;
            _mapper=mapper;
            _unitOfWork=unitOfWork;
        }

        public async Task<int> Handle(CreateSueldoCommand request, CancellationToken cancellationToken)
        {
            var sueldoEntity = _mapper.Map<Sueldo>(request);

            _unitOfWork.Repository<Sueldo>().AddEntity(sueldoEntity);

            var result = await _unitOfWork.Complete();

            if(result <= 0)
            {
                _logger.LogError("No se registro el sueldo");
                throw new Exception("No se pudo registrar el sueldo");
            }

            return sueldoEntity.Id;
        }
    }
}
