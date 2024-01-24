using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventAggrigator
{
    public class Event
    {
        public string Name { get; }

        public Event(string name)
        {
            Name = name;
        }
    }

    public class EventAggregator
    {
        private static EventAggregator _instance;
        private static readonly object _lock = new object();

        private readonly Dictionary<Type, List<Action<Event>>> _subscribers = new Dictionary<Type, List<Action<Event>>>();

        private EventAggregator()
        {
        }

        public static EventAggregator Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_lock)
                    {
                        if (_instance == null)
                        {
                            _instance = new EventAggregator();
                        }
                    }
                }
                return _instance;
            }
        }

        public void Subscribe<TEvent>(Action<TEvent> handler) where TEvent : Event
        {
            Type eventType = typeof(TEvent);
            if (!_subscribers.ContainsKey(eventType))
            {
                _subscribers[eventType] = new List<Action<Event>>();
            }

            _subscribers[eventType].Add(ev => handler((TEvent)ev));
        }

        public void Publish<TEvent>(TEvent ev) where TEvent : Event
        {
            Type eventType = typeof(TEvent);
            if (_subscribers.ContainsKey(eventType))
            {
                foreach (var subscriber in _subscribers[eventType])
                {
                    subscriber(ev);
                }
            }
        }
    }

}
