using System.Collections.Generic;
using System.Reflection;
using HarmonyLib;
using RimWorld;
using Verse;

namespace SpreadTheWord.HarmonyPatches;

[HarmonyPatch]
public static class WorkGiver_Warden_Convert
{
    private static IEnumerable<MethodBase> TargetMethods()
    {
        yield return AccessTools.Method(typeof(RimWorld.WorkGiver_Warden_Convert),
            nameof(RimWorld.WorkGiver_Warden_Convert.HasJobOnThing));
        yield return AccessTools.Method(typeof(RimWorld.WorkGiver_Warden_Convert),
            nameof(RimWorld.WorkGiver_Warden_Convert.JobOnThing));
    }

    public static void Prefix(Thing t, Pawn pawn, out bool __state)
    {
        var prisoner = (Pawn)t;
        __state = false;
        if (prisoner is { IsPrisonerOfColony: false })
        {
            return;
        }

        if (prisoner?.guest == null)
        {
            return;
        }

        if (prisoner.guest.ExclusiveInteractionMode != STWDefOf.ConvertThenRelease)
        {
            return;
        }

        if (prisoner.Ideo == Faction.OfPlayer.ideos.PrimaryIdeo)
        {
            prisoner.guest.SetExclusiveInteraction(PrisonerInteractionModeDefOf.Release);
            return;
        }

        if (prisoner.Ideo != pawn.Ideo && prisoner.guest.ideoForConversion == null)
        {
            prisoner.guest.ideoForConversion = Faction.OfPlayer.ideos.PrimaryIdeo;
        }

        prisoner.guest.SetExclusiveInteraction(PrisonerInteractionModeDefOf.Convert);
        __state = true;
    }

    public static void Postfix(Thing t, bool __state)
    {
        if (!__state)
        {
            return;
        }

        ((Pawn)t)?.guest?.SetExclusiveInteraction(STWDefOf.ConvertThenRelease);
    }
}