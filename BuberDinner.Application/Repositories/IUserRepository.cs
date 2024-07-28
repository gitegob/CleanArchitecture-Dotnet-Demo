using BuberDinner.Domain.Users.Entities;

namespace BuberDinner.Application.Repositories;

public interface IUserRepository
{
    void AddUser(User user);
    User? GetUserByEmail(string email);
}