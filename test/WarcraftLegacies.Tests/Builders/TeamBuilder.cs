using MacroTools.FactionSystem;

namespace WarcraftLegacies.Tests.Builders;

/// <summary>
/// Builder for creating test Team instances.
/// </summary>
public class TeamBuilder
{
  private string _name = "Test Team";
  private string? _victoryMusic = null;

  public TeamBuilder WithName(string name)
  {
    _name = name;
    return this;
  }

  public TeamBuilder WithVictoryMusic(string music)
  {
    _victoryMusic = music;
    return this;
  }

  public Team Build()
  {
    return new Team(_name)
    {
      VictoryMusic = _victoryMusic
    };
  }

  public static TeamBuilder Alliance() =>
    new TeamBuilder().WithName("Alliance");

  public static TeamBuilder Horde() =>
    new TeamBuilder().WithName("Horde");

  public static TeamBuilder Default() => new TeamBuilder();
}
