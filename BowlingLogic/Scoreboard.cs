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
    
    public void AddBonusScore(int score)
    {
        if(IsValidNumber(score) && CanAddToList(_bonusScores.Count))
        {
            _bonusScores.Add(score);
        }
    }

    public void UpdateBonusScore(int score, int frameNumber)
    {
        var index = frameNumber - 1;
        if (index >= 0 && index < _bonusScores.Count && IsValidNumber(score))
        {
            _bonusScores[index] += score;
        }
    }

    private bool IsValidNumber(int score)
    {
        return score is < 10 and > 0;
    }

    private bool CanAddToList(int count)
    {
        return count < 10;
    }
}