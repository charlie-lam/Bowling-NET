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

    private void UpdateHasStarted()
    {
        _hasStarted = !_hasStarted;
    }

    private void UpdateHasEnded()
    {
        _hasEnded = !_hasEnded;
    }

    public void StartGame()
    {
        UpdateHasStarted();
        GenerateAndAddNewFrame(1);
    }

    public void TakeRoll(int pins)
    {
        if (!HasStarted || HasEnded) throw new Exception("Game not in a playable state");
        var latestFrame = Scoreboard.Frames.Last();
        var latestFrameNumber = latestFrame.FrameNumber;

        if (!latestFrame.RollOne.HasValue)
        {
            latestFrame.RollOne ??= pins;
            if (pins == 10)
            {
                Scoreboard.CalculateBonus(latestFrame);
                GenerateAndAddNewFrame(latestFrameNumber + 1);
            }
        }

        else if (!latestFrame.RollTwo.HasValue)
        {
            latestFrame.RollTwo ??= pins;
            if (latestFrame.FrameNumber != 10)
            {
                Scoreboard.CalculateBonus(latestFrame);
                GenerateAndAddNewFrame(latestFrameNumber + 1);
            }
            else if (latestFrame.RollOne + latestFrame.RollTwo != 10)
            {
                UpdateHasEnded();
            }
        }

        else if (!latestFrame.RollThree.HasValue)
        {
            latestFrame.RollThree ??= pins;
            Scoreboard.CalculateBonus(latestFrame);
            UpdateHasEnded();
        }

        else
        {
            throw new ArgumentException("Roll number out of range");
        }
    }

    private void GenerateAndAddNewFrame(int frameNumber)
    {
        var frame = _frameFactory.CreateFrame(frameNumber);
        Scoreboard.AddBonusScore();
        Scoreboard.AddFrame(frame);
    }
}
