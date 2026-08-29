using _Digger.Scripts;
using Assets._Digger.Scripts.Game.Preloader.Root;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets._Digger.Scripts.Game.Root
{
    public class SceneLoader
    {
        public IEnumerator LoadSceneAsync(string name)
        {
            AsyncOperation loadingScene;

            Scene currentScene = SceneManager.GetActiveScene();
            yield return SceneManager.LoadSceneAsync(Scenes.Preloader, LoadSceneMode.Additive);
            SceneManager.UnloadSceneAsync(currentScene);

            var preloaderEntryPoint = Object.FindAnyObjectByType<PreloaderEntryPoint>();

            if (preloaderEntryPoint == null)
                Debug.LogError("preloaderEntryPoint is null");

            loadingScene = SceneManager.LoadSceneAsync(name, LoadSceneMode.Additive);
            preloaderEntryPoint.SimulationRun(loadingScene, 3f);
            yield return loadingScene;
            yield return SceneManager.UnloadSceneAsync(Scenes.Preloader);
        }
    }
}