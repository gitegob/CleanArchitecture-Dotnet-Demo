using ErrorOr;

namespace BuberDinner.Domain.Errors;

public static partial class Errors
{
    public static class Users
    {
        public static Error DuplicateEmail => Error.Conflict("auth.duplicate_email", "Email is already in use.");
    }
}