using ApiColegio.Application.Abstractions.Messaging;

namespace ApiColegio.Application.Features.Users.Commands.CreateUser;

public record CreateUserCommand(
   string FirstName,
   string LastName,
   DateTime DateOfBirth,
   string PhoneNumber,
   string Role,
   DateTime StartDate) : ICommand;
