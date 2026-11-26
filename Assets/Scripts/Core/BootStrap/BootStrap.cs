using UniFoundation.Scripts.Core.EventBus;
using UniFoundation.Scripts.Shared;
using UniFoundation.Scripts.Shared.Managers;

namespace UniFoundation.Scripts.Core.BootStrap
{
    /// <summary>
    /// 게임의 모든 초기화는 해당 클래스에서 담당합니다.
    /// 이벤트 버스, 리퀘스트 버스, 매니저, UI, ETC.
    /// </summary>
    public class BootStrap : GameBehaviour
    {
        private void Start()
        {
            InitializeScripts();
        }

        private void InitializeScripts()
        {
            EventHub.Instance.Initialize();
            
            GameManager.Instance.Initialize();
            SceneManager.Instance.Initialize();
            CamManager.Instance.Initialize();
            SaveManager.Instance.Initialize();
            UIManager.Instance.Initialize();
        }
    }
}