using System;
using System.Collections.Generic;
using Zenject;

public class StateMachine
{
    public IState CurrentState { get;private set; }

    public event Action<IState> StateChanged;
    private readonly Dictionary<Type, IState> _states = new Dictionary<Type, IState>();

    [Inject]
    private void Construct(List<IState> states)
    {
        foreach (var state in states)
        {
            _states.TryAdd(state.GetType(), state);
        }
    }
    public IState GetState<T>() where T : IState
    {
        var type = typeof(T);
        return _states.GetValueOrDefault(type);
    }
    public void Initialize<T>() where T : IState
    {
        var startingState = GetState<T>();
        if (startingState == null) return;
        CurrentState = startingState;
        CurrentState.Enter();
        StateChanged?.Invoke(CurrentState);
    }

    public void ChangeState<T>() where T : IState
    {
        var nextState = GetState<T>();
        
        if (nextState == null)
        {
            return;
        }

        if (CurrentState == nextState) return;

        CurrentState?.Exit();
        CurrentState = nextState;
        CurrentState?.Enter();
        StateChanged?.Invoke(CurrentState);
    }

    public void Execute()
    {
        CurrentState?.Execute();
    }
}
