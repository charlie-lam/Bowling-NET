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
    public void Frame_GetSet_SetsRollOne()
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

    [Fact]
    public void Frame_GetSetRollThree_SetsRollThree()
    {
        //Arrange
        var frame = new Frame(10);

        //Act
        frame.RollOne = 5;
        frame.RollTwo = 5;
        frame.RollThree = 9;

        //Assert
        frame.RollOne.Should().Be(5);
        frame.RollTwo.Should().Be(5);
        frame.RollThree.Should().Be(9);

    }

    [Fact]
    public void Frame_GetSetRollThreeTest_SetsRollThree()
    {
        //Arrange
        var frame = new Frame(10);

        //Act
        frame.RollOne = 5;
        frame.RollTwo = 5;
        frame.RollThree = 9;

        //Assert
        frame.RollOne.Should().Be(5);
        frame.RollTwo.Should().Be(5);
        frame.RollThree.Should().Be(9);

    }

    [Fact]
    public void Frame_NotFrameTenRollThreeInvalid_ThrowsArgumentException()
    {
        //Arrange
        var frame = new Frame(1);

        //Act
        frame.RollOne = 5;
        frame.RollTwo = 5;

        //Assert
        frame.RollOne.Should().Be(5);
        frame.RollTwo.Should().Be(5);
        Assert.Throws<Exception>(()=> frame.RollThree = 9);
    }

    [Fact]
    public void Frame_FrameTenRollThreeInvalidTotal_ThrowsArgumentException()
    {
        //Arrange
        var frame = new Frame(10);

        //Act
        frame.RollOne = 5;
        frame.RollTwo = 4;

        //Assert
        frame.RollOne.Should().Be(5);
        frame.RollTwo.Should().Be(4);
        Assert.Throws<Exception>(()=> frame.RollThree = 9);
    }
}