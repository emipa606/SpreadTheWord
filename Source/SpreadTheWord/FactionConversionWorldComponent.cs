using RimWorld;
using RimWorld.Planet;

namespace SpreadTheWord;

public class FactionConversionWorldComponent : WorldComponent
{
    public FactionConversionWorldComponent(World world) : base(world)
    {
        this.world = world;
    }

    public int getFactionCountOnWorld(Faction faction)
    {
        return world.info.factions.Contains(faction.def) ? 1 : 0;
    }
}