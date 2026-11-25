namespace UniFoundation.Scripts.UI.Component.Interface
{
    public interface IUICompnent
    {
        public void Init();
        public void OnShow();
        public void OnHide();
        public void Release();
    }
}