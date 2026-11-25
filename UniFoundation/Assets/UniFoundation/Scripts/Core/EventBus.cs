using System;
using System.Collections.Generic;
using Unity.Properties;

namespace UniFoundation.Scripts.Core
{
    public abstract class EventBus<TDomain>
    {
        private readonly Dictionary<Type, Delegate> events = new();

        public void Subscribe<T>(Action<T> callback) where T : TDomain
        {
            var type = typeof(T);
            
            events.TryGetValue(type, out var exist);
            events[type] = Delegate.Combine(exist, callback);
        }

        public void UnSubScribe<T>(Action<T> callback) where T : TDomain
        {
            var type = typeof(T);

            if (events.TryGetValue(type, out var exist) == false) 
                return;
            
            events[type] = Delegate.Remove(exist, callback);
            if (events[type] == null) events.Remove(type);
        }

        public void Publish<T>(T domain) where T : TDomain
        {
            var type = typeof(T);

            events.TryGetValue(type, out var exist);

            if (exist is Action<T> handler)
            {
                handler.Invoke(domain);
            }
        }
    }
}