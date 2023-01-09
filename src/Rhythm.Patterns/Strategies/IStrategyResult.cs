namespace Rhythm.Patterns.Strategies;

/// <summary>
/// An contract for creating a result returned by a strategy.
/// </summary>
/// <typeparam name="TOutput">The type of the output.</typeparam>
public interface IStrategyResult<TOutput>
{
    /// <summary>
    /// Gets a value indicating if the strategy was successful or not.
    /// </summary>
    bool IsSuccessful { get; }

    /// <summary>
    /// Gets the output.
    /// </summary>
    /// <remarks>This will not likely be set if <see cref="IsSuccessful"/> is false.</remarks>
    TOutput Output { get; }
}
