namespace Rhythm.Patterns.Tests.Strategies;

using Rhythm.Patterns.Strategies;

internal sealed class AlwaysReturnsStringEmptyStrategy : Strategy<object, string>
{
    protected override string? Execute(object input)
    {
        return string.Empty;
    }

    protected override bool ValidateInput(object? input)
    {
        return true;
    }
}