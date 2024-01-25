using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventAggrigator
{
    using System;
    using System.Collections.Generic;

    public class Event
    {
        public string Name { get; }

        public Event(string name)
        {
            Name = name;
        }
    }

    public sealed class EventAggregator
    {
        private static readonly Lazy<EventAggregator> _instance = new Lazy<EventAggregator>(() => new EventAggregator());
        private readonly object _lock = new object();

        private readonly Dictionary<Type, List<Action<Event>>> _subscribers = new Dictionary<Type, List<Action<Event>>>();

        private EventAggregator()
        {
        }

        public static EventAggregator Instance => _instance.Value;

        public void Subscribe<TEvent>(Action<TEvent> handler) where TEvent : Event
        {
            Type eventType = typeof(TEvent);
            lock (_lock)
            {
                if (!_subscribers.ContainsKey(eventType))
                {
                    _subscribers[eventType] = new List<Action<Event>>();
                }

                _subscribers[eventType].Add(ev => handler((TEvent)ev));
            }
        }

        public void Publish<TEvent>(TEvent ev) where TEvent : Event
        {
            Type eventType = typeof(TEvent);
            lock (_lock)
            {
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


}
