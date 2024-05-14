using Zenject;


public interface IDifficultyService : IService
{
	public CirclesSOData GetCurrentCircleData();
}

public class DifficultyService : IDifficultyService
{
	[Inject] private IServiceFabric _serviceFabric;
	[Inject] private ISOStorageService _sOStorageService;
	[Inject] private IDifficultDataManager _difficultDataManager;
	
	private DifficultyLevelsSO _difficultyLevelsSO;
	private int _difficultyLevel;

    public void ActivateService()
	{
		_difficultyLevelsSO = _sOStorageService.GetSOByType<DifficultyLevelsSO>() as DifficultyLevelsSO;
		_difficultyLevel = _difficultDataManager.GetCurrentDifficult();
    }

	public CirclesSOData GetCurrentCircleData() => _difficultyLevelsSO.GetCirclesData(_difficultyLevel);
}
