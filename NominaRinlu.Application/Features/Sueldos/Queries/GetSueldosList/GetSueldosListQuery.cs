using MediatR;

namespace NominaRinku.Application.Features.Sueldos.Queries.GetSueldosList
{
    public class GetSueldosListQuery: IRequest<List<SueldosVm>>
    {
        public int _EmpleadoId { get; set; }

        public GetSueldosListQuery(int empleadoId)
        {
            _EmpleadoId = empleadoId;
        }
    }
}
