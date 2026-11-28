using System;
using UnityEngine;
using Object = UnityEngine.Object;

namespace UniFoundation.Scripts.Shared.Managers
{
    [DefaultExecutionOrder(-1)]
    public abstract class ManagerBase<T> : GameBehaviour where T : ManagerBase<T>
    {
        public static T Instance { get; private set; }

        public bool IsInitialized() => Instance != null;

        public void Initialize()
        {
            if (Instance != null)
            {
                Debug.LogWarning($"{typeof(T).Name} 인스턴스가 이미 존재합니다.");
                return;
            }
            
            Instance = (T)this;
            
            OnInitialized();
        }

        protected virtual void OnDestroy()
        {
            if (Instance == this)
                Instance = null;
        }

        protected virtual void OnInitialized()
        {
        }
    }
}