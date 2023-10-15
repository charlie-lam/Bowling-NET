namespace Tests;
using BowlingLogic;

public class FrameFactoryTests
{
    [Theory]
    [AutoSubstituteData]
    public void FrameFactory_InstantiatesNewFrame(FrameFactory frameFactory)
    {
        //Act
        var frame = frameFactory.CreateFrame(1);
        //Assert
        frame.FrameNumber.Should().Be(1);
    }
}