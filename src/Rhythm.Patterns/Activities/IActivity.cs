namespace Rhythm.Patterns.Activities;

/// <summary>
/// A contract for a single responsibility activity class that takes an input and returns an output.
/// </summary>
/// <typeparam name="TInput">The input.</typeparam>
/// <typeparam name="TOutput">The output.</typeparam>
public interface IActivity<in TInput, out TOutput>
{
    /// <summary>
    /// The execute method that returns an output for a given input.
    /// </summary>
    /// <param name="input">The input.</param>
    /// <returns>The output.</returns>
    TOutput Execute(TInput input);
}

/// <summary>
/// A contract for a single responsibility activity class that returns an output.
/// </summary>
/// <typeparam name="TOutput">The output.</typeparam>
public interface IActivity<out TOutput>
{
    /// <summary>
    /// The execute method that returns an output.
    /// </summary>
    /// <returns>The output.</returns>
    TOutput Execute();
}

/// <summary>
/// A contract for a single responsibility activity class that returns no output.
/// </summary>
public interface IActivity
{
    /// <summary>
    /// The execute method that returns no output.
    /// </summary>
    void Execute();
}
