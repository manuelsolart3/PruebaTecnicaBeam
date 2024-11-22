using ApiColegio.Application.Abstractions.Messaging;
using ApiColegio.Application.Authentication;
using ApiColegio.Domain.Abstractions;
using ApiColegio.Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ApiColegio.Application.Features.Users.Commands.LoginUser;

public class LoginUserCommandHandler : ICommandHandler<LoginUserCommand, string>
{
    private readonly UserManager<User> _userManager;
    private readonly JwtTokenService _jwtTokenService;

    public LoginUserCommandHandler(UserManager<User> userManager, JwtTokenService jwtTokenService)
    {
        _userManager = userManager;
        _jwtTokenService = jwtTokenService;
    }

    public async Task<Result<string>> Handle(LoginUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _userManager.Users
             .FirstOrDefaultAsync(u =>
                 u.FirstName == request.FirstName &&
                 u.LastName == request.LastName,
                 cancellationToken);
        if (user is null)
        {
            return Result.Failure<string>(UserError.UserNotFound);
        }

        var token = _jwtTokenService.GenerateToken(user);

        return Result.Success(token);
    }
}
