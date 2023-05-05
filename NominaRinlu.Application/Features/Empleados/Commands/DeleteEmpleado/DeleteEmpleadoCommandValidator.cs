using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NominaRinku.Application.Features.Empleados.Commands.DeleteEmpleado
{
    public class DeleteEmpleadoCommandValidator: AbstractValidator<DeleteEmpleadoCommand>
    {
        public DeleteEmpleadoCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotNull().WithMessage("Id no puede ser nulo");
        }
    }
}
