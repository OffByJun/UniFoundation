using System;
using System.Threading;
using System.Threading.Tasks;
using UniFoundation.Scripts.UI.Component.Type;

namespace UniFoundation.Scripts.UI.Component.Interface
{
    public interface IUIComponent
    {
        public void Open(Action onComplete = null);
        
        public void Close(Action onComplete = null);

        public void Release();
    }
}