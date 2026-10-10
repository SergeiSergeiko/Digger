using Assets._Digger.Scripts.Game.Preloader.Root;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;

namespace Assets._Digger.Scripts.Game.Root
{
    public class SceneLoader
    {
        public IEnumerator LoadSceneAsync(string name)
        {
            yield return SceneManager.LoadSceneAsync(Scenes.Preloader, LoadSceneMode.Additive);
            SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene());

            var preloaderEntryPoint = Object.FindAnyObjectByType<PreloaderEntryPoint>();

            var loadingScene = SceneManager.LoadSceneAsync(name, LoadSceneMode.Additive);
            preloaderEntryPoint.Run(loadingScene);
            yield return loadingScene;
            yield return SceneManager.UnloadSceneAsync(Scenes.Preloader);
        }
    }
}