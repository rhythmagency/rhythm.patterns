namespace Rhythm.Patterns.Strategies;

public static class StrategyCollectionExtensions
{
    /// <summary>
    /// Executes and returns the output of the first strategy that returns true. 
    /// </summary>
    /// <typeparam name="TInput">The type of the input.</typeparam>
    /// <typeparam name="TOutput">The type of the output.</typeparam>
    /// <param name="strategies">The collection of strategies.</param>
    /// <param name="input">The input.</param>
    /// <returns>A <typeparamref name="TOutput"/>.</returns>
    /// <remarks>This method can return a null/default value as a valid strategy may return a null value.</remarks>
    public static TOutput? Execute<TInput, TOutput>(this IEnumerable<IStrategy<TInput, TOutput>?>? strategies, TInput input)
    {
        if (strategies is null)
        {
            return default;
        }

        foreach (var strategy in strategies)
        {
            if (strategy is null)
            {
                continue;
            }

            var result = strategy.TryExecute(input);

            if (result.IsSuccessful)
            {
                return result.Output;
            }
        }

        return default;
    }

    public static IReadOnlyCollection<string> ExecuteMultiple<TInput>(this IEnumerable<IStrategy<TInput, string?>>? strategies, TInput input)
    {
        return strategies.ExecuteMultiple(input, string.IsNullOrEmpty);
    }

    public static IReadOnlyCollection<TOutput> ExecuteMultiple<TInput, TOutput>(this IEnumerable<IStrategy<TInput, TOutput?>>? strategies, TInput input)
    {
        return strategies.ExecuteMultiple(input, x => x is null);
    }

    /// <summary>
    /// Executes and collates all non-null outputs from valid strategies.
    /// </summary>
    /// <typeparam name="TInput">The type of the input.</typeparam>
    /// <typeparam name="TOutput">The type of the output.</typeparam>
    /// <param name="strategies">The collection of strategies.</param>
    /// <param name="input">The input.</param>
    /// <param name="ignoredValuesFilter">THe function which filters out ignored values.</param>
    /// <returns>A readonly collection of <typeparamref name="TOutput"/> objects.</returns>
    /// <remarks>Unlike <see cref="Execute{TInput, TOutput}(IEnumerable{IStrategy{TInput, TOutput}}, TInput)"/>, null values will not be returned. </remarks>
    private static IReadOnlyCollection<TOutput> ExecuteMultiple<TInput, TOutput>(this IEnumerable<IStrategy<TInput, TOutput?>>? strategies, TInput input, Func<TOutput?, bool> ignoredValuesFilter)
    {
        if (strategies is null)
        {
            return Array.Empty<TOutput>();
        }

        var results = new List<TOutput>();

        foreach (var strategy in strategies)
        {
            if (strategy is null)
            {
                continue;
            }

            var result = strategy.TryExecute(input);

            if (!result.IsSuccessful)
            {
                continue;
            }

            if (result.Output is not null && ignoredValuesFilter.Invoke(result.Output) == false)
            {
                results.Add(result.Output);
            }
        }

        return results.ToArray();
    }
}
