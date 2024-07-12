using HarmonyLib;
using RimWorld;
using Verse;

namespace SpreadTheWord.HarmonyPatches;

[HarmonyPatch(typeof(WorkGiver_Warden_Chat), nameof(WorkGiver_Warden_Chat.JobOnThing))]
public static class WorkGiver_Warden_Chat_JobOnThing
{
    public static void Prefix(Thing t, out bool __state)
    {
        var pawn = (Pawn)t;
        __state = false;
        if (pawn is { IsPrisonerOfColony: false })
        {
            return;
        }

        if (pawn?.guest == null)
        {
            return;
        }

        if (pawn.guest.ExclusiveInteractionMode != STWDefOf.ConvertThenRelease)
        {
            return;
        }

        __state = true;
    }

    public static void Postfix(Thing t, bool __state)
    {
        if (!__state)
        {
            return;
        }

        var pawn = (Pawn)t;

        pawn?.guest?.SetExclusiveInteraction(STWDefOf.ConvertThenRelease);
    }
}