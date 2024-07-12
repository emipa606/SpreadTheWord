using System.Reflection;
using HarmonyLib;
using Mlie;
using UnityEngine;
using Verse;

namespace SpreadTheWord;

[StaticConstructorOnStartup]
public class SpreadTheWordMod : Mod
{
    public static SpreadTheWordSettings settings;
    private static string currentVersion;

    public SpreadTheWordMod(ModContentPack content) : base(content)
    {
        new Harmony("crazedmonkey231.spread.the.word").PatchAll(Assembly.GetExecutingAssembly());
        settings = GetSettings<SpreadTheWordSettings>();
        currentVersion = VersionFromManifest.GetVersionFromModMetaData(content.ModMetaData);
    }

    public override void DoSettingsWindowContents(Rect inRect)
    {
        var listingStandard = new Listing_Standard();
        listingStandard.Begin(inRect);
        listingStandard.Gap();
        listingStandard.Label("STW.BaseSettings".Translate());
        listingStandard.Gap();
        listingStandard.Label("STW.BaseNeededGoodwill".Translate(settings.baseGoodwillNeeded));
        settings.baseGoodwillNeeded = (int)listingStandard.Slider(settings.baseGoodwillNeeded, -100f, 100f);
        listingStandard.Gap();
        listingStandard.CheckboxLabeled("STW.ComplexCalculation".Translate(), ref settings.enableComplexCalculation,
            "STW.ComplexCalculationTT".Translate());
        listingStandard.Gap();
        listingStandard.Label("STW.PeopleToConvert".Translate(settings.numberToRelease));
        settings.numberToRelease = (int)listingStandard.Slider(settings.numberToRelease, 1f, 1000f);
        if (currentVersion != null)
        {
            listingStandard.Gap();
            GUI.contentColor = Color.gray;
            listingStandard.Label("STW.CurrentModVersion".Translate(currentVersion));
            GUI.contentColor = Color.white;
        }

        listingStandard.End();
        base.DoSettingsWindowContents(inRect);
    }

    public override string SettingsCategory()
    {
        return "Spread The Word";
    }
}