using System.Collections.Generic;
using Verse;

namespace SpreadTheWord;

public class ConversionTrackerComponent : MapComponent
{
    public Dictionary<string, int> entries = new();

    public ConversionTrackerComponent(Map map) : base(map)
    {
    }

    public void AddEntry(string key, int value)
    {
        if (!entries.TryAdd(key, value))
        {
            entries[key] += value;
        }
    }

    public int GetEntry(string key)
    {
        return entries.GetValueOrDefault(key, 0);
    }

    public void Reset(string key)
    {
        if (entries.ContainsKey(key))
        {
            entries[key] = 0;
        }
    }

    public override void ExposeData()
    {
        base.ExposeData();
        Scribe_Collections.Look(ref entries, "entries", LookMode.Value);
    }
}