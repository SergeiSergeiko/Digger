using _Digger.Scripts;
using Assets._Digger.Scripts.Game.FSM;
using Assets._Digger.Scripts.Game.Preloader.Root;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets._Digger.Scripts.Game.Root.States
{
    public class PreloaderState : State
    {
        private Coroutines _coroutines;
        private StateMachine<GameBootStrap> _fsm;

        public PreloaderState(StateMachine<GameBootStrap> fsm, Coroutines coroutines)
        {
            _fsm = fsm;
            _coroutines = coroutines;
        }

        public override void Enter()
        {
            _coroutines.StartCoroutine(LoadSceneAsync());
        }

        public override void Update() { }

        public override void Exit()
        {
            SceneManager.UnloadSceneAsync(Scenes.PRELOADER);
        }

        public IEnumerator LoadSceneAsync()
        {
            yield return SceneManager.LoadSceneAsync(Scenes.PRELOADER, LoadSceneMode.Additive);
            SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene());

            var preloaderEntryPoint = Object.FindAnyObjectByType<PreloaderEntryPoint>();

            var loadingScene = SceneManager.LoadSceneAsync(TargetScene.NAME, LoadSceneMode.Additive);
            preloaderEntryPoint.Run(loadingScene);
            yield return loadingScene;

            _fsm.SetState(TargetScene.NAME);
        }
    }
}
