using ApiColegio.Application.Abstractions.Messaging;
using ApiColegio.Application.Features.Users.Queries.GetActiveUsers;
using ApiColegio.Domain.Abstractions;
using ApiColegio.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ApiColegio.Application.Features.Users.Queries.GetUsersByRole;

public class GetUsersByRoleQueryHandler : IQueryHandler<GetUsersByRoleQuery, Pageable>
{
    private readonly IUserRepository _userRepository;

    public GetUsersByRoleQueryHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<Result<Pageable>> Handle(GetUsersByRoleQuery request, CancellationToken cancellationToken)
    {
        var page = new Page(request.PageNumber, request.PageSize);
        var users = await FetchData(request.Role, page, cancellationToken);
        return Result.Success(users);
    }

    private async Task<Pageable> FetchData(string role, Page page, CancellationToken cancellationToken)
    {
        var query = _userRepository
            .Queryable()
            .Where(u => u.Role == role)
            .Select(u => new GetUsersByRoleResponse
            {
                Id = u.Id,
                FirstName = u.FirstName,
                LastName = u.LastName,
                DateOfBirth = u.DateOfBirth,
                PhoneNumber = u.PhoneNumber,
                Role = u.Role,
                StartDate = u.StartDate,
                Status = u.Status
            })
             .OrderByDescending(u => u.StartDate);

        var totalItems = await query.CountAsync(cancellationToken);

        var userResponses = await query
            .Skip(page.Start())
            .Take(page.PageSize)
            .ToListAsync(cancellationToken);

        return new Pageable
        {
            ResultList = userResponses,
            Count = totalItems
        };
    }
}

