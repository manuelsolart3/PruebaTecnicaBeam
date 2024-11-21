using FluentValidation;

namespace ApiColegio.Application.Features.Users.Commands.CreateUser;

public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
{
    public CreateUserCommandValidator()
    {
        RuleFor(x => x.FirstName)
            .NotEmpty().WithMessage("El nombre es obligatorio")
            .MaximumLength(50).WithMessage("El nombre no puede superar los 50 caracteres");

        RuleFor(x => x.LastName)
            .NotEmpty().WithMessage("El apellido es obligatorio")
            .MaximumLength(50).WithMessage("El apellido no puede superar los 50 caracteres");

        RuleFor(x => x.DateOfBirth)
            .LessThan(DateTime.Now).WithMessage("La fecha de nacimiento debe ser anterior a la fecha actual");

        RuleFor(x => x.PhoneNumber)
            .NotEmpty().WithMessage("El número de teléfono es obligatorio");

        RuleFor(x => x.Role)
            .NotEmpty().WithMessage("El rol es obligatorio");

        RuleFor(x => x.StartDate)
       .GreaterThanOrEqualTo(DateTime.Now.AddYears(-100).Date)
       .WithMessage("La fecha de inicio no puede ser más antigua que 100 años")
            .LessThan(DateTime.Now).WithMessage("La fecha de inicio no puede ser en el futuro");
    }
}