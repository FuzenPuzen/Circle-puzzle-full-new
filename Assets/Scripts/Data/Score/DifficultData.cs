using EventBus;

public class DifficultData 
{
    public int Difficult;
}

public interface IDifficultDataManager : IService
{
    public int GetCurrentDifficult();
}

public class DifficultDataManager : IDifficultDataManager
{
    private DifficultData _difficultData = new ();

    public void ActivateService()
    {
        // Load
        _difficultData.Difficult = 2;
    }

    public int GetCurrentDifficult() => _difficultData.Difficult;

}

