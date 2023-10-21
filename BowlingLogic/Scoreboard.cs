namespace BowlingLogic;

public class Scoreboard : IScoreboard
{
    private List<Frame> _frames;
    private List<int> _baseScores;
    private List<int> _bonusScores;

    public IReadOnlyList<Frame> Frames => _frames;
    public IReadOnlyList<int> BaseScores => _baseScores;
    public IReadOnlyList<int> BonusScores => _bonusScores;

    public Scoreboard()
    {
        _frames = new List<Frame>();
        _baseScores = new List<int>();
        _bonusScores = new List<int>();
    }

    public void AddFrame(Frame frame)
    {
        _frames.Add(frame);
    }

    public void AddBaseScore(int score)
    {
        _baseScores.Add(score);
    }
    
    public void AddBonusScore(int score)
    {
        _bonusScores.Add(score);
    }

    public void UpdateBonusScore(int score, int frameNumber)
    {
        var index = frameNumber - 1;
        if(index >= 0 && index < _bonusScores.Count) _bonusScores[index] += score;
    }
}