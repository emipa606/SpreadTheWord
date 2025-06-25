using Verse;

namespace SpreadTheWord;

public class SpreadTheWordSettings : ModSettings
{
    public int BaseGoodwillNeeded = 100;
    public bool EnableComplexCalculation;
    public int NumberToRelease = 25;

    public override void ExposeData()
    {
        Scribe_Values.Look(ref EnableComplexCalculation, "enableComplexCalculation");
        Scribe_Values.Look(ref NumberToRelease, "numberToRelease");
        Scribe_Values.Look(ref BaseGoodwillNeeded, "baseGoodwillNeeded");
        base.ExposeData();
    }
}