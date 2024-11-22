using ApiColegio.Domain.Abstractions;

namespace ApiColegio.Domain.Models;

public static class UserError
{
    public static readonly Error CreationFailed = new(
        "User.CreationFailed ",
        "Failed to create user");

    public static readonly Error UserNotFound = new(
        "User.UserNotFound ",
        "Failed to find the  user");

    public static readonly Error UpdatedFailed = new(
        "User.UpdatedFailed ",
        "Failed to Update user");

    public static readonly Error DeleteFailed = new(
     "User.DeleteFailed",
     "Failed to Delete user");
}
