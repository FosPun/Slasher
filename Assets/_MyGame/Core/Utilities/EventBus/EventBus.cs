using System;
using System.Collections.Generic;

public static class EventBus
{
    private static Dictionary<Type, Delegate> _eventHandlers = new Dictionary<Type, Delegate>();

    public static void Subscribe<T>(Action<T> callback) where T : GameEvent
    {
        Type eventType = typeof(T);

        if (_eventHandlers.ContainsKey(eventType))
        {
            _eventHandlers[eventType] = Delegate.Combine(_eventHandlers[eventType], callback);
        }
        else
        {
            _eventHandlers[eventType] = callback;
        }
    }

    public static void Unsubscribe<T>(Action<T> callback) where T : GameEvent
    {
        Type eventType = typeof(T);

        if (_eventHandlers.ContainsKey(eventType))
        {
            var currentDelegate = _eventHandlers[eventType];
            var newDelegate = Delegate.Remove(currentDelegate, callback);

            if (newDelegate == null)
            {
                _eventHandlers.Remove(eventType);
            }
            else
            {
                _eventHandlers[eventType] = newDelegate;
            }
        }
    }

    public static void Publish<T>(T gameEvent) where T : GameEvent
    {
        Type eventType = typeof(T);

        if (_eventHandlers.ContainsKey(eventType))
        {
            if (_eventHandlers[eventType] is Action<T> action)
            {
                action.Invoke(gameEvent);
            }
        }
    }
}
