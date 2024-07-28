using BuberDinner.Application.Repositories;
using BuberDinner.Domain.Auth.Entities;

namespace BuberDinner.Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    private static readonly HashSet<User> users = [];

    public void AddUser(User user)
    {
        users.Add(user);
    }

    public User? GetUserByEmail(string email)
    {
        return users.SingleOrDefault(u => u.Email == email);
    }
}