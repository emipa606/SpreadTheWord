using System.Collections.Generic;
using RimWorld;
using RimWorld.Planet;
using Verse;

namespace SpreadTheWord;

public class FactionConversionWorldComponent : WorldComponent
{
    private Dictionary<string, int> entries = new();

    public FactionConversionWorldComponent(World world) : base(world)
    {
        this.world = world;
    }

    public Dictionary<string, int> Entries
    {
        get
        {
            entries ??= [];
            return entries;
        }
        set => entries = value;
    }

    public int getFactionCountOnWorld(Faction faction)
    {
        return world.info.factions.Contains(faction.def) ? 1 : 0;
    }

    public void AddEntry(string key, int value)
    {
        if (!Entries.TryAdd(key, value))
        {
            Entries[key] += value;
        }
    }

    public int GetEntry(string key)
    {
        return Entries.GetValueOrDefault(key, 0);
    }

    public void Reset(string key)
    {
        if (Entries.ContainsKey(key))
        {
            Entries[key] = 0;
        }
    }

    public override void ExposeData()
    {
        base.ExposeData();
        Scribe_Collections.Look(ref entries, "entries", LookMode.Value);
    }
}