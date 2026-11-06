using Assets._Digger.Scripts.Game.FSM;
using Assets._Digger.Scripts.Game.Root;
using Assets._Digger.Scripts.Game.Root.States;
using UnityEngine;

namespace _Digger.Scripts
{
    public class GameBootStrap
    {
        private static GameBootStrap _instance;
        private Coroutines _coroutines;
        private SceneLoader _sceneLoader;
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
            _coroutines = new GameObject("[COROUTINES]").AddComponent<Coroutines>();
            Object.DontDestroyOnLoad(_coroutines.gameObject);

            InitStateMachine();
        }

        private void RunGame()
        {
            TargetScene.NAME = Scenes.MAINMENU;
            _fsm.SetState(Scenes.PRELOADER);
        }

        private void InitStateMachine()
        {
            _fsm = new StateMachine<GameBootStrap>();
            var preloaderState = new PreloaderState(_fsm, _sceneLoader, _coroutines);
            var mainMenuState = new MainMenuState(_fsm);
            var gameplayState = new GameplayState(_fsm);

            _fsm.AddState(Scenes.PRELOADER, preloaderState);
            _fsm.AddState(Scenes.MAINMENU, mainMenuState); 
            _fsm.AddState(Scenes.GAMEPLAY, gameplayState);
        }
    }
}