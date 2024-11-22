using ApiColegio.Application.Abstractions.Messaging;

namespace ApiColegio.Application.Features.Users.Commands.LoginUser;

public record LoginUserCommand(string FirstName, string LastName) : ICommand<string>;
