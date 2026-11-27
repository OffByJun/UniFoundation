using UniFoundation.Scripts.UI.Panel;

namespace UniFoundation.Scripts.Core.EventBus.Lib
{
    // UI 도메인의 리퀘스트들
    
    
    public class UIDomain : DomainBase
    {
        
    }

    public class OpenPanelRequest : UIDomain
    {
        public string panelName;
    }

    public class ClosePanelRequest : UIDomain
    {
        public string panelName;
    }

    public class CloseAllPanelRequest : UIDomain
    {
        public string panelName;
    }
}