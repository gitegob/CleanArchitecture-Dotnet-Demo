using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.Menu.ValueObjects;

public class MenuItemId : ValueObject
{
    private MenuItemId(Guid value)
    {
        Value = value;
    }

    public Guid Value { get; }

    protected override IEnumerable<object?> GetEqualityComponents()
    {
        yield return Value;
    }
    
    public static MenuItemId CreateUnique() => new(Guid.NewGuid());

}