using ApiColegio.Application.Abstractions.Messaging;
using ApiColegio.Domain.Abstractions;
using ApiColegio.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace ApiColegio.Application.Features.Users.Commands.CreateUser;

public class CreateUserCommandHandler : ICommandHandler<CreateUserCommand>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly UserManager<User> _userManager;

    public CreateUserCommandHandler(IUnitOfWork unitOfWork, UserManager<User> userManager)
    {
        _unitOfWork = unitOfWork;
        _userManager = userManager;
    }

    public async Task<Result> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var user = User.Create(
            request.FirstName,
            request.LastName,
            request.DateOfBirth,
            request.PhoneNumber,
            request.Role,
            request.StartDate);

        var result = await _userManager.CreateAsync(user);

        if (!result.Succeeded)
        {
            return Result.Failure(UserError.CreationFailed);
        }
        return Result.Success();
    }
}
