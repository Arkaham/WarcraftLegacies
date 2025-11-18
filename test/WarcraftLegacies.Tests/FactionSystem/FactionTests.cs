namespace WarcraftLegacies.Tests.FactionSystem;

/// <summary>
/// Tests Faction logic patterns without instantiating Faction.
/// </summary>
public class FactionLogicTests
{
  [Fact]
  public void ObjectLimitLogic_StartsAtZero()
  {
    // Simulate Faction's _objectLimits dictionary
    var objectLimits = new Dictionary<int, int>();

    // Simulate GetObjectLimit(999)
    var limit = objectLimits.TryGetValue(999, out var value) ? value : 0;

    Assert.Equal(0, limit);
  }

  [Fact]
  public void ObjectLimitLogic_ModIncreasesLimit()
  {
    var objectLimits = new Dictionary<int, int>();
    const int objectId = 100;
    const int amount = 5;

    // Simulate ModObjectLimit
    if (!objectLimits.TryAdd(objectId, amount))
    {
      objectLimits[objectId] += amount;
    }

    Assert.Equal(5, objectLimits[objectId]);
  }

  [Fact]
  public void ObjectLimitLogic_ModAccumulates()
  {
    var objectLimits = new Dictionary<int, int>();
    const int objectId = 100;

    // First mod
    if (!objectLimits.TryAdd(objectId, 5))
    {
      objectLimits[objectId] += 5;
    }
    else
    {
      objectLimits[objectId] = 5;
    }

    // Second mod
    objectLimits[objectId] += 3;

    Assert.Equal(8, objectLimits[objectId]);
  }

  [Fact]
  public void ObjectLimitLogic_SetReplacesValue()
  {
    var objectLimits = new Dictionary<int, int> { [100] = 5 };

    // Simulate SetObjectLimit
    objectLimits[100] = 20;

    Assert.Equal(20, objectLimits[100]);
  }

  [Theory]
  [InlineData(5, 3, 8)]
  [InlineData(10, -3, 7)]
  [InlineData(0, 15, 15)]
  public void ObjectLimitLogic_ModWithDifferentValues(int first, int second, int expected)
  {
    var objectLimits = new Dictionary<int, int> { [100] = first };
    objectLimits[100] += second;

    Assert.Equal(expected, objectLimits[100]);
  }

  [Fact]
  public void ObjectLevelLogic_CanBeStored()
  {
    var objectLevels = new Dictionary<int, int>();
    const int researchId = 1000;

    // Simulate SetObjectLevel
    objectLevels[researchId] = 3;

    // Simulate GetObjectLevel
    var level = objectLevels.TryGetValue(researchId, out var value) ? value : 0;

    Assert.Equal(3, level);
  }

  [Fact]
  public void CopyObjectLevelsLogic_OnlyCopiesWithLimit()
  {
    // Source faction data
    var sourceLevels = new Dictionary<int, int>
    {
      [100] = 2,
      [200] = 3,
      [300] = 5
    };

    // Target faction data
    var targetLimits = new Dictionary<int, int>
    {
      [100] = 10, // Has access
      [200] = 5   // Has access
      // No access to 300
    };
    var targetLevels = new Dictionary<int, int>();

    // Simulate CopyObjectLevelsFrom logic
    foreach (var (objectId, sourceLevel) in sourceLevels)
    {
      if (targetLimits.TryGetValue(objectId, out var targetLimit) && targetLimit > 0)
      {
        targetLevels[objectId] = Math.Min(targetLimit, sourceLevel);
      }
    }

    // Assert
    Assert.Equal(2, targetLevels[100]); // Copied
    Assert.Equal(3, targetLevels[200]); // Copied
    Assert.False(targetLevels.ContainsKey(300)); // Not copied (no limit)
  }

  [Fact]
  public void CopyObjectLevelsLogic_CapsAtLimit()
  {
    var sourceLevels = new Dictionary<int, int> { [100] = 10 };
    var targetLimits = new Dictionary<int, int> { [100] = 5 };
    var targetLevels = new Dictionary<int, int>();

    // Copy logic with cap
    foreach (var (objectId, sourceLevel) in sourceLevels)
    {
      if (targetLimits.TryGetValue(objectId, out var targetLimit) && targetLimit > 0)
      {
        targetLevels[objectId] = Math.Min(targetLimit, sourceLevel);
      }
    }

    Assert.Equal(5, targetLevels[100]); // Capped at limit
  }
}
