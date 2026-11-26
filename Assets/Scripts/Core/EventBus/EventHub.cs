using System;
using System.Collections.Generic;
using UniFoundation.Scripts.Core.Interface;
using UniFoundation.Scripts.Shared;
using UniFoundation.Scripts.Shared.Managers;

namespace UniFoundation.Scripts.Core.EventBus
{
    public class EventHub : ManagerBase<EventHub>
    {
        private readonly Dictionary<Type, IEventBus> Buses = new();
        
        // 굳이 의미 없는거 같아서 삭제함
        // *주석 풀고 쓰지마
        // public void Register<TDomain>(EventBus<TDomain> bus) where TDomain : DomainBase
        // {
        //     var type = typeof(TDomain);
        //
        //     if (!Buses.TryAdd(type, bus))
        //     {
        //         throw new InvalidOperationException("이미 존재하는 버스입니다!");
        //     }
        // }
        //
        // public void UnRegister<TDomain>() where TDomain : DomainBase
        // {
        //     var type = typeof(TDomain);
        //
        //     if (!Buses.Remove(type))
        //         throw new InvalidOperationException("존재하지 않거나 잘못된 버스입니다!");
        // }

        public EventBus<TDomain> Get<TDomain>() where TDomain : DomainBase
        {
            var type = typeof(TDomain);

            if (Buses.TryGetValue(type, out var bus))
            {
                return (EventBus<TDomain>)bus;
            }
            else
            {
                var newBus = new EventBus<TDomain>();
                
                Buses.Add(type, newBus);
                return newBus;
            }
        }
    }
}