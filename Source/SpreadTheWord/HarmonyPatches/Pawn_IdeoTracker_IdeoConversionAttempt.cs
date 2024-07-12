using HarmonyLib;
using RimWorld;
using Verse;

namespace SpreadTheWord.HarmonyPatches;

[HarmonyPatch(typeof(Pawn_IdeoTracker), nameof(Pawn_IdeoTracker.IdeoConversionAttempt))]
public static class Pawn_IdeoTracker_IdeoConversionAttempt
{
    public static void Postfix(bool __result, Pawn ___pawn)
    {
        if (!__result || !___pawn.IsPrisonerOfColony ||
            ___pawn.guest.ExclusiveInteractionMode != STWDefOf.ConvertThenRelease ||
            ___pawn.Ideo != Faction.OfPlayer.ideos.PrimaryIdeo)
        {
            return;
        }

        ___pawn.guest.SetExclusiveInteraction(PrisonerInteractionModeDefOf.Release);
    }
}