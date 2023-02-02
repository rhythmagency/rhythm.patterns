namespace Rhythm.Patterns.Tests.Strategies;

using Rhythm.Patterns.Strategies;

internal sealed class AlwaysReturnsDefaultStrategy : Strategy<object, string>
{
    protected override string? Execute(object input)
    {
        return default;
    }

    protected override bool ValidateInput(object? input)
    {
        return true;
    }
}
