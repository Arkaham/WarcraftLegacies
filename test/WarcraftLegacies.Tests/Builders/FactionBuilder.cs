using WarcraftLegacies.Tests.Fakes;
using WCSharp.Api;

namespace WarcraftLegacies.Tests.Builders;

/// <summary>
/// Builder for creating test Faction instances.
/// </summary>
public class FactionBuilder
{
  private string _name = "Test Faction";
  private playercolor _color = playercolor.Red;
  private readonly string _icon = "BTNTest.blp";
  private int _startingGold = 0;
  private string? _introText = null;
  private readonly Dictionary<int, int> _objectLimits = new();

  public FactionBuilder WithName(string name)
  {
    _name = name;
    return this;
  }

  public FactionBuilder WithColor(playercolor color)
  {
    _color = color;
    return this;
  }

  public FactionBuilder WithStartingGold(int gold)
  {
    _startingGold = gold;
    return this;
  }

  public FactionBuilder WithIntroText(string text)
  {
    _introText = text;
    return this;
  }

  public FactionBuilder WithObjectLimit(int objectId, int limit)
  {
    _objectLimits[objectId] = limit;
    return this;
  }

  public FactionFake Build()
  {
    var faction = new FactionFake(_name, _color, _icon)
    {
      StartingGold = _startingGold,
      IntroText = _introText
    };

    foreach (var (objectId, limit) in _objectLimits)
    {
      faction.ModObjectLimit(objectId, limit);
    }

    return faction;
  }

  // Preset factions for common test scenarios
  public static FactionBuilder Ahnqiraj() =>
    new FactionBuilder()
      .WithName("Ahn'qiraj")
      .WithColor(playercolor.Wheat)
      .WithStartingGold(200);

  public static FactionBuilder Lordaeron() =>
    new FactionBuilder()
      .WithName("Lordaeron")
      .WithColor(playercolor.Blue)
      .WithStartingGold(500);

  public static FactionBuilder Default() => new FactionBuilder();
}
