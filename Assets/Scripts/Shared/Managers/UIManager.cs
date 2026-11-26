using System;
using System.Collections.Generic;
using NUnit.Framework.Constraints;
using UniFoundation.Scripts.Core;
using UniFoundation.Scripts.Core.EventBus;
using UniFoundation.Scripts.Core.EventBus.Lib;
using UniFoundation.Scripts.UI.Component.Interface;
using UniFoundation.Scripts.UI.Panel;
using UniFoundation.Scripts.UI.Panel.Interface;

namespace UniFoundation.Scripts.Shared.Managers
{
    public class UIManager : ManagerBase<UIManager>
    {
        private Dictionary<string, IPanel> panels = new();
        private EventBus<UIDomain> uiBus;

        public override void Initialize()
        {
            base.Initialize();
            var temp = GetComponentsInChildren<PanelBase>(true);

            foreach (var panel in temp)
            {
                if (panel is IPanel panelHandler)
                {
                    panels.Add(panel.name, panelHandler);
                    panelHandler.Initialize();
                }
            }

            uiBus = EventHub.Instance.Get<UIDomain>();
            RegisterMethod();
        }

        private void RegisterMethod()
        {
            uiBus.Register<OpenPanelRequest, bool>(
                req => TryOpen(req.panelName));
            
            uiBus.Register<ClosePanelRequest, bool>(
                req => TryClose(req.panelName));
            
            uiBus.Register<CloseAllPanelRequest, bool>(
                req => TryCloseAll());
        }

        private void UnRegisterMethod()
        {
            uiBus.UnRegister<OpenPanelRequest>();
            uiBus.UnRegister<ClosePanelRequest>();
            uiBus.UnRegister<CloseAllPanelRequest>();
        }
        
        public bool TryOpen(string panelName)
        {
            if (!panels.TryGetValue(panelName, out var panel)) return false;
            
            panel.Open();
            return true;
        }

        public bool TryClose(string panelName)
        {
            if (!panels.TryGetValue(panelName, out var panel)) return false;
            
            panel.Close();
            return true;
        }

        public bool TryCloseAll()
        {
            if (panels.Count == 0) return false;
            foreach (var panel in panels)
            {
                panel.Value.Close();
            }

            return true;
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();
            UnRegisterMethod();
        }
    }
}