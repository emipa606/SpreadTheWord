using HarmonyLib;
using RimWorld;

namespace SpreadTheWord.HarmonyPatches;

[HarmonyPatch(typeof(Pawn_GuestTracker), nameof(Pawn_GuestTracker.IsInteractionDisabled))]
public static class Pawn_GuestTracker_IsInteractionDisabled
{
    public static void Postfix(ref bool __result, PrisonerInteractionModeDef def,
        PrisonerInteractionModeDef ___interactionMode)
    {
        if (!__result)
        {
            return;
        }

        if (def == PrisonerInteractionModeDefOf.Convert && ___interactionMode == STWDefOf.ConvertThenRelease)
        {
            __result = false;
        }
    }
}