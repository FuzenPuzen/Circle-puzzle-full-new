using Zenject;

public class InitState : IBaseState
{
    [Inject] private IMarkerService _markerService;
    [Inject] private StateMachine _stateMachine;
    [Inject] private GameCanvasViewService _gameCanvasViewService;
    [Inject] private MainCameraViewService _mainCameraViewService;
    [Inject] private IScoreDataManager _scoreDataManager;
    [Inject] private IAudioService _audioService;



    public void Enter()
    {
        _mainCameraViewService.ActivateService();
        _markerService.ActivateService();
        _gameCanvasViewService.ActivateService();
        _scoreDataManager.ActivateService();
        _audioService.ActivateService();
        _stateMachine.SetState<ChooseState>();
    }

    public void Exit()
    {
        
    }

}
