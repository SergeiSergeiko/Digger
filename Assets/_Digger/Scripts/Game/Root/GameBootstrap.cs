using _Digger.Scripts.Game.Gameplay.Root;
using Assets._Digger.Scripts.Game.FSM;
using Assets._Digger.Scripts.Game.MainMenu.Root;
using Assets._Digger.Scripts.Game.Root;
using Assets._Digger.Scripts.Game.Root.DI;
using Assets._Digger.Scripts.Game.Root.States;
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
        private StateMachine<GameBootStrap> _fsm;

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        public static void AutoStartGame()
        {
            _instance = new GameBootStrap();
            _instance.RunGame();
        }

        private GameBootStrap()
        {
            _sceneLoader = new SceneLoader();
            _diContainer = new DIContainer();
            _coroutines = new GameObject("[COROUTINES]").AddComponent<Coroutines>();
            Object.DontDestroyOnLoad(_coroutines.gameObject);

            InitStateMachine();
        }

        private void RunGame()
        {
            TargetScene.NAME = Scenes.MAINMENU;
            _fsm.SetState(Scenes.PRELOADER);
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

        private void InitStateMachine()
        {
            _fsm = new StateMachine<GameBootStrap>();
            var preloaderState = new PreloaderState(_fsm, _coroutines);
            var mainMenuState = new MainMenuState(_fsm);
            var gameplayState = new GameplayState(_fsm);

            _fsm.AddState(Scenes.PRELOADER, preloaderState);
            _fsm.AddState(Scenes.MAINMENU, mainMenuState); 
            _fsm.AddState(Scenes.GAMEPLAY, gameplayState);
        }
    }
}