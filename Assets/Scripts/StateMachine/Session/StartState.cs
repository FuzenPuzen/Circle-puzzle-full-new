using Zenject;

public class StartState : IBaseState
{
    [Inject] private StateMachine _stateMachine;
    [Inject] private LineGeneratorService _lineGeneratorService;
    [Inject] private RotateLineService _rotateLineService;


    public void Enter()
    {        
        _lineGeneratorService.ActivateService();
        _rotateLineService.ActivateService();
    }

    public void Exit()
    {
       
    }
}
