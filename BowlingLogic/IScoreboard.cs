namespace BowlingLogic
{
    public interface IScoreboard
    {
        IReadOnlyList<IFrame> Frames { get; }
        IReadOnlyList<int> BonusScores { get; }

        void AddBonusScore(int score);
        void AddFrame(IFrame frame);
        void UpdateBonusScore(int score, int frameNumber);
    }
}