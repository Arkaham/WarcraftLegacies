using MacroTools.ResearchSystems;
using WCSharp.Api;

namespace WarcraftLegacies.Tests.Fakes;

/// <summary>
/// Concrete implementation of Research for testing.
/// Exists ONLY in test project.
/// </summary>
public class ResearchFake : Research
{
  public ResearchFake(int researchTypeId, int goldCost)
    : base(researchTypeId, goldCost)
  {
  }

  // Track what was called
  public bool OnResearchWasCalled { get; private set; }
  public player? LastResearchingPlayer { get; private set; }
  public bool OnRegisterWasCalled { get; private set; }

  public override void OnResearch(player researchingPlayer)
  {
    OnResearchWasCalled = true;
    LastResearchingPlayer = researchingPlayer;
  }

  public override void OnRegister()
  {
    OnRegisterWasCalled = true;
    base.OnRegister();
  }

  // Helper to reset state between tests
  public void Reset()
  {
    OnResearchWasCalled = false;
    LastResearchingPlayer = null;
    OnRegisterWasCalled = false;
  }
}
