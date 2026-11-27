using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using DG.Tweening;
using NUnit.Framework;
using UI.Lib.Animation;
using UniFoundation.Scripts.Shared;
using UniFoundation.Scripts.UI.Component.Interface;
using UniFoundation.Scripts.UI.Component.Type;
using UnityEngine;

namespace UniFoundation.Scripts.UI.Component
{
    public class ComponentBase : GameBehaviour, IUIComponent
    {
        private CancellationTokenSource animCTS;
        protected RectTransform rectTrs;
        protected UIState UIState;
        protected bool isInited;

        public UIState GetUIState => UIState;
        public bool EqualState(UIState state) => UIState == state;

        [SerializeField] private List<AnimationBase> showAnims = new();
        [SerializeField] private List<AnimationBase> hideAnims = new();
        
        
        #region Internal Methods
        
        public void Initialize()
        {
            rectTrs = GetComponent<RectTransform>();
            isInited = true;
        }

        public void OnShow()
        {
            if (EqualState(UIState.Entering) || EqualState(UIState.Visible) || !isInited) return;

            UIState = UIState.Entering;
            var token = CreateAnimationToken();

            Open();

            int remain = showAnims.Count;
            
            foreach (var anim in showAnims)
                Animation(token, anim)?.IsComplete(() =>
                {
                    remain--;

                    if (remain <= 0)
                        UIState = UIState.Visible;
                });
        }

        public void OnHide()
        {
            if (EqualState(UIState.Exiting) || EqualState(UIState.Hidden) || !isInited) return;
            
            UIState = UIState.Exiting;
            var token = CreateAnimationToken();
            
            Close();
            
            int remain = hideAnims.Count;
            
            foreach (var anim in hideAnims)
                Animation(token, anim)?.IsComplete(() =>
                {
                    remain--;

                    if (remain <= 0)
                        UIState = UIState.Hidden;
                });
        }

        public void Clear()
        {
            if (!isInited) return;
            
            CancelAnimation();
            Release();
        }

        public AnimationBase Animation(CancellationToken token, AnimationBase animClip)
        {
            if (!isInited) return null;
            
            animClip.Start();
            return animClip;
        }

        private CancellationToken CreateAnimationToken()
        {
            CancelAnimation();

            animCTS = new CancellationTokenSource();
            return animCTS.Token;
        }

        private void CancelAnimation()
        {
            animCTS?.Cancel();
            animCTS?.Dispose();

            animCTS = null;
        }

        #endregion
        
        #region APIs

        /// <summary>
        /// 해당 메서드를 Override하여 Open될때 동작을 정의합니다
        /// </summary>
        /// <param name="onComplete"></param>
        public virtual void Open(Action onComplete = null)
        {
        }

        /// <summary>
        /// 해당 메서드를 Override하여 Close될때 동작을 정의합니다.
        /// </summary>
        /// <param name="onComplete"></param>
        public virtual void Close(Action onComplete = null)
        {
        }

        /// <summary>
        /// 해당 메서들르 Override하여 Release될때 동작을 정의합니다.
        /// </summary>
        public virtual void Release()
        {
        }

        #endregion
    }
}