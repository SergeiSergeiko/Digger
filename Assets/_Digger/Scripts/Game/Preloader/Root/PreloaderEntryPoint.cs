using UnityEngine;

namespace Assets._Digger.Scripts.Game.Preloader.Root
{
    public class PreloaderEntryPoint : MonoBehaviour
    {
        [SerializeField] private LoadingScreen _loadingScreen;

        public void Run(AsyncOperation loadingScene)
        {
            _loadingScreen.Run(loadingScene);
        }

#if UNITY_EDITOR
        public void SimulationRun(AsyncOperation loadingScene, float loadingTime)
        {
            _loadingScreen.Run(loadingScene, loadingTime);
        }
#endif
    }
}