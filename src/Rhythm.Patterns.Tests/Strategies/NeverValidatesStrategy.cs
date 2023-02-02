namespace Rhythm.Patterns.Tests.Strategies;

using Rhythm.Patterns.Strategies;

internal sealed class NeverValidatesStrategy : Strategy<object, string>
{
    protected override string? Execute(object input)
    {
        return null;
    }

    protected override bool ValidateInput(object? input)
    {
        return false;
    }
}
