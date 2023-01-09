namespace Rhythm.Patterns.Strategies;

/// <summary>
/// A fluent helper class which creates <see cref="StrategyResult{TOutput}"/> objects.
/// </summary>
public static class StrategyResult
{
    public static StrategyResult<TOutput> Succeed<TOutput>(TOutput output) => new(true, output);

    public static StrategyResult<TOutput?> Fail<TOutput>() => new(false, default);
}

/// <summary>
/// A concrete implementation of <see cref="IStrategyResult{TOutput}"/>.
/// </summary>
/// <typeparam name="TOutput">The type of the output.</typeparam>
public sealed class StrategyResult<TOutput> : IStrategyResult<TOutput>
{
    public static IStrategyResult<TOutput> Succeed(TOutput output) => StrategyResult.Succeed(output);

    public static IStrategyResult<TOutput?> Fail() => StrategyResult.Fail<TOutput>();

    /// <summary>
    /// Initializes a new instance of the <see cref="StrategyResult{TOutput}"/> class.
    /// </summary>
    /// <param name="isSuccessful">Whether this result is successful or not.</param>
    /// <param name="output">The output.</param>
    /// <remarks>This constructor should not be used directly. Use the static helper methods instead.</remarks>
    internal StrategyResult(bool isSuccessful, TOutput output)
	{
        IsSuccessful = isSuccessful;
        Output = output;
    }

    /// <inheritdoc />
    public bool IsSuccessful { get; }

    /// <inheritdoc />
    public TOutput Output { get; }
}
