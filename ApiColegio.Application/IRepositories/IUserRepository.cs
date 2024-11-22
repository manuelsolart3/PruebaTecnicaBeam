using ApiColegio.Domain.Models;

namespace ApiColegio.Infrastructure.Repositories;
public interface IUserRepository
{
    IQueryable<User> Queryable();
}
