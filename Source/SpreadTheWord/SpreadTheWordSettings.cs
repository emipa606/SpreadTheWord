using Verse;

namespace SpreadTheWord;

public class SpreadTheWordSettings : ModSettings
{
    public int baseGoodwillNeeded = 100;
    public bool enableComplexCalculation;
    public int numberToRelease = 25;

    public override void ExposeData()
    {
        Scribe_Values.Look(ref enableComplexCalculation, "enableComplexCalculation");
        Scribe_Values.Look(ref numberToRelease, "numberToRelease");
        Scribe_Values.Look(ref baseGoodwillNeeded, "baseGoodwillNeeded");
        base.ExposeData();
    }
}