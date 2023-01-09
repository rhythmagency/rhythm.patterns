namespace Rhythm.Patterns.Strategies;

/// <summary>
/// An abstract implementation of <see cref="IStrategy{TInput, TOutput}"/>.
/// </summary>
/// <remarks>This will validate the input before proceding.</remarks>
public abstract class Strategy<TInput, TOutput> : IStrategy<TInput, TOutput?>
{
    /// <inheritdoc />
    public IStrategyResult<TOutput?> TryExecute(TInput input)
    {
        if (ValidateInput(input) == false)
        {
            return StrategyResult<TOutput?>.Fail();
        }

        var output = Execute(input);

        return StrategyResult<TOutput?>.Succeed(output);
    }

    /// <summary>
    /// Executes the strategy.
    /// </summary>
    /// <param name="input">The input.</param>
    /// <returns>A <see cref="TOutput?"/>.</returns>
    protected abstract TOutput? Execute(TInput? input);

    /// <summary>
    /// Validating the incoming input on whether this strategy can be executed or not.
    /// </summary>
    /// <param name="input">The input.</param>
    /// <returns>A <see cref="bool"/> determining if it can continue or not.</returns>
    protected abstract bool ValidateInput(TInput? input);
}
