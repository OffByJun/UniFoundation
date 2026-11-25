using UnityEngine;

namespace UniFoundation.Scripts.Shared.Managers
{
    public class ManagerBase<T> : GameBehaviour
    {
        public static T Instance { get; private set; }

        protected virtual void Awake()
        {
            if (Instance == null)
            {
                Instance = (T)(object)this;
            }
            else
            {
                Debug.LogWarning($"{typeof(T).Name} 인스턴스가 이미 존재합니다. 새 인스턴스를 삭제합니다.");
                Destroy(gameObject);
            }
        }
    }
}