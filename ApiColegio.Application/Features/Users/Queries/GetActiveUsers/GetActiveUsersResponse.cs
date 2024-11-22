namespace ApiColegio.Application.Features.Users.Queries.GetActiveUsers;

public  class GetActiveUsersResponse
{
    public string Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string PhoneNumber { get; set; }
    public string Role { get; set; }
    public DateTime StartDate { get; set; }
    public bool Status { get; set; }

}
