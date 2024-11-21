using ApiColegio.Application.Abstractions.Messaging;
using ApiColegio.Domain.Abstractions;
using ApiColegio.Domain.Models;
using Microsoft.AspNetCore.Identity;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace ApiColegio.Application.Features.Users.Commands.UpdateUser;

public class UpdateUserCommandHandler : ICommandHandler<UpdateUserCommand>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly UserManager<User> _userManager;

    public UpdateUserCommandHandler(IUnitOfWork unitOfWork, UserManager<User> userManager)
    {
        _unitOfWork = unitOfWork;
        _userManager = userManager;
    }

    public async Task<Result> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {   
        var user = await _userManager.FindByIdAsync(request.Id.ToString());

        if (user is null)
        {
            return Result.Failure(UserError.UserNotFound);
        }

        if (request.FirstName != null)
        {
            user.FirstName = request.FirstName;
        }

        if (request.LastName != null)
        {
            user.LastName = request.LastName;
        }

        if (request.DateOfBirth != null)
        {
            user.DateOfBirth = request.DateOfBirth.Value;
        }

        if (request.PhoneNumber != null)
        {
            user.PhoneNumber = request.PhoneNumber;
        }

        if (request.Role != null)
        {
            user.Role = request.Role;
        }

        if (request.StartDate != null)
        {
            user.StartDate = request.StartDate.Value;
        }

        if (request.Status.HasValue)
        {
            user.Status = request.Status.Value;
        }

        var result = await _userManager.UpdateAsync(user);

        if (result.Succeeded)
        {
            return Result.Success();
        }

        return Result.Failure(UserError.UpdatedFailed);
    }
}
