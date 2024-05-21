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

    public void ActivateService()
    {
        _difficultData = _saveService.LoadData(_difficultData, DifKey);
    }

    public int GetCurrentDifficult() => _difficultData.Difficult;

}

