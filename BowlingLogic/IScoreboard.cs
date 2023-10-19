namespace BowlingLogic
{
    public interface IScoreboard
    {
        void AddBaseScore(int score);
        void AddBonusScore(int score);
        void AddFrame(Frame frame);
    }
}