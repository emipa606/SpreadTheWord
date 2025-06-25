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
        addStat(key, value);
        return GetStat(key);
    }

    private static void addStat(string key, int value)
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
        return Find.CurrentMap.GetComponent<ConversionTrackerComponent>() != null;
    }

    private static ConversionTrackerComponent getComp()
    {
        return Find.CurrentMap.GetComponent<ConversionTrackerComponent>();
    }
}