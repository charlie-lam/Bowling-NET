namespace BowlingLogic;

public class Frame : IFrame
{
    public readonly int _frameNumber;

    public Frame(int? frameNumber)
    {
        _frameNumber = frameNumber ?? throw new ArgumentNullException(nameof(frameNumber));
    }

    public int FrameNumber { get => _frameNumber; }

    private int? rollOne;
    private int? rollTwo;
    private int? rollThree;

    public int? RollOne { get => rollOne; set => rollOne = AddRoll(value); }
    public int? RollTwo { get => rollTwo; set => rollTwo = AddRoll(value); }
    public int? RollThree
    {
        get => rollThree;
        set
        {
            if (_frameNumber != 10 || (RollOne + RollTwo < 10))
            {
                throw new Exception("Third roll only available on the 10th frame and if previous two rolls are greater than 10.");
            }
            rollThree = AddRoll(value);
        }
    }


    static int? AddRoll(int? pins)
    {
        if (pins < 0 || pins > 10)
        {
            throw new ArgumentException($"Pin value {pins} out of range");
        }
        return pins;
    }
}