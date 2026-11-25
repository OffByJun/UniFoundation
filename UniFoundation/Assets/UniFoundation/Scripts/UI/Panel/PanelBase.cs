using System.Collections.Generic;
using System.Linq;
using UniFoundation.Scripts.Shared;
using UniFoundation.Scripts.UI.Component;
using UniFoundation.Scripts.UI.Component.Interface;

namespace UniFoundation.Scripts.UI.Panel
{
    public class PanelBase : GameBehaviour
    {
        List<IUICompnent> components = new();
        
        protected virtual void Awake()
        {
            components = gameObject.GetComponentsInChildren<ComponentBase>(true)
                .OfType<IUICompnent>()
                .ToList();
            
            Initialize();
        }
        
        public virtual void OnShow()
        {
            foreach (var uiComponent in components)
            {
                uiComponent.OnShow();
            }
        }

        public virtual void OnHide()
        {
            foreach (var uiComponent in components)
            {
                uiComponent.OnHide();
            }
        }

        private void Initialize()
        {
            foreach (var uiComponent in components)
            {
                uiComponent.Init();
            }
        }
    }
}