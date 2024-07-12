using RimWorld;

namespace SpreadTheWord;

public class HistoryAutoRecorderWorker_Proselytizers : HistoryAutoRecorderWorker
{
    public override float PullRecord()
    {
        return ConversionTrackerUtil.GetStat("crazedmonkey231.spread.the.word");
    }
}