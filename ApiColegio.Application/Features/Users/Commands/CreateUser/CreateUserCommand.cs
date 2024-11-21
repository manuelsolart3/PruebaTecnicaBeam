using ApiColegio.Application.Abstractions.Messaging;

namespace ApiColegio.Application.Features.Users.Commands.CreateUser;

public record CreateUserCommand(
   string FirstName,
   string LastName,
   DateOnly DateOfBirth,
   string PhoneNumber,
   string Role,
   DateOnly StartDate,
   bool Status) : ICommand;
