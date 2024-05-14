using YG;

public class YSaveService
{
    /*public YSaveService()
    {
        YandexGame.LoadCloud();
    }*/

    public void SaveRecord(RecordData item)
    {
#if !UNITY_EDITOR
        YandexGame.savesData.RecordData = item.Record;
        YandexGame.SaveCloud();
#endif
    }

    public RecordData LoadRecord()
    {

        RecordData temp = new RecordData();
#if !UNITY_EDITOR
        temp.Record = YandexGame.savesData.RecordData;
        return temp;
#endif
        return temp;
    }
}
