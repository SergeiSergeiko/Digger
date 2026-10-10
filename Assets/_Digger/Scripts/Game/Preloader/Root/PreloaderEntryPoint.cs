using UnityEngine;

namespace Assets._Digger.Scripts.Game.Preloader.Root
{
    public class PreloaderEntryPoint : MonoBehaviour
    {
        [SerializeField] private LoadingScreen _loadingScreen;

        public void Run(AsyncOperation loadingScene)
        {
            StartCoroutine(_loadingScreen.Run(loadingScene));
        }
    }
}