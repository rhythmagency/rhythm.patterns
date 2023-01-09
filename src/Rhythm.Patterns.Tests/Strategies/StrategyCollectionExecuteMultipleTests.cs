namespace Rhythm.Patterns.Tests.Strategies;

using Rhythm.Patterns.Strategies;

public class StrategyCollectionExecuteMultipleTests
{
    [Test]
    public void Given_A_Null_Collection_Of_Strategies_Return_An_Empty_Array()
    {
        // Arrange
        IStrategy<object, string?>[]? strategies = null;
        var input = string.Empty;

        // Act
        var output = strategies.ExecuteMultiple(input);

        // Assert
        Assert.That(output, Is.Not.Null);
        Assert.That(output, Is.Empty);
    }

    [Test]
    public void Given_A_Collection_Of_Some_Valid_Strategies_Only_Return_Valid_NotNull_Values()
    {
        // Arrange
        var strategies = new IStrategy<object, string?>[]
        {
            new NeverValidatesStrategy(),
            new AlwaysValidatesStrategy(),
            new AlwaysReturnsDefaultStrategy(),
        };
        var input = string.Empty;

        // Act
        var output = strategies.ExecuteMultiple(input);

        // Assert
        Assert.That(output, Is.Not.Null);
        Assert.That(output, Contains.Item(AlwaysValidatesStrategy.Output));
        Assert.That(output, Has.Count.EqualTo(1));
    }

    [Test]
    public void Given_A_Collection_Of_No_Valid_Strategies_Return_No_Values()
    {
        // Arrange
        var strategies = new IStrategy<object, string?>[]
        {
            new NeverValidatesStrategy(),
            new AlwaysReturnsDefaultStrategy(),
        };
        var input = string.Empty;

        // Act
        var output = strategies.ExecuteMultiple(input);

        // Assert
        Assert.That(output, Is.Not.Null);
        Assert.That(output, Is.Empty);
    }
}