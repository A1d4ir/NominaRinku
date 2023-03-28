using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using NominaRinku.Application.Contracts.Persistense;
using NominaRinku.Domain.Common;

namespace NominaRinku.Application.Features.Sueldos.Queries.GetSueldosList
{
    public class GetSueldosListQueryHandler : IRequestHandler<GetSueldosListQuery, List<SueldosVm>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetSueldosListQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<SueldosVm>> Handle(GetSueldosListQuery request, CancellationToken cancellationToken)
        {
            var sueldosList = await _unitOfWork.SueldoRepository.GetAsync(x => x.EmpleadoId == request._EmpleadoId);
            var empleado = await _unitOfWork.EmpleadoRepository.GetByIdAsync(request._EmpleadoId);

            var sueldos = new List<SueldosVm>();

            foreach(var sueldo in sueldosList)
            {
                var pagoPorEntregas = sueldo.Entregas * 5;
                var pagoPorBonos = empleado.Rol switch
                {
                    Roles.Chofer => 192 * 10,
                    Roles.Cargador => 192 * 5,
                    _ => 0
                };
                var sueldoFinal = (192 * 30) + pagoPorEntregas + pagoPorBonos;
                var retenciones = sueldoFinal > 10000 ? (decimal)(sueldoFinal * 12) / 100 : (decimal)(sueldoFinal * 9) / 100;
                var vales = (decimal)(sueldoFinal * 4) / 100;

                sueldos.Add(new SueldosVm
                    {
                        Id = sueldo.Id,
                        Mes = sueldo.Mes,
                        HorasTrabajadas = 192,
                        PagoPorEntregas = pagoPorEntregas,
                        PagoPorBonos = pagoPorBonos,
                        Retenciones = retenciones,
                        Vales = vales,
                        Sueldo = sueldoFinal - retenciones
                    }
                );
            }

            return _mapper.Map<List<SueldosVm>>(sueldos);
        }

    }
}
