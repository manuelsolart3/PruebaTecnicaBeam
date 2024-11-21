using ApiColegio.Application.Abstractions.Messaging;

namespace ApiColegio.Application.Features.Users.Commands.UpdateUser;

public record UpdateUserCommand(
    Guid Id,
    string? FirstName,
    string? LastName,
    DateTime? DateOfBirth,
    string? PhoneNumber,
    string? Role,
    DateTime? StartDate,
    bool? Status
) : ICommand;
