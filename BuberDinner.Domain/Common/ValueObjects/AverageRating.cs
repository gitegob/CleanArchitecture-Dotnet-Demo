using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.Common.ValueObjects;

public sealed class AverageRating : ValueObject
{
    private AverageRating(double value, int numberOfRatings)
    {
        Value = value;
        NumberOfRatings = numberOfRatings;
    }

    public double Value { get; private set; }
    public int NumberOfRatings { get; private set; }

    protected override IEnumerable<object?> GetEqualityComponents()
    {
        yield return Value;
    }

    public static AverageRating Create(double value, int numberOfRatings) => new(value, numberOfRatings);
    public void AddNewRating(double newRating)
    {
        Value = (Value * NumberOfRatings + newRating) / ++NumberOfRatings;
    }
      
    public void RemoveRating(double newRating)
    {
        Value = (Value * NumberOfRatings - newRating) / --NumberOfRatings;
    }
}