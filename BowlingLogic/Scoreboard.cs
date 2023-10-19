namespace BowlingLogic;

public class Scoreboard
{
    private readonly List<Frame> _frames;
    private readonly List<int> _baseScore;
    private readonly List<int> _bonusScore;

    public Scoreboard()
    {
        _frames = new List<Frame>();
        _baseScore = new List<int>();
        _bonusScore = new List<int>();
    }

    public void AddFrame(Frame frame)
    {
        _frames.Add(frame);
    }

    public void AddBaseScore(int score)
    {
        _baseScore.Add(score);
    }
    
    public void AddBonusScore(int score)
    {
        _bonusScore.Add(score);
    }
}