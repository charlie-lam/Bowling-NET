namespace Tests;
using BowlingLogic;

public class FrameTests
{
    [Fact]
    public void Frame_InitialisedWithFrameNumber()
    {
        //Arrange & Act
        var frame = new Frame(1);

        //Assert
        frame.frameNumber.Should().Be(1);
    }

    [Fact]
    public void Frame_InitialisedWithNull_ThrowsArgumentNullException()
    {
        //Act & Assert
        Assert.Throws<ArgumentNullException>(()=> new Frame(null));
    }

    [Fact]
    public void Frame_GetSetTest_SetsRollOne()
    {
        //Arrange
        var frame = new Frame(1);

        //Act
        frame.RollOne = 1;

        //Assert
        frame.RollOne.Should().Be(1);
    }

    [Theory]
    [InlineData(-1)]
    [InlineData(11)]

    public void Frame_InvalidRolls_ThrowsArgumentException(int pins)
    {
        //Arrange
        var frame = new Frame(1);

        //Act & Assert
        Assert.Throws<ArgumentException>(()=> frame.RollOne = pins);
    }

    [Fact]
    public void Frame_GetSetRollTwoTest_SetsRollTwo()
    {
        //Arrange
        var frame = new Frame(1);

        //Act
        frame.RollOne = 1;
        frame.RollTwo = 5;

        //Assert
        frame.RollOne.Should().Be(1);
        frame.RollTwo.Should().Be(5);
    }
}