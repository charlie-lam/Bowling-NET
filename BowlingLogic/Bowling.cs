namespace BowlingLogic;

public class Bowling
{
    private bool _hasStarted;
    private bool _hasEnded;
    private int _currentFrame;

    private IScoreboard _scoreboard;
    private IFrameFactory _frameFactory;

    public Bowling(IScoreboard scoreboard, IFrameFactory frameFactory)
    {
        _scoreboard = scoreboard ?? throw new ArgumentNullException(nameof(scoreboard));
        _frameFactory = frameFactory ?? throw new ArgumentNullException(nameof(frameFactory));

        _hasStarted = false;
        _hasEnded = false;
        _currentFrame = 0;
    }

    public void StartGame()
    {
        _hasStarted = true;
        var frame = GenerateNewFrame(1);
        _scoreboard.AddFrame(frame);
    }

    public void TakeRoll(int pins, int roll)
    {
        var latestFrame = _scoreboard.Frames.Last();
        var latestFrameNumber = latestFrame.FrameNumber;
        switch (roll)
        {
            case 1:
                latestFrame.RollOne ??= pins;
                break;
            case 2:
                latestFrame.RollTwo ??= pins;
                if(latestFrame.FrameNumber != 10)
                {
                    var nextFrame = _frameFactory.CreateFrame(latestFrameNumber + 1);
                    _scoreboard.AddFrame(nextFrame);
                }
                break;
            case 3:
                latestFrame.RollThree ??= pins;
                break;
            default:
                throw new ArgumentException("Roll number out of range");
        }
    }

    private IFrame GenerateNewFrame(int frameNumber)
    {
        var frame = _frameFactory.CreateFrame(frameNumber);
        return frame;
    }
}
