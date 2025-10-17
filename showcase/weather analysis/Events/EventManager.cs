using System;
using System.Collections.Generic;
using System.Linq;

namespace syncfusion.weatheranalysis.wpf
{
    public sealed class EventManager
    {
        private static EventManager _instance;

        public static EventManager Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new EventManager();
                return _instance;
            }
        }

        private Dictionary<Type, List<object>> _events = new Dictionary<Type, List<object>>();

        private EventManager()
        {
        }

        public void Subscribe<T, U>(Action<U> action)
        {
            if (_events.TryGetValue(typeof(T), out var actions))
            {
                actions.Add(action);
            }
            else
            {
                _events.Add(typeof(T), new List<object>() { action });
            }
        }

        public void Unsubscribe<T, U>(Action<U> action)
        {
            if (_events.TryGetValue(typeof(T), out var actions))
            {
                actions.Remove(action);
            }
        }

        public void Publish<T, U>(U payload)
        {
            var actions = _events.FirstOrDefault(e => e.Key == typeof(T)).Value;
            if (actions != null)
            {
                foreach (var action in actions)
                {
                    (action as Action<U>)(payload);
                }
            }
        }
    }
}
