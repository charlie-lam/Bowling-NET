namespace BowlingLogic;

public class Scoreboard : IScoreboard
{
    private List<IFrame> _frames;
    private List<int> _bonusScores;

    public IReadOnlyList<IFrame> Frames => _frames;
    public IReadOnlyList<int> BonusScores => _bonusScores;

    public Scoreboard()
    {
        _frames = new List<IFrame>();
        _bonusScores = new List<int>();
    }

    public void AddFrame(IFrame frame)
    {
        if(CanAddToList(_frames.Count))
        {
            _frames.Add(frame);
        }
    }

    public void CalculateBonus(IFrame frame)
    {
        var twoFramesBefore = Frames.ElementAtOrDefault(frame.FrameNumber - 3);
        var oneFrameBefore = Frames.ElementAtOrDefault(frame.FrameNumber - 2);

        if (TwoFramesBeforeIsAStrike(twoFramesBefore, oneFrameBefore))
        {
            UpdateBonusScore(frame.RollOne ?? 0, twoFramesBefore.FrameNumber);
        }
        if (PreviousFrameIsAStrike(oneFrameBefore))
        {
            var bonus = (frame.RollOne ?? 0) + (frame.RollTwo ?? 0);
            UpdateBonusScore(bonus, oneFrameBefore.FrameNumber);
        }
        if (PreviousFrameIsASpare(oneFrameBefore))
        {
            UpdateBonusScore(frame.RollOne ?? 0, oneFrameBefore.FrameNumber);
        }
    }

    private static bool PreviousFrameIsASpare(IFrame oneFrameBefore)
    {
        return oneFrameBefore != null && oneFrameBefore.RollOne + oneFrameBefore.RollTwo == 10 && oneFrameBefore.RollTwo != 0;
    }

    private static bool PreviousFrameIsAStrike(IFrame oneFrameBefore)
    {
        return oneFrameBefore != null && oneFrameBefore.RollOne == 10;
    }

    private static bool TwoFramesBeforeIsAStrike(IFrame? twoFramesBefore, IFrame oneFrameBefore)
    {
        return twoFramesBefore != null && twoFramesBefore.RollOne == 10 && oneFrameBefore!.RollOne == 10;
    }

    public void AddBonusScore()
    {
        if(CanAddToList(_bonusScores.Count)) _bonusScores.Add(0);
    }

    private void UpdateBonusScore(int score, int frameNumber)
    {
        var index = frameNumber - 1;
        if (index >= 0 && index < _bonusScores.Count && IsValidNumber(score))
        {
            _bonusScores[index] += score;
        }
    }

    private bool IsValidNumber(int score)
    {
        return score is <= 10 and >= 0;
    }

    private bool CanAddToList(int count)
    {
        return count < 10;
    }
}