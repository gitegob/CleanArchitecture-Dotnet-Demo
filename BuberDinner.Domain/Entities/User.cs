using System.Text.Json.Serialization;

namespace BuberDinner.Domain.Entities;

public class User
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }

    [JsonIgnore] public string Password { get; set; }
}