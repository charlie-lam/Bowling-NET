namespace BowlingLogic;

public class Bowling
{
    private bool _hasStarted;
    private bool _hasEnded;

    private IScoreboard _scoreboard;
    private IFrameFactory _frameFactory;

    public Bowling(IScoreboard scoreboard, IFrameFactory frameFactory)
    {
        _scoreboard = scoreboard ?? throw new ArgumentNullException(nameof(scoreboard));
        _frameFactory = frameFactory ?? throw new ArgumentNullException(nameof(frameFactory));

        _hasStarted = false;
        _hasEnded = false;
    }

    public bool HasStarted => _hasStarted;
    public bool HasEnded => _hasEnded;

    public IScoreboard Scoreboard => _scoreboard;

    private void ChangedHasStarted()
    {
        _hasStarted = !_hasStarted;
    }

    private void ChangedHasEnded()
    {
        _hasEnded = !_hasEnded;
    }

    public void StartGame()
    {
        ChangedHasStarted();
        GenerateAndAddNewFrame(1);
    }

    public void TakeRoll(int pins)
    {
        if (!HasStarted || HasEnded) throw new Exception("Game not in a playable state");
        var latestFrame = Scoreboard.Frames.Last();
        int rollNumber = 1;

        if (latestFrame.RollOne.HasValue)
        {
            rollNumber = 2;
        }

        if (latestFrame.RollTwo.HasValue)
        {
            rollNumber = 3;
        }
        var latestFrameNumber = latestFrame.FrameNumber;

        switch (rollNumber)
        {
            case 1:
                latestFrame.RollOne ??= pins;
                if (pins == 10)
                {
                    GenerateAndAddNewFrame(latestFrameNumber + 1);
                }
                break;
            case 2:
                latestFrame.RollTwo ??= pins;
                if (latestFrame.FrameNumber != 10)
                {
                    GenerateAndAddNewFrame(latestFrameNumber + 1);
                }
                else if (latestFrame.RollOne + latestFrame.RollTwo != 10)
                {
                    ChangedHasEnded();
                }
                break;
            case 3:
                latestFrame.RollThree ??= pins;
                ChangedHasEnded();
                break;
            default:
                throw new ArgumentException("Roll number out of range");
        }
    }

    private void GenerateAndAddNewFrame(int frameNumber)
    {
        var frame = _frameFactory.CreateFrame(frameNumber);
        Scoreboard.AddFrame(frame);
    }
}
