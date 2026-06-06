using System;
using UnityEngine;

public class PlayerStateMachine
{
    public IState CurrentState { get;private set; }
    
    public event Action<IState> StateChanged;

    public OnGroundState OnGroundState;
    public InAirState InAirState;
    public MovingState MovingState;
    public PlayerStateMachine(PlayerCharacter playerCharacter)
    {
        OnGroundState = new OnGroundState(playerCharacter);
        InAirState = new InAirState(playerCharacter);
        MovingState = new MovingState(playerCharacter);
    }

    public void Initialize(IState initialState)
    {
        CurrentState = initialState;
        initialState.Enter();
        StateChanged?.Invoke(initialState);
    }

    public void TransitionTo(IState nextState)
    {
        CurrentState.Exit();
        CurrentState = nextState;
        nextState.Enter();
        StateChanged?.Invoke(nextState);
    }

    public void Execute()
    {
        CurrentState?.Execute();
    }
}
