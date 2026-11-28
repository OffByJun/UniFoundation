using UniFoundation.Scripts.Core.EventBus;
using UniFoundation.Scripts.Shared;
using UniFoundation.Scripts.Shared.Managers;
using UnityEditor;
using UnityEngine;

namespace UniFoundation.Scripts.Core.BootStrap
{
    /// <summary>
    /// 게임의 모든 초기화는 해당 클래스에서 담당합니다.
    /// 이벤트 버스, 리퀘스트 버스, 매니저, UI, ETC.
    /// </summary>
    [DefaultExecutionOrder(0)]
    public class BootStrap : GameBehaviour
    {
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        private static void InitializeScripts()
        {
            var obj = new GameObject("[ManagerObject - Do Not Destroy]");
            DontDestroyOnLoad(obj);
            
            obj.AddComponent<EventHub>().Initialize();

            obj.AddComponent<GameManager>().Initialize();
            obj.AddComponent<SceneManager>().Initialize();
            obj.AddComponent<CamManager>().Initialize();
            obj.AddComponent<SaveManager>().Initialize();
            obj.AddComponent<UIManager>().Initialize();
        }
    }
}