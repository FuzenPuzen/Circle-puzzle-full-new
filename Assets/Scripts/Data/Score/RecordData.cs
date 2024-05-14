using EventBus;
using UnityEngine;
using Zenject;

public class RecordData
{
    public int Record;
}

public interface IRecordDataManager : IService
{
    public int GetRecord();
    public void DeactivateService();
}

public class RecordDataManager : IRecordDataManager
{
    private RecordData _recordData;
    [Inject] private YSaveService _YSaveService;
    private EventBinding<ScoreChanged> _scoreChanged;
    private const string RecordKey = "RecordKey";

    public void ActivateService()
    {
        _recordData = LoadRecord();
        _scoreChanged = new(CheckRecord);
    }

    public int GetRecord() => _recordData.Record;

    public void DeactivateService()
    {
        _scoreChanged.Remove(CheckRecord);
    }

    private void CheckRecord(ScoreChanged scoreChanged)
    {
        if (_recordData.Record < scoreChanged.score)
            SetRecord(scoreChanged.score);
    }

    private RecordData LoadRecord()
    {       
        return _YSaveService.LoadRecord();
    }

    private void SetRecord(int newRecord)
    {
        _recordData.Record = newRecord;
        _YSaveService.SaveRecord(_recordData);
        EventBus<RecordChanged>.Raise(new RecordChanged { record = newRecord });
    }

}
