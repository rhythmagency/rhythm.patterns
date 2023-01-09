namespace Rhythm.Patterns.Tests.Strategies;

using Rhythm.Patterns.Strategies;

internal sealed class AlwaysValidatesStrategy : Strategy<object, string>
{
    public const string Output = "output";

    protected override string? Execute(object? input)
    {
        return Output;
    }

    protected override bool ValidateInput(object? input)
    {
        return true;
    }
}