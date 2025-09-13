using System.Collections.Generic;
using System.Linq;
using Verse;

namespace SpreadTheWord;

public class ConversionTrackerComponent : MapComponent
{
    private Dictionary<string, int> entries = new();

    // Legacy component, not sure why they had it as a map-component
    public ConversionTrackerComponent(Map map) : base(map)
    {
    }

    public override void FinalizeInit()
    {
        base.FinalizeInit();
        if (!entries.Any())
        {
            return;
        }

        foreach (var entry in entries)
        {
            ConversionTrackerUtil.AddStat(entry.Key, entry.Value);
        }

        entries.Clear();
    }


    public override void ExposeData()
    {
        base.ExposeData();
        Scribe_Collections.Look(ref entries, "entries", LookMode.Value);
    }
}