using AutoMapper;
using NominaRinku.Domain;
using NominaRinku.Application.Features.Empleados.Commands.CreateEmpleado;
using NominaRinku.Application.Features.Sueldos.Commands.CreateSueldo;

namespace NominaRinku.Application.Mappings
{
    internal class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMap<CreateEmpleadoCommand, Empleado>();
            CreateMap<CreateSueldoCommand, Sueldo>();
        }
    }
}
