namespace BowlingLogic;

public class FrameFactory : IFrameFactory
{
    public IFrame CreateFrame(int frameNumber)
    {
        return new Frame(frameNumber);
    }
}