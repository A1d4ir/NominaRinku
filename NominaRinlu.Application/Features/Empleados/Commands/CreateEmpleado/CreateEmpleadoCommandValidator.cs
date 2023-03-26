using FluentValidation;

namespace NominaRinlu.Application.Features.Empleados.Commands.CreateEmpleado
{
    public class CreateEmpleadoCommandValidator: AbstractValidator<CreateEmpleadoCommand>
    {
        public CreateEmpleadoCommandValidator()
        {
            RuleFor(p => p.Nombre)
                .NotNull().WithMessage("{Nombre} no puede ser nulo");
        }
    }
}
