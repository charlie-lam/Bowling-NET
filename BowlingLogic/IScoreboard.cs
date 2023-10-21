namespace BowlingLogic
{
    public interface IScoreboard
    {
        IReadOnlyList<Frame> Frames { get; }
        IReadOnlyList<int> BaseScores { get; }
        IReadOnlyList<int> BonusScores { get; }

        void AddBaseScore(int score);
        void AddBonusScore(int score);
        void AddFrame(Frame frame);
        void UpdateBonusScore(int score, int frameNumber);
    }
}