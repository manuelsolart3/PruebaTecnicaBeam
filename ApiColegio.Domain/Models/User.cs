using Microsoft.AspNetCore.Identity;

namespace ApiColegio.Domain.Models;

public class User : IdentityUser
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string PhoneNumber { get; set; }
    public string Role { get; set; }
    public DateTime StartDate { get; set; }
    public bool Status { get; set; }


    public User(string firstName,string lastName, DateTime dateOfBirth, string phoneNumber, string role, DateTime startDate)
    {
        FirstName = firstName;
        LastName = lastName;
        DateOfBirth = dateOfBirth;
        PhoneNumber = phoneNumber;
        Role = role;
        StartDate = startDate;
        Status = true;
    }


    public static User Create(
        string firstName,
        string lastName, 
        DateTime dateOfBirth,
        string phoneNumber, 
        string role,
        DateTime startDate)
    {
        return new User(
            firstName,
            lastName,
            dateOfBirth,
            phoneNumber,
            role,
            startDate);
    }
}

