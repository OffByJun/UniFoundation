using DG.Tweening;
using UnityEngine;

namespace UniFoundation.Scripts.UI.Lib.Animation
{
    public class RectAnimation : UIAnimation<RectAnimation>
    {
        private readonly RectTransform target;

        public RectAnimation(RectTransform target)
        {
            this.target = target;
        }

        #region Position

        public RectAnimation MoveTo(
            Vector2 pos, float duration, Ease ease = Ease.Linear)
        {
            return Append(target.DOAnchorPos(pos, duration)
                .SetEase(ease));
        }

        public RectAnimation MoveBy(
            Vector2 pos, float duration, Ease ease = Ease.Linear)
        {
            return Append(target.DOAnchorPos(pos, duration)
                .SetEase(ease)
                .SetRelative());
        }

        public RectAnimation MoveX(
            float x, float duration, Ease ease = Ease.Linear)
        {
            return Append(target.DOAnchorPosX(x, duration)
                .SetEase(ease));
        }

        public RectAnimation MoveY(
            float y, float duration, Ease ease = Ease.Linear)
        {
            return Append(target.DOAnchorPosY(y, duration)
                .SetEase(ease));
        }

        #endregion

        #region Scale

        public RectAnimation ScaleTo(
            float size, float duration, Ease ease = Ease.Linear)
        {
            return Append(target.DOScale(size, duration)
                .SetEase(ease));
        }

        public RectAnimation ScaleTo(
            Vector3 size, float duration, Ease ease = Ease.Linear)
        {
            return Append(target.DOScale(size, duration)
                .SetEase(ease));
        }

        public RectAnimation ScaleX(
            float size, float duration, Ease ease = Ease.Linear)
        {
            return Append(target.DOScaleX(size, duration)
                .SetEase(ease));
        }

        public RectAnimation ScaleY(
            float size, float duration, Ease ease = Ease.Linear)
        {
            return Append(target.DOScaleY(size, duration)
                .SetEase(ease));
        }

        #endregion

        #region Size

        public RectAnimation ScaleToDelta(
            float size, float duration, Ease ease = Ease.Linear)
        {
            return ScaleToDelta(
                new Vector2(size, size), duration, ease);
        }

        public RectAnimation ScaleToDelta(
            Vector2 size, float duration, Ease ease = Ease.Linear)
        {
            return Append(target.DOSizeDelta(size, duration)
                .SetEase(ease));
        }

        #endregion

        #region Rotation

        public RectAnimation RotateTo(
            float degrees, float duration, Ease ease = Ease.Linear)
        {
            return Append(target.DOLocalRotate(
                    new Vector3(0, 0, degrees), duration)
                .SetEase(ease));
        }

        public RectAnimation RotateBy(
            float degrees, float duration, Ease ease = Ease.Linear)
        {
            return Append(target.DOLocalRotate(
                    new Vector3(0, 0, degrees), duration)
                .SetEase(ease)
                .SetRelative());
        }

        #endregion
    }
}