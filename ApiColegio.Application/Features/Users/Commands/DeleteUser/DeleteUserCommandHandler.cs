using ApiColegio.Application.Abstractions.Messaging;
using ApiColegio.Domain.Abstractions;
using ApiColegio.Domain.Models;
using Microsoft.AspNetCore.Identity;

namespace ApiColegio.Application.Features.Users.Commands.DeleteUser;

public class DeleteUserCommandHandler : ICommandHandler<DeleteUserCommand>
{
    private readonly UserManager<User> _userManager;

    public DeleteUserCommandHandler(UserManager<User> userManager)
    {
        _userManager = userManager;
    }

    public async Task<Result> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _userManager.FindByIdAsync(request.UserId);

        if (user is null)
        {
            return Result.Failure(UserError.UserNotFound);
        }

        var result = await _userManager.DeleteAsync(user);

        if (!result.Succeeded)
        {
            return Result.Failure(UserError.UpdatedFailed);
        }

        return Result.Success();
    }
}
