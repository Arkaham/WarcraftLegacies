using WarcraftLegacies.Tests.Builders;

namespace WarcraftLegacies.Tests.FactionSystem;

public class TeamTests
{
  [Fact]
  public void Constructor_SetsNameCorrectly()
  {
    // Arrange & Act
    var team = TeamBuilder.Default()
      .WithName("Test Team")
      .Build();

    // Assert
    Assert.Equal("Test Team", team.Name);
  }

  [Fact]
  public void Size_IsZero_Initially()
  {
    // Arrange & Act
    var team = TeamBuilder.Default().Build();

    // Assert
    Assert.Equal(0, team.Size);
  }

  [Fact]
  public void VictoryMusic_CanBeSet()
  {
    // Arrange & Act
    var team = TeamBuilder.Default()
      .WithVictoryMusic("Victory.mp3")
      .Build();

    // Assert
    Assert.Equal("Victory.mp3", team.VictoryMusic);
  }
}
