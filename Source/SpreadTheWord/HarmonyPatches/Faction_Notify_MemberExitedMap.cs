using HarmonyLib;
using RimWorld;
using Verse;

namespace SpreadTheWord.HarmonyPatches;

[HarmonyPatch(typeof(Faction), nameof(Faction.Notify_MemberExitedMap))]
public static class Faction_Notify_MemberExitedMap
{
    public static void Postfix(Pawn member, bool freed, Faction __instance)
    {
        if (member.HostFaction == null)
        {
            return;
        }

        if (__instance.ideos == null || member.HostFaction.ideos == null)
        {
            return;
        }

        if (!member.mindState.AvailableForGoodwillReward)
        {
            return;
        }

        if (!freed)
        {
            return;
        }

        if (member.Ideo == Faction.OfPlayer.ideos.PrimaryIdeo)
        {
            ConversionTrackerUtil.InsertThenGetStat("crazedmonkey231.spread.the.word", 1);
            StatsFactionUtil.CheckCanChangeIdeos(__instance, member.HostFaction);
        }
        else
        {
            Messages.Message(new Message("STW.ConvertMessage".Translate(), MessageTypeDefOf.NeutralEvent));
        }
    }
}