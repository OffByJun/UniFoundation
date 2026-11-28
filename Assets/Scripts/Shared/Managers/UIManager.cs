using System;
using System.Collections.Generic;
using NUnit.Framework.Constraints;
using UI.Lib.Panel;
using UniFoundation.Scripts.Core;
using UniFoundation.Scripts.Core.EventBus;
using UniFoundation.Scripts.Core.EventBus.Lib;
using UnityEngine;

namespace UniFoundation.Scripts.Shared.Managers
{
    public class UIManager : ManagerBase<UIManager>
    {
        private Dictionary<string, PanelBase> panels = new();
        private EventBus<UIDomain> uiBus;

        protected override void OnInitialized()
        {
            var temp = GetComponentsInChildren<PanelBase>(true);

            foreach (var panel in temp)
            {
                    panels.Add(panel.name, panel);
                    panel.Initialize();
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
            
            panel.OnShow();
            return true;
        }

        public bool TryClose(string panelName)
        {
            if (!panels.TryGetValue(panelName, out var panel)) return false;
            
            panel.OnHide();
            return true;
        }

        public bool TryCloseAll()
        {
            if (panels.Count == 0) return false;
            foreach (var panel in panels)
            {
                panel.Value.OnHide();
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