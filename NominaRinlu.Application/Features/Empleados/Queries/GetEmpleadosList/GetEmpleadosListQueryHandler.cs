using AutoMapper;
using MediatR;
using NominaRinku.Application.Contracts.Persistense;

namespace NominaRinku.Application.Features.Empleados.Queries.GetEmpleadosList
{
    public class GetEmpleadosListQueryHandler : IRequestHandler<GetEmpleadosListQuery, List<EmpleadosVm>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetEmpleadosListQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<EmpleadosVm>> Handle(GetEmpleadosListQuery request, CancellationToken cancellationToken)
        {
            var empleados = await _unitOfWork.EmpleadoRepository.GetAllAsync();

            return _mapper.Map<List<EmpleadosVm>>(empleados);
        }
    }
}
