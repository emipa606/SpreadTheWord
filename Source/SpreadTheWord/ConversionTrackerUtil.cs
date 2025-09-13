using Verse;

namespace SpreadTheWord;

public static class ConversionTrackerUtil
{
    public static void Reset(string key)
    {
        if (isInitialized())
        {
            getComp().Reset(key);
        }
    }

    public static int InsertThenGetStat(string key, int value)
    {
        AddStat(key, value);
        return GetStat(key);
    }

    public static void AddStat(string key, int value)
    {
        if (isInitialized())
        {
            getComp().AddEntry(key, value);
        }
    }

    public static int GetStat(string key)
    {
        return isInitialized() ? getComp().GetEntry(key) : 0;
    }

    private static bool isInitialized()
    {
        return getComp() != null;
    }

    private static FactionConversionWorldComponent getComp()
    {
        return Find.World.GetComponent<FactionConversionWorldComponent>();
    }
}