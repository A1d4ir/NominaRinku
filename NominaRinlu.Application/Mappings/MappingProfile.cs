using AutoMapper;
using NominaRinku.Domain;
using NominaRinlu.Application.Features.Empleados.Commands.CreateEmpleado;

namespace NominaRinlu.Application.Mappings
{
    internal class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMap<CreateEmpleadoCommand, Empleado>();
        }
    }
}
