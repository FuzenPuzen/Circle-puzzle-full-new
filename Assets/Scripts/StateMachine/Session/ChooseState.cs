using Zenject;

public class ChooseState : IBaseState
{
    [Inject] private StateMachine _stateMachine;
    [Inject] private IDifficultDataManager _difficultDataManager;
    [Inject] private IDifficultyService _difficultyService;
    [Inject] private IPicturesDataManager _picturesDataManager;

    [Inject] private ChoosePanelViewService _choosePanelViewService;


    public void Enter()
    {
        _picturesDataManager.ActivateService();

        _difficultDataManager.ActivateService();
        _difficultyService.ActivateService();

        _choosePanelViewService.ActivateService();

    }

    public void Exit()
    {
        throw new System.NotImplementedException();
    }
}
