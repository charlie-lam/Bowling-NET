namespace BowlingLogic;

public class FrameFactory
{
    public IFrame CreateFrame(int frameNumber)
    {
        return new Frame(frameNumber);
    }
}