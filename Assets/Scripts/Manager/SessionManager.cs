using UnityEngine;
using Zenject;

public class SessionManager : MonoBehaviour
{
    [Inject] private StateMachine _stateMachine;


    void Start()
    {
        _stateMachine.SetState<InitState>();
    }


}
