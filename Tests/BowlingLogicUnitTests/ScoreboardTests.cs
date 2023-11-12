
namespace Tests;

public class ScoreboardTests
{
    [Fact]
    public void Scoreboard_InitialisedWithEmptyLists()
    {
        //Arrange & Act
        var scoreboard = new Scoreboard();
        //Assert
        scoreboard.Frames.Should().BeEmpty();
        scoreboard.BonusScores.Should().BeEmpty();
    }

    [Theory]
    [AutoSubstituteData]
    public void Scoreboard_AddFrame_FramesHasAFrame(IFrame frame)
    {
        //Arrange
        var scoreboard = new Scoreboard();

        //Act
        scoreboard.AddFrame(frame);
        //Assert
        scoreboard.Frames.Count.Should().Be(1);
    }

    [Theory]
    [AutoSubstituteData]
    public void Scoreboard_FramesAtMaxCount_FrameNotAdded(IFrame frame, IFrame lastFrame)
    {
        //Arrange
        var scoreboard = new Scoreboard();
        TestSetter.SetPrivateField(scoreboard, "_frames", new List<IFrame> { frame, frame, frame, frame, frame, frame, frame, frame, frame, frame });

        //Act
        scoreboard.AddFrame(lastFrame);
        //Assert
        scoreboard.Frames.Count.Should().Be(10);
        scoreboard.Frames.Last().Should().NotBe(lastFrame);
    }

    [Fact]
    public void Scoreboard_AddBonusScore_BonusScoresHasAScore()
    {
        //Arrange
        var scoreboard = new Scoreboard();

        //Act
        scoreboard.AddBonusScore();

        //Assert
        scoreboard.BonusScores.Count.Should().Be(1);
        scoreboard.BonusScores.First().Should().Be(0);
    }

    [Fact]
    public void Scoreboard_BonusScoreAtMaxCount_BonusScoreIsNotAdded()
    {
        //Arrange
        var scoreboard = new Scoreboard();
        TestSetter.SetPrivateField(scoreboard, "_bonusScores", new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 1 });

        //Act
        scoreboard.AddBonusScore();

        //Assert
        scoreboard.BonusScores.Count.Should().Be(10);
        scoreboard.BonusScores.Last().Should().Be(1);
    }

    [Theory]
    [AutoSubstituteData]
    public void Scoreboard_FramesWithNoTenPinScores_BonusScoresValueZero(IFrame frameOne, IFrame frameTwo)
    {
        //Arrange
        var scoreboard = new Scoreboard();
        frameOne.RollOne = 4;
        frameOne.RollTwo = 1;
        frameTwo.RollOne = 4;
        frameTwo.RollTwo = 1;
        
        TestSetter.SetPrivateField(scoreboard, "_frames", new List<IFrame> {frameOne, frameTwo });
        TestSetter.SetPrivateField(scoreboard, "_bonusScores", new List<int> {0, 0 });


        //Act
        scoreboard.CalculateBonus(frameTwo);

        //Assert
        var bonus = scoreboard.BonusScores.ElementAt(0).Should().Be(0);
    }

    [Theory]
    [AutoSubstituteData]
    public void Scoreboard_FrameWithStrike_BonusScoresEqualToNextTwoRollsOfSameFrame(IFrame frameOne, IFrame frameTwo)
    {
        //Arrange
        var scoreboard = new Scoreboard();
        frameOne.RollOne = 10;
        TestSetter.SetPrivateProperty(frameOne, "FrameNumber", 1);

        frameTwo.RollOne = 4;
        frameTwo.RollTwo = 1;
        TestSetter.SetPrivateProperty(frameTwo, "FrameNumber", 2);
        
        TestSetter.SetPrivateField(scoreboard, "_frames", new List<IFrame> {frameOne, frameTwo });
        TestSetter.SetPrivateField(scoreboard, "_bonusScores", new List<int> {0, 0 });


        //Act
        scoreboard.CalculateBonus(frameTwo);

        //Assert
        var bonus = scoreboard.BonusScores.ElementAt(0).Should().Be(5);
    }

    [Theory]
    [AutoSubstituteData]
    public void Scoreboard_FramesWithStrikes_BonusScoresEqualToNextTwoRollsAcrossNextTwoFrames(IFrame frameOne, IFrame frameTwo, IFrame frameThree)
    {
        //Arrange
        var scoreboard = new Scoreboard();
        frameOne.RollOne = 10;
        TestSetter.SetPrivateProperty(frameOne, "FrameNumber", 1);

        frameTwo.RollOne = 10;
        frameTwo.RollTwo = 0;
        TestSetter.SetPrivateProperty(frameTwo, "FrameNumber", 2);

        frameThree.RollOne = 5;
        frameThree.RollTwo = 3;
        
        TestSetter.SetPrivateProperty(frameThree, "FrameNumber", 3);
        
        TestSetter.SetPrivateField(scoreboard, "_frames", new List<IFrame> {frameOne, frameTwo, frameThree });
        TestSetter.SetPrivateField(scoreboard, "_bonusScores", new List<int> {0, 0, 0 });


        //Act
        scoreboard.CalculateBonus(frameOne);
        scoreboard.CalculateBonus(frameTwo);
        scoreboard.CalculateBonus(frameThree);

        //Assert
        scoreboard.BonusScores.ElementAt(0).Should().Be(15);
        scoreboard.BonusScores.ElementAt(1).Should().Be(8);
    }
}