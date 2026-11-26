using System.Collections.Generic;
using System.Linq;
using UniFoundation.Scripts.Core.EventBus;
using UniFoundation.Scripts.Shared;
using UniFoundation.Scripts.UI.Component;
using UniFoundation.Scripts.UI.Component.Interface;
using UniFoundation.Scripts.UI.Panel.Interface;

namespace UniFoundation.Scripts.UI.Panel
{
    public abstract class PanelBase : GameBehaviour, IPanel
    {
        List<IUICompnent> components = new();
        private bool hasOpened = false;
        private bool hasInited = false;
        
        public virtual void Initialize()
        {
            if (hasInited) return;
            
            components = gameObject.GetComponentsInChildren<ComponentBase>(true)
                .OfType<IUICompnent>()
                .ToList();
            
            foreach (var uiComponent in components)
            {
                uiComponent.Init();
            }

            hasInited = true;
        }

        public virtual void Open()
        {
            if (hasOpened && hasInited) return;
            hasOpened = true;

            foreach (var uiComponent in components)
            {
                uiComponent.OnShow();
            }
        }

        public virtual void Close()
        {
            if (!hasOpened && hasInited) return;
            hasOpened = false;

            foreach (var uiComponent in components)
            {
                uiComponent.OnHide();
            }
        }

        public virtual void Release()
        {
            if (!hasInited) return;
            hasInited = false;
            
            foreach (var uiComponent in components)
            {
                uiComponent.Release();
            }
        }
    }
}