using BowlingLogic;

var frameFactory = new FrameFactory();
var scoreboard = new Scoreboard();
Bowling? bowlingGame = null;

Console.WriteLine("Do you want to start a game of bowling: Yes or No");
string? startGameResponse = null;
while (string.IsNullOrWhiteSpace(startGameResponse))
{
    startGameResponse = Console.ReadLine();
}
if (startGameResponse.ToLower() == "yes")
{
    bowlingGame = new Bowling(scoreboard, frameFactory);
    bowlingGame.StartGame();
    while (!bowlingGame.HasEnded)
    {
        Console.WriteLine("Type your roll from 1 to 10:");
        string? pinInput = Console.ReadLine();
        Console.WriteLine();
        if (int.TryParse(pinInput, out int pins) && pins >= 0 && pins <= 10)
        {
            var frames = bowlingGame.Scoreboard.Frames;
            bowlingGame.TakeRoll(pins);
            foreach (var frame in frames)
            {
                Console.WriteLine($"Frame {frame.FrameNumber}:");

                if (frame.RollOne.HasValue)
                {
                    Console.WriteLine($"  Roll One: {frame.RollOne}");
                }

                if (frame.RollTwo.HasValue)
                {
                    Console.WriteLine($"  Roll Two: {frame.RollTwo}");
                }

                if (frame.FrameNumber == 10 && frame.RollThree.HasValue)
                {
                    Console.WriteLine($"  Roll Three: {frame.RollThree}");
                }

                Console.WriteLine($"  Bonus score: {bowlingGame.Scoreboard.BonusScores.ElementAt(frame.FrameNumber - 1)}");

                Console.WriteLine();
            }
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter a number from 0 to 10.");
        }
    }
}
else
{
    Console.WriteLine("Shame");
}
