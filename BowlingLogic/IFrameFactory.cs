namespace BowlingLogic
{
    public interface IFrameFactory
    {
        IFrame CreateFrame(int frameNumber);
    }
}