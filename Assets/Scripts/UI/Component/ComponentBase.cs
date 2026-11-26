using System.Threading;
using UniFoundation.Scripts.Shared;
using UniFoundation.Scripts.UI.Component.Interface;
using UnityEngine;

namespace UniFoundation.Scripts.UI.Component
{
    public class ComponentBase : GameBehaviour, IUICompnent
    {
        private CancellationTokenSource animCTS;
        protected RectTransform rectTrs;
        
        public virtual void Init()
        {
            rectTrs = GetComponent<RectTransform>();
        }

        public virtual void OnShow()
        {
        }

        public virtual void OnHide()
        {
            CancelAnimation();
        }

        public virtual void Release()
        {
            CancelAnimation();
        }

        public virtual void Animate()
        {
            
        }

        protected CancellationToken CreateAnimationToken()
        {
            CancelAnimation();

            animCTS = new CancellationTokenSource();
            return animCTS.Token;
        }

        public void CancelAnimation()
        {
            animCTS?.Cancel();
            animCTS?.Dispose();
            
            animCTS = null;
        }
    }
}