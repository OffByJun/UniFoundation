using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using UniFoundation.Scripts.UI.Component;
using UniFoundation.Scripts.UI.Component.Interface;
using UnityEditor;

namespace UI.Lib.Panel
{
    public class PanelBase : ComponentBase
    {
        List<IUIComponent> components = new List<IUIComponent>();
        
        public sealed override void Init(Action onComplete = null)
        {
            foreach (var uiComponent in GetComponentsInChildren<IUIComponent>(true))
            {
                if (ReferenceEquals(uiComponent, this)) continue;
                
                components.Add(uiComponent);
            }
            
            Register();
            
            onComplete?.Invoke();
        }

        public sealed override void Open(Action onComplete = null)
        {
            foreach (var component in components)
            {
                component.Open(onComplete);
            }
            Show();
            
            onComplete?.Invoke();
        }

        public sealed override void Close(Action onComplete = null)
        {
            foreach (var component in components)
            {
                component.Close(onComplete);    
            }
            Hide();
            
            onComplete?.Invoke();
        }

        #region API

        public virtual void Register()
        {
        }

        public virtual void Hide()
        {
        }

        public virtual void Show()
        {
        }

        #endregion
    }
}