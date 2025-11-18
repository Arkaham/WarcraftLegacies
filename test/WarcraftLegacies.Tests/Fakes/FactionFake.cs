using MacroTools.FactionSystem;
using WCSharp.Api;

namespace WarcraftLegacies.Tests.Fakes;

/// <summary>
/// Concrete implementation of Faction for testing.
/// Exists ONLY in test project.
/// </summary>
public class FactionFake : Faction
{
  public FactionFake(string name, playercolor color, string icon)
    : base(name, color, icon)
  {
  }

  // Expose protected properties for testing
  public new int StartingGold
  {
    get => base.StartingGold;
    init => base.StartingGold = value;
  }

  public new string? IntroText
  {
    get => base.IntroText;
    init => base.IntroText = value;
  }

  public new int? ControlPointDefenderUnitTypeId
  {
    get => base.ControlPointDefenderUnitTypeId;
    init => base.ControlPointDefenderUnitTypeId = value;
  }

  // Track calls for testing
  public bool OnRegisteredWasCalled { get; private set; }
  public bool OnNotPickedWasCalled { get; private set; }

  public override void OnRegistered()
  {
    OnRegisteredWasCalled = true;
    base.OnRegistered();
  }

  public override void OnNotPicked()
  {
    OnNotPickedWasCalled = true;
    base.OnNotPicked();
  }
}
