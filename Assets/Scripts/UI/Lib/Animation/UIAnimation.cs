using System.Threading;
using DG.Tweening;
using UniFoundation.Scripts.Shared;

namespace UniFoundation.Scripts.UI.Lib.Animation
{
    /// <summary>
    /// 체이닝을 기반으로 하여 사용되는것
    /// </summary>
    public abstract class UIAnimation<T> where T : UIAnimation<T>
    {
        protected readonly Sequence sq;
        private bool hasPlayed;

        protected UIAnimation()
        {
            sq = DOTween.Sequence();
            sq.Pause();
        }

        public T Append(Tween tween)
        {
            sq.Append(tween);
            return (T)this;
        }

        public T Join(Tween tween)
        {
            sq.Join(tween);
            return (T)this;
        }

        public T Delay(float delay)
        {
            sq.AppendInterval(delay);
            return (T)this;
        }

        public void Play(CancellationToken cts)
        {
            if (hasPlayed || !sq.IsActive()) return;
            
            if (cts.IsCancellationRequested)
            {
                Cancel();
                return;
            }

            hasPlayed = true;

            var regist = cts.Register(() => Cancel());
            sq.OnKill(() => regist.Dispose());
            
            sq.Play();
        }

        public void Cancel()
        {
            if (sq.IsActive())
                sq.Kill(false);
        }
        
        public T OnStart(TweenCallback callback)
        {
            sq.OnStart(callback);
            return (T)this;
        }

        public T OnComplete(TweenCallback callback)
        {
            sq.onComplete = callback;
            return (T)this;
        }
    }
}