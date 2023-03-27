using FluentValidation;

namespace NominaRinku.Application.Features.Sueldos.Commands.CreateSueldo
{
    public class CreateSueldoCommandValidator: AbstractValidator<CreateSueldoCommand>
    {
        public CreateSueldoCommandValidator()
        {
            RuleFor(p => p.EmpleadoId)
                .NotNull().WithMessage("El numero de empleado no puede ser nulo");
        }
    }
}
