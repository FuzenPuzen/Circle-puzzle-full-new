using Zenject;

public class StartState : IBaseState
{
    [Inject] private StateMachine _stateMachine;
    [Inject] private LineGeneratorService _lineGeneratorService;
    [Inject] private RotateLineService _rotateLineService;
    [Inject] private IDifficultDataManager _difficultDataManager;
    [Inject] private IDifficultyService _difficultyService;
    [Inject] private IPicturesDataManager _picturesDataManager;


    public void Enter()
    {
        _picturesDataManager.ActivateService();
        _difficultDataManager.ActivateService();
        _difficultyService.ActivateService();
        _lineGeneratorService.ActivateService();

        _rotateLineService.ActivateService();
    }

    public void Exit()
    {
       
    }
}
