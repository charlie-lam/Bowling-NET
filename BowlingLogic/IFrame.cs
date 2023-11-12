namespace BowlingLogic
{
    public interface IFrame
    {
        int FrameNumber { get; set; }
        int? RollOne { get; set; }
        int? RollTwo { get; set; }
        int? RollThree { get; set; }
    }
}