using FluentValidation;

namespace ApiColegio.Application.Features.Users.Commands.UpdateUser;

public class UpdateUserValidator : AbstractValidator<UpdateUserCommand>
{
    public UpdateUserValidator()
    {
        RuleFor(x => x.DateOfBirth)
           .Must(BeAValidDateOfBirth)
           .When(x => x.DateOfBirth.HasValue)
           .WithMessage("La fecha de nacimiento debe tener una fecha valida");

        RuleFor(x => x.StartDate)
            .Must(BeAValidStartDate)
            .When(x => x.StartDate.HasValue)
            .WithMessage("La fecha de inicio debe tener una fecha valida");
    }
    private bool BeAValidDateOfBirth(DateTime? date)
    {
        if (!date.HasValue)
        {
            return true;
        }
        return date.Value.Year > 1900 && date.Value <= DateTime.Today;
    }

    private bool BeAValidStartDate(DateTime? date)
    {
        if (!date.HasValue)
        {
            return true;
        }
        return date.Value <= DateTime.Today;
    }
}
