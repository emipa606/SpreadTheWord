using System.Reflection;
using HarmonyLib;
using Mlie;
using UnityEngine;
using Verse;

namespace SpreadTheWord;

[StaticConstructorOnStartup]
public class SpreadTheWordMod : Mod
{
    public static SpreadTheWordSettings Settings;
    private static string currentVersion;

    public SpreadTheWordMod(ModContentPack content) : base(content)
    {
        new Harmony("crazedmonkey231.spread.the.word").PatchAll(Assembly.GetExecutingAssembly());
        Settings = GetSettings<SpreadTheWordSettings>();
        currentVersion = VersionFromManifest.GetVersionFromModMetaData(content.ModMetaData);
    }

    public override void DoSettingsWindowContents(Rect inRect)
    {
        var listingStandard = new Listing_Standard();
        listingStandard.Begin(inRect);
        listingStandard.Gap();
        listingStandard.Label("STW.BaseSettings".Translate());
        listingStandard.Gap();
        listingStandard.Label("STW.BaseNeededGoodwill".Translate(Settings.BaseGoodwillNeeded));
        Settings.BaseGoodwillNeeded = (int)listingStandard.Slider(Settings.BaseGoodwillNeeded, -100f, 100f);
        listingStandard.Gap();
        listingStandard.CheckboxLabeled("STW.ComplexCalculation".Translate(), ref Settings.EnableComplexCalculation,
            "STW.ComplexCalculationTT".Translate());
        listingStandard.Gap();
        listingStandard.Label("STW.PeopleToConvert".Translate(Settings.NumberToRelease));
        Settings.NumberToRelease = (int)listingStandard.Slider(Settings.NumberToRelease, 1f, 1000f);
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