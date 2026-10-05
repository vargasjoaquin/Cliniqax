using CliniqaxSystem.Application.Interfaces.Common;
using System.Collections.Concurrent;

namespace CliniqaxSystem.Infrastructure.Services
{
    public class AppEventBusService : IAppEventBus
    {
        private readonly ConcurrentDictionary<Type, List<Delegate>> _subscribers = new();

        public void Publish<T>(T message) where T : class
        {
            if (_subscribers.TryGetValue(typeof(T), out var handlers))
            {
                List<Delegate> copy;
                lock (handlers)
                {
                    copy = handlers.ToList();
                }

                foreach (var handler in copy)
                {
                    if (handler is Action<T> action)
                    {
                        try { action(message); } catch { }
                    }
                }
            }
        }

        public void Subscribe<T>(Action<T> action) where T : class
        {
            var handlers = _subscribers.GetOrAdd(typeof(T), _ => new List<Delegate>());
            lock (handlers)
            {
                handlers.Add(action);
            }
        }

        public void Unsubscribe<T>(Action<T> action) where T : class
        {
            if (_subscribers.TryGetValue(typeof(T), out var handlers))
            {
                lock (handlers)
                {
                    handlers.Remove(action);
                }
            }
        }
    }
}
