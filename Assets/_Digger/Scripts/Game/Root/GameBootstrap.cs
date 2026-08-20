using _Digger.Scripts.Game.Gameplay.Root;
using Assets._Digger.Scripts.Game.MainMenu.Root;
using Assets._Digger.Scripts.Game.Preloader.Root;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace _Digger.Scripts
{
    public class GameBootStrap
    {
        private static GameBootStrap _instance;
        private Coroutines _coroutines;

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        public static void AutoStartGame()
        {
            _instance = new GameBootStrap();
            _instance.RunGame();
        }

        private GameBootStrap()
        {
            _coroutines = new GameObject("[COROUTINES]").AddComponent<Coroutines>();
            Object.DontDestroyOnLoad(_coroutines.gameObject);
        }

        private void RunGame()
        {
            _coroutines.StartCoroutine(LoadAndStartMainMenu());
        }

        private IEnumerator LoadAndStartGameplay()
        {
            PreloaderEntryPoint preloaderEntryPoint = null;
            AsyncOperation loadingGameplayScene;

            yield return SceneManager.LoadSceneAsync(Scenes.Preloader, LoadSceneMode.Additive);

            var preloaderScene = SceneManager.GetSceneByName(Scenes.Preloader);
            var preloaderRootGameObjects = preloaderScene.GetRootGameObjects();
            foreach (var gameObject in preloaderRootGameObjects)
                if (gameObject.TryGetComponent<PreloaderEntryPoint>(out preloaderEntryPoint)) { }
            if (preloaderEntryPoint == null)
                Debug.LogError($"{preloaderEntryPoint.name} is null");

            loadingGameplayScene = SceneManager.LoadSceneAsync(Scenes.GAMEPLAY);
            preloaderEntryPoint.SimulationRun(loadingGameplayScene, 3f);
            yield return loadingGameplayScene;
            yield return null;

            var gameplayEntryPoint = Object.FindAnyObjectByType<GameplayEntryPoint>();

            gameplayEntryPoint.Run();
            gameplayEntryPoint.GoToMainMenuButtonClicked += () =>
            {
                _coroutines.StartCoroutine(LoadAndStartMainMenu());
            };
        }

        private IEnumerator LoadAndStartMainMenu()
        {
            MainMenuEntryPoint mainMenuEntryPoint = null;
            PreloaderEntryPoint preloaderEntryPoint = null;
            AsyncOperation loadingMainMenuScene;

            yield return SceneManager.LoadSceneAsync(Scenes.Preloader, LoadSceneMode.Additive);

            var preloaderScene = SceneManager.GetSceneByName(Scenes.Preloader);
            var preloaderRootGameObjects = preloaderScene.GetRootGameObjects();
            foreach (var gameObject in preloaderRootGameObjects)
                if (gameObject.TryGetComponent<PreloaderEntryPoint>(out preloaderEntryPoint)) { }
            if (preloaderEntryPoint == null)
                Debug.LogError("preloaderEntryPoint is null");

            loadingMainMenuScene = SceneManager.LoadSceneAsync(Scenes.MAINMENU, LoadSceneMode.Additive);
            preloaderEntryPoint.SimulationRun(loadingMainMenuScene, 3f);
            yield return loadingMainMenuScene;
            yield return SceneManager.UnloadSceneAsync(Scenes.Preloader);
            yield return null;

            var mainMenuScene = SceneManager.GetSceneByName(Scenes.MAINMENU);
            var mainMenuRootGameObjects = mainMenuScene.GetRootGameObjects();
            foreach (var gameObject in mainMenuRootGameObjects)
                if (gameObject.TryGetComponent<MainMenuEntryPoint>(out mainMenuEntryPoint)) { }
            if (mainMenuEntryPoint == null)
                Debug.LogError("mainMenuEntryPoint is null");

            mainMenuEntryPoint.Run();
            mainMenuEntryPoint.GoToGameplayButtonClicked += () =>
            {
                _coroutines.StartCoroutine(LoadAndStartGameplay());
            };
        }
    }
}