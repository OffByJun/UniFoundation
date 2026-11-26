using UniFoundation.Scripts.UI.Panel.Type;

namespace UniFoundation.Scripts.Core.EventBus.Lib
{
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