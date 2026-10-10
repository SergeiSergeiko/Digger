using _Digger.Scripts.Game.Gameplay.Root;
using Assets._Digger.Scripts.Game.MainMenu.Root;
using Assets._Digger.Scripts.Game.Root;
using Assets._Digger.Scripts.Game.Root.DI;
using System.Collections;
using UnityEngine;

namespace _Digger.Scripts
{
    public class GameBootStrap
    {
        private static GameBootStrap _instance;
        private Coroutines _coroutines;
        private SceneLoader _sceneLoader;
        private DIContainer _diContainer;

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        public static void AutoStartGame()
        {
            _instance = new GameBootStrap();
            _instance.RunGame();
        }

        private GameBootStrap()
        {
            _diContainer = new DIContainer();
            _sceneLoader = new SceneLoader();
            _coroutines = new GameObject("[COROUTINES]").AddComponent<Coroutines>();
            Object.DontDestroyOnLoad(_coroutines.gameObject);
        }

        private void RunGame()
        {
            _coroutines.StartCoroutine(LoadAndStartMainMenu());
        }

        private IEnumerator LoadAndStartGameplay()
        {
            yield return _coroutines.StartCoroutine(_sceneLoader.LoadSceneAsync(Scenes.GAMEPLAY));

            var gameplayEntryPoint = Object.FindAnyObjectByType<GameplayEntryPoint>();

            if (gameplayEntryPoint == null)
                Debug.LogError("gameplayEntryPoint is null");

            gameplayEntryPoint.Run();
            void handler()
            {
                _coroutines.StartCoroutine(LoadAndStartMainMenu());
                gameplayEntryPoint.GoToMainMenuButtonClicked -= handler;
            }
            gameplayEntryPoint.GoToMainMenuButtonClicked += handler;
        }

        private IEnumerator LoadAndStartMainMenu()
        {

            yield return _coroutines.StartCoroutine(_sceneLoader.LoadSceneAsync(Scenes.MAINMENU));

            var mainMenuEntryPoint = Object.FindAnyObjectByType<MainMenuEntryPoint>();

            if (mainMenuEntryPoint == null)
                Debug.LogError("mainMenuEntryPoint is null");

            mainMenuEntryPoint.Run();
            void handler()
            {
                _coroutines.StartCoroutine(LoadAndStartGameplay());
                mainMenuEntryPoint.GoToGameplayButtonClicked -= handler;
            }
            mainMenuEntryPoint.GoToGameplayButtonClicked += handler;
        }
    }
}