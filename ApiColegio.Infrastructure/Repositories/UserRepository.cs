using ApiColegio.Domain.Models;
using ApiColegio.Infrastructure.Context;

namespace ApiColegio.Infrastructure.Repositories;
public class UserRepository : IUserRepository
{
    private readonly AppDbContext _context;

    public UserRepository(AppDbContext context)
    {
        _context = context;
    }

    public IQueryable<User> Queryable()
    {
        return _context.Users.AsQueryable();
    }
}

