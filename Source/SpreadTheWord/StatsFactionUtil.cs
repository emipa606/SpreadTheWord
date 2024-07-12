using RimWorld;
using Verse;

namespace SpreadTheWord;

public static class StatsFactionUtil
{
    //Check Ideo goodwill and prisoners released
    public static void CheckCanChangeIdeos(Faction other, Faction player)
    {
        if (other.ideos.PrimaryIdeo == player.ideos.PrimaryIdeo)
        {
            return;
        }

        var key = other.Name;
        var currVal = ConversionTrackerUtil.InsertThenGetStat(key, 1);
        CheckFactionConversion(other, player, key, currVal);
    }

    private static void CheckFactionConversion(Faction other, Faction player, string key, int currVal)
    {
        var numToRelease = SpreadTheWordMod.settings.numberToRelease;

        if (SpreadTheWordMod.settings.enableComplexCalculation)
        {
            numToRelease *= Find.World.GetComponent<FactionConversionWorldComponent>().getFactionCountOnWorld(other);
        }

        if (currVal >= numToRelease &&
            player.RelationWith(other).baseGoodwill >= SpreadTheWordMod.settings.baseGoodwillNeeded)
        {
            ConversionTrackerUtil.Reset(key);
            Find.FactionManager.FirstFactionOfDef(other.def).ideos.SetPrimary(player.ideos.PrimaryIdeo);
            var goodwillChange = 12;
            Find.HistoryEventsManager.RecordEvent(new HistoryEvent(HistoryEventDefOf.PeaceTalksSuccess,
                other.Named(HistoryEventArgsNames.AffectedFaction),
                goodwillChange.Named(HistoryEventArgsNames.CustomGoodwill)));
            Find.FactionManager.goodwillSituationManager.RecalculateAll(false);
            SendLetter(other);
        }
        else
        {
            Messages.Message(new Message("STW.ConversionLetterDetail".Translate(currVal, numToRelease, key),
                MessageTypeDefOf.NeutralEvent));
        }
    }

    //Send letter the ideo has changed
    private static void SendLetter(Faction other)
    {
        var letterTitle = "STW.ConversionLetterTitle".Translate();
        var letterLabel = "STW.ConversionLetterTitle".Translate();
        var letterText = "STW.ConversionLetterMessage".Translate(other.Name);
        var letter = LetterMaker.MakeLetter(letterLabel, letterText, LetterDefOf.PositiveEvent);
        letter.title = letterTitle;
        Find.LetterStack.ReceiveLetter(letter);
    }
}