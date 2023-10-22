using AutoFixture.Xunit2;
using System.Reflection;

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
        TestPropertySetter.SetPrivateProperty(scoreboard, "_frames", new List<IFrame> { frame, frame, frame, frame, frame, frame, frame, frame, frame, frame });

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
        scoreboard.AddBonusScore(9);

        //Assert
        scoreboard.BonusScores.Count.Should().Be(1);
        scoreboard.BonusScores.First().Should().Be(9);
    }

    [Theory]
    [InlineAutoData(-1)]
    [InlineAutoData(11)]
    public void Scoreboard_AddInvalidBonusScore_BonusScoreIsNotAdded(int score)
    {
        //Arrange
        var scoreboard = new Scoreboard();

        //Act
        scoreboard.AddBonusScore(score);

        //Assert
        scoreboard.BonusScores.Should().BeEmpty();
    }

    [Fact]
    public void Scoreboard_BonusScoreAtMaxCount_BonusScoreIsNotAdded()
    {
        //Arrange
        var scoreboard = new Scoreboard();
        TestPropertySetter.SetPrivateProperty(scoreboard, "_bonusScores", new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 1 });

        //Act
        scoreboard.AddBonusScore(7);

        //Assert
        scoreboard.BonusScores.Count.Should().Be(10);
        scoreboard.BonusScores.Last().Should().Be(1);
    }

    [Fact]
    public void Scoreboard_UpdateBonusScore_BonusScoresHasAnUpdatedScore()
    {
        //Arrange
        var scoreboard = new Scoreboard();

        //Act
        scoreboard.AddBonusScore(9);
        scoreboard.UpdateBonusScore(5, 1);

        //Assert
        scoreboard.BonusScores.Count.Should().Be(1);
        scoreboard.BonusScores.First().Should().Be(14);
    }

    [Theory]
    [InlineAutoData(-1)]
    [InlineAutoData(11)]
    public void Scoreboard_UpdateWithInvalidBonusScore_BonusScoreIsNotUpdated(int score)
    {
        //Arrange
        var scoreboard = new Scoreboard();
        scoreboard.AddBonusScore(7);

        //Act
        scoreboard.UpdateBonusScore(score, 1);

        //Assert
        scoreboard.BonusScores.First().Should().Be(7);
    }
}