using System.Collections.Generic;
using System.Linq;
using UniFoundation.Scripts.Shared;
using UniFoundation.Scripts.UI.Component;
using UniFoundation.Scripts.UI.Component.Interface;
using UniFoundation.Scripts.UI.Panel.Interface;

namespace UniFoundation.Scripts.UI.Panel
{
    public abstract class PanelBase : GameBehaviour, IPanel
    {
        List<IUICompnent> components = new();
        
        protected virtual void Awake()
        {
            components = gameObject.GetComponentsInChildren<ComponentBase>(true)
                .OfType<IUICompnent>()
                .ToList();
            
            Initialize();
        }

        public abstract void Open();

        public abstract void Close();

        protected virtual void Initialize()
        {
            foreach (var uiComponent in components)
            {
                uiComponent.Init();
            }
        }
    }
}