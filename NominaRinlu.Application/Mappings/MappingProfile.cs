using AutoMapper;
using NominaRinku.Domain;
using NominaRinku.Application.Features.Empleados.Commands.CreateEmpleado;
using NominaRinku.Application.Features.Sueldos.Commands.CreateSueldo;
using NominaRinku.Application.Features.Sueldos.Queries.GetSueldosList;
using NominaRinku.Application.Features.Empleados.Queries.GetEmpleadosList;

namespace NominaRinku.Application.Mappings
{
    internal class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMap<Sueldo, SueldosVm>();
            CreateMap<Empleado, EmpleadosVm>();
            CreateMap<CreateEmpleadoCommand, Empleado>();
            CreateMap<CreateSueldoCommand, Sueldo>();
        }
    }
}
