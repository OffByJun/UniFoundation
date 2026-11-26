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

        protected UIAnimation()
        {
            sq = DOTween.Sequence();
            sq.Pause();
        }

        public UIAnimation<T> Append(Tween tween)
        {
            sq.Append(tween);
            return (T)this;
        }

        public UIAnimation<T> Join(Tween tween)
        {
            sq.Join(tween);
            return (T)this;
        }

        public UIAnimation<T> Delay(float delay)
        {
            sq.AppendInterval(delay);
            return (T)this;
        }
        
        
    }
}