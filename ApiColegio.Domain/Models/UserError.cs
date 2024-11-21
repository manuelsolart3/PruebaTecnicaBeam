using ApiColegio.Domain.Abstractions;

namespace ApiColegio.Domain.Models;

public static class UserError
{
    public static readonly Error CreationFailed = new(
        "User.CreationFailed ",
        "Failed to create user");
}
