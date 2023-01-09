namespace Rhythm.Patterns.Strategies;

/// <summary>
/// A contract for implementing a class that tries to return an <typeparamref name="TOutput"/> from a given <typeparamref name="TInput"/>.
/// </summary>
/// <typeparam name="TInput">The input.</typeparam>
/// <typeparam name="TOutput">The output.</typeparam>
public interface IStrategy<in TInput, TOutput>
{
    /// <summary>
    /// Tries to execute this strategy for a given input.
    /// </summary>
    /// <param name="input">The input.</param>
    /// <returns>A <see cref="IStrategyResult{TOutput}"/> which determines whether it was successful or not.</returns>
    IStrategyResult<TOutput> TryExecute(TInput input);
}
