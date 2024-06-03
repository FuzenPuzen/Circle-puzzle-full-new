using EventBus;
using Zenject;

public class DifficultSLData 
{
    public int Difficult = 0;
}

public interface IDifficultDataManager : IService
{
    public int GetCurrentDifficult();
}

public class DifficultDataManager : IDifficultDataManager
{
    [Inject] private ILoadService _saveService;
    private DifficultSLData _difficultData = new();
    private const string DifKey = "DifKey";
    private EventBinding<OnDifficultChanged> _onDifficultChanged;

    public void ActivateService()
    {
        _difficultData = _saveService.LoadData(_difficultData, DifKey);
        _onDifficultChanged = new(DifficultChanged);
    }

    public int GetCurrentDifficult() => _difficultData.Difficult;

    public void DifficultChanged(OnDifficultChanged onDifficultChanged)
    {
        _difficultData.Difficult = onDifficultChanged.Difficult;
        _saveService.SaveItem(_difficultData, DifKey);
    }

}

