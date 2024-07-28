using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.Dinner.ValueObjects;

public sealed class DinnerId : ValueObject
{
    private DinnerId(Guid value)
    {
        Value = value;
    }

    public Guid Value { get; }

    protected override IEnumerable<object?> GetEqualityComponents()
    {
        yield return Value;
    }
    
    public static DinnerId CreateUnique() => new(Guid.NewGuid());

}