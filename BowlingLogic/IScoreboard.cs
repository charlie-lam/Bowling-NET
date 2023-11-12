namespace BowlingLogic
{
    public interface IScoreboard
    {
        IReadOnlyList<IFrame> Frames { get; }
        IReadOnlyList<int> BonusScores { get; }

        void AddBonusScore();
        void AddFrame(IFrame frame);
        void CalculateBonus(IFrame frame);
    }
}