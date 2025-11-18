using MacroTools.ResearchSystems;
using WarcraftLegacies.Tests.Fakes;

namespace WarcraftLegacies.Tests.Builders;

/// <summary>
/// Builder for creating test Research instances.
/// </summary>
public class ResearchBuilder
{
  private int _researchTypeId = 1000;
  private int _goldCost = 100;
  private readonly List<Research> _incompatibleWith = new();

  public ResearchBuilder WithId(int id)
  {
    _researchTypeId = id;
    return this;
  }

  public ResearchBuilder WithCost(int cost)
  {
    _goldCost = cost;
    return this;
  }

  public ResearchBuilder IncompatibleWith(params Research[] researches)
  {
    _incompatibleWith.AddRange(researches);
    return this;
  }

  public ResearchFake Build()
  {
    var research = new ResearchFake(_researchTypeId, _goldCost)
    {
      IncompatibleWith = _incompatibleWith
    };
    return research;
  }

  // Preset researches
  public static ResearchBuilder SpellConduction() =>
    new ResearchBuilder()
      .WithId(1514294604)
      .WithCost(170);

  public static ResearchBuilder ShapedObsidian() =>
    new ResearchBuilder()
      .WithId(1514293331)
      .WithCost(100);

  public static ResearchBuilder Default() => new ResearchBuilder();
}
