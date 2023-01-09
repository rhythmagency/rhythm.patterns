namespace Rhythm.Patterns.Tests.Strategies;

using Rhythm.Patterns.Strategies;

public class StrategyCollectionExecuteTests
{
    [Test]
    public void Given_A_Null_Collection_Of_Strategies_Return_Default()
    {
        // Arrange
        IStrategy<object, string?>[]? strategies = null;
        var input = string.Empty;

        // Act
        var output = strategies.Execute(input);

        // Assert
        Assert.That(output, Is.EqualTo(default));
    }


    [Test]
    public void Given_A_Collection_Of_Strategies_The_First_To_Validate_Should_Return_Expected_Value()
    {
        // Arrange
        var strategies = new IStrategy<object, string?>[]
        {
            new NeverValidatesStrategy(),
            new AlwaysValidatesStrategy(),
        };
        var input = string.Empty;

        // Act 
        var output = strategies.Execute(input);

        // Assert
        Assert.That(output, Is.EqualTo(AlwaysValidatesStrategy.Output));
    }

    [Test]
    public void Given_A_Collection_Of_Strategies_The_First_To_Validate_Should_Return_Expected_Value_Even_Default()
    {
        // Arrange
        var strategies = new IStrategy<object, string?>[]
        {
            new NeverValidatesStrategy(),
            new AlwaysReturnsDefaultStrategy(),
            new AlwaysValidatesStrategy(),
        };
        var input = string.Empty;

        // Act 
        var output = strategies.Execute(input);

        // Assert
        Assert.That(output, Is.EqualTo(default));
        Assert.That(output, Is.Not.EqualTo(AlwaysValidatesStrategy.Output));
    }


}