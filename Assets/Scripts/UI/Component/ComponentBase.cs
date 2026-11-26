using System.Threading;
using UniFoundation.Scripts.Shared;
using UniFoundation.Scripts.UI.Component.Interface;
using UniFoundation.Scripts.UI.Component.Type;
using UnityEngine;

namespace UniFoundation.Scripts.UI.Component
{
    public class ComponentBase : GameBehaviour, IUICompnent
    {
        private CancellationTokenSource animCTS;
        protected RectTransform rectTrs;
        protected UIState UIState;
        protected bool isInited;

        public UIState GetUIState => UIState;
        public bool EqualState(UIState state) => UIState == state;

        public virtual void Initialize()
        {
            rectTrs = GetComponent<RectTransform>();
            isInited = true;
        }

        public virtual void OnShow()
        {
            // 추후 tween하고 합쳐질듯
        }

        public virtual void OnHide()
        {
            // this one too.
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