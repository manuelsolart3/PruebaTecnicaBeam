using ApiColegio.Application.Abstractions.Messaging;
using ApiColegio.Application.Features.Users.Queries.GetActiveUsers;
using ApiColegio.Domain.Abstractions;
using ApiColegio.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ApiColegio.Application.Features.Users.Queries.GetUserByName;

public class GetUsersByNameQueryHandler : IQueryHandler<GetUsersByNameQuery, Pageable>
{
    private readonly IUserRepository _userRepository;

    public GetUsersByNameQueryHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<Result<Pageable>> Handle(GetUsersByNameQuery request, CancellationToken cancellationToken)
    {
        var page = new Page(request.PageNumber, request.PageSize);
        var users = await FetchData(request.Name, page, cancellationToken);
        return Result.Success(users);
    }

    private async Task<Pageable> FetchData(string name, Page page, CancellationToken cancellationToken)
    {
        var query = _userRepository
            .Queryable()
            .Where(u => u.FirstName.Contains(name) || u.LastName.Contains(name)) 
            .Select(u => new GetUsersByNameReponse
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
