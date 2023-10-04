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
}