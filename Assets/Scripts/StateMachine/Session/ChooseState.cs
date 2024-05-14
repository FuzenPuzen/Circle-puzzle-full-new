using Zenject;

public class ChooseState : IBaseState
{
    [Inject] private StateMachine _stateMachine;
    [Inject] private IDifficultDataManager _difficultDataManager;
    [Inject] private IDifficultyService _difficultyService;
    [Inject] private IPicturesDataManager _picturesDataManager;

    public void Enter()
    {
        _picturesDataManager.ActivateService();

        _difficultDataManager.ActivateService();
        _difficultyService.ActivateService();
    }

    public void Exit()
    {
        throw new System.NotImplementedException();
    }
}
