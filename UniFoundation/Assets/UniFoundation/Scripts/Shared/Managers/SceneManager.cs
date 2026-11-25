using System.ComponentModel;
using UniFoundation.Scripts.Shared.Managers;

namespace UniFoundation.Scripts.Shared
{
    public class SceneManager : ManagerBase<SceneManager>
    {
        public UnityEngine.AsyncOperation LoadSceneAsync(string sceneName)
        {
            UnityEngine.AsyncOperation rst = UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(sceneName);
            return rst;
        }

        public UnityEngine.AsyncOperation UnloadSceneAsync(string sceneName)
        {
            UnityEngine.AsyncOperation rst = UnityEngine.SceneManagement.SceneManager.UnloadSceneAsync(sceneName);
            return rst;
        }
    }
}