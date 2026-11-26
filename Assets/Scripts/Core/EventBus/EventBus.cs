    using System;
    using System.Collections.Generic;
    using UniFoundation.Scripts.Core.Interface;
    using Unity.Properties;

    namespace UniFoundation.Scripts.Core.EventBus
    {
        /// <summary>
        /// 인스턴스를 새로 만들어서 작동시키세요
        /// </summary>
        /// <typeparam name="TDomain"></typeparam>
        public class EventBus<TDomain> : IEventBus  
            where TDomain : DomainBase
        {
            private readonly Dictionary<Type, Delegate> events = new();
            private readonly Dictionary<Type, Delegate> requests = new();

            #region EventBus

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

            #endregion

            #region RequestBus

            public virtual void Register<T, TResult>(Func<T, TResult> handler) where T : TDomain
            {
                var type = typeof(T);

                if (!requests.TryAdd(type, handler))
                    throw new InvalidOperationException("이미 등록된 리퀘스트입니다!");
            }

            public virtual void UnRegister<T>() where T : TDomain
            {
                var type = typeof(T);

                requests.Remove(type);
            }

            public virtual TResult Request<T, TResult>(T req) where T : TDomain
            {
                var type = typeof(T);

                var exist = requests.TryGetValue(type, out var request);

                if (request is Func<T, TResult> handler)
                    return handler.Invoke(req);

                throw new InvalidOperationException("요청한 처리자가 없거나 타입이 일치하지 않습니다.");
            }

            #endregion
        }
    }