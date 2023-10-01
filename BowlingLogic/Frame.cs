namespace BowlingLogic;

public class Frame
{
    private int rollOne;
    private int rollTwo;
    private int rollThree;

    public int RollOne { get => rollOne; set => AddRole(ref rollOne, pins); }
    public int RollTwo { get => rollTwo; set => AddRole(ref rollTwo, pins); }
    public int RollThree { get => rollThree; set => AddRole(ref rollThree, pins); }
    

    public void AddRole(ref roll, int pins)
    {
        if(pins < 0 || pins > 10)
        {
            throw new ArgumentException("Pin value out of range");
        }
        return pins;
    }
}