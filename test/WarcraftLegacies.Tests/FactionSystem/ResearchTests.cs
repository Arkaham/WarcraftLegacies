using WarcraftLegacies.Tests.Builders;

namespace WarcraftLegacies.Tests.FactionSystem;

public class ResearchTests
{
  [Fact]
  public void Constructor_SetsResearchTypeIdCorrectly()
  {
    // Arrange & Act
    var research = ResearchBuilder.Default()
      .WithId(1234)
      .Build();

    // Assert
    Assert.Equal(1234, research.ResearchTypeId);
  }

  [Fact]
  public void Constructor_SetsGoldCostCorrectly()
  {
    // Arrange & Act
    var research = ResearchBuilder.Default()
      .WithCost(250)
      .Build();

    // Assert
    Assert.Equal(250, research.GoldCost);
  }

  [Fact]
  public void IncompatibleWith_IsEmptyByDefault()
  {
    // Arrange & Act
    var research = ResearchBuilder.Default().Build();

    // Assert
    Assert.Empty(research.IncompatibleWith);
  }

  [Fact]
  public void IncompatibleWith_CanBeSet()
  {
    // Arrange
    var research1 = ResearchBuilder.Default().WithId(100).Build();
    var research2 = ResearchBuilder.Default().WithId(200)
      .IncompatibleWith(research1)
      .Build();

    // Act & Assert
    Assert.Contains(research1, research2.IncompatibleWith);
  }

  [Fact]
  public void IncompatibleWith_CanContainMultiple()
  {
    // Arrange
    var research1 = ResearchBuilder.Default().WithId(100).Build();
    var research2 = ResearchBuilder.Default().WithId(200).Build();
    var research3 = ResearchBuilder.Default().WithId(300)
      .IncompatibleWith(research1, research2)
      .Build();

    // Act & Assert
    Assert.Equal(2, research3.IncompatibleWith.Count());
    Assert.Contains(research1, research3.IncompatibleWith);
    Assert.Contains(research2, research3.IncompatibleWith);
  }

  [Fact]
  public void OnRegister_IsCalled()
  {
    // Arrange
    var research = ResearchBuilder.Default().Build();

    // Act
    research.OnRegister();

    // Assert
    Assert.True(research.OnRegisterWasCalled);
  }
}
