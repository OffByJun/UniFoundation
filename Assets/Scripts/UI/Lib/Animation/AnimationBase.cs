using System;
using System.Resources;
using DG.Tweening;
using UniFoundation.Scripts.Shared;

namespace UI.Lib.Animation
{
    [System.Serializable]
    public class AnimationBase
    {
        private Tween tween;
        public bool isLoop = false;
        
        public void Start()
        {
            if (tween == null) return;
            
            Play(tween);
        }

        public void Pause()
        {
            if (tween == null) return;
            
            Stop(tween);
        }

        public AnimationBase IsPlaying(Action callback)
        {
            tween?.OnPlay(() => callback?.Invoke());
            return this;
        }

        public AnimationBase IsComplete(Action callback)
        {
            tween?.OnComplete(() => callback?.Invoke());
            return this;
        }


        #region API
        
        public void SetLoop(bool isLoop = false) => this.isLoop = isLoop;
        public void SetTween(Tween tween) => this.tween = tween;

        public virtual void Play(Tween tween)
        {
            
        }

        public virtual void Stop(Tween tween)
        {
            
        }

        #endregion
    }
}