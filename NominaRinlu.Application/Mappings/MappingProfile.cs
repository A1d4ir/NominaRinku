using AutoMapper;
using NominaRinku.Domain;
using NominaRinku.Application.Features.Empleados.Commands.CreateEmpleado;

namespace NominaRinku.Application.Mappings
{
    internal class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMap<CreateEmpleadoCommand, Empleado>();
        }
    }
}
