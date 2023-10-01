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

    public int RollOne { get => rollOne; set => AddRole(ref rollOne, pins); }
    public int RollTwo { get => rollTwo; set => AddRole(ref rollTwo, pins); }
    public int RollThree 
    { 
        get => rollThree; 
        set => 
            {
                if(frameNumber != 10 || (RollOne + RollTwo < 10))
                {
                    throw new ArgumentException("Third roll only available on the 10th frame and if previous two rolls are greater than 10.");
                }
                AddRole(ref rollThree, pins);
            } 
    }
    

    public void AddRole(ref roll, int pins)
    {
        if(pins < 0 || pins > 10)
        {
            throw new ArgumentException("Pin value out of range");
        }
        return pins;
    }
}