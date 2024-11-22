using ApiColegio.Application.Abstractions.Messaging;

namespace ApiColegio.Application.Features.Users.Commands.DeleteUser;

public record DeleteUserCommand(string UserId) : ICommand;
