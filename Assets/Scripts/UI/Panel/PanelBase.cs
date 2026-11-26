using System.Collections.Generic;
using System.Linq;
using UniFoundation.Scripts.Core.EventBus;
using UniFoundation.Scripts.Shared;
using UniFoundation.Scripts.UI.Component;
using UniFoundation.Scripts.UI.Component.Interface;
using UniFoundation.Scripts.UI.Component.Type;
using UniFoundation.Scripts.UI.Panel.Interface;

namespace UniFoundation.Scripts.UI.Panel
{
    /// <summary>
    /// 모든 Panel은 해당 클래스를 상속해야합니다
    /// </summary>
    public abstract class PanelBase : ComponentBase
    {
        List<IUICompnent> components = new();
        
        public override void Initialize()
        {
            if (isInited) return;
            base.Initialize();
            
            components = gameObject.GetComponentsInChildren<ComponentBase>(true)
                .OfType<IUICompnent>()
                .ToList();
            
            foreach (var uiComponent in components)
            {
                uiComponent.Initialize();
            }

            isInited = true;
        }

        public override void OnShow()
        {
            if ((EqualState(UIState.Visible) 
                 || EqualState(UIState.Entering)) 
                && !isInited) return;
            base.OnShow();

            foreach (var uiComponent in components)
            {
                uiComponent.OnShow();
            }
        }

        public override void OnHide()
        {
            if ((EqualState(UIState.Hidden)
                || EqualState(UIState.Exiting))
                && !isInited) return;
            base.OnHide();

            foreach (var uiComponent in components)
            {
                uiComponent.OnHide();
            }
        }

        public override void Release()
        {
            if (!isInited) return;
            base.Release();
            isInited = false;
            
            foreach (var uiComponent in components)
            {
                uiComponent.Release();
            }
        }
    }
}