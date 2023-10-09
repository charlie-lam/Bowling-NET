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
    public void Frame_AddValidRoll_SetsRollOne()
    {
        //Arrange
        var frame = new Frame(1);

        //Act
        frame.RollOne = 1;

        var firstRoll = frame.RollOne;

        //Assert
        firstRoll.Should().Be(1);
    }
}