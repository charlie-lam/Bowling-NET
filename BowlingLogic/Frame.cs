namespace BowlingLogic;

public class Frame
{
    private int frameNumber;

    public Frame(int frameNumber)
    {
        this.frameNumber = frameNumber;
    }
    private int rollOne;
    private int rollTwo;
    private int rollThree;

    public int RollOne { get => rollOne; set => AddRoll(ref rollOne, value); }
    public int RollTwo { get => rollTwo; set => AddRoll(ref rollTwo, value); }
    public int RollThree
    {
        get => rollThree;
        set
        {
            if (frameNumber != 10 || (RollOne + RollTwo < 10))
            {
                throw new ArgumentException("Third roll only available on the 10th frame and if previous two rolls are greater than 10.");
            }
            AddRoll(ref rollThree, value);
        }
    }


    public int AddRoll(ref int roll, int pins)
    {
        if (pins < 0 || pins > 10)
        {
            throw new ArgumentException("Pin value out of range");
        }
        return pins;
    }
}