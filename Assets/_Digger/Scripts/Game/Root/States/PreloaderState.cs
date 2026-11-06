using _Digger.Scripts;
using Assets._Digger.Scripts.Game.FSM;
using System.Collections;

namespace Assets._Digger.Scripts.Game.Root.States
{
    public class PreloaderState : State
    {
        private Coroutines _coroutines;
        private StateMachine<GameBootStrap> _fsm;
        private SceneLoader _sceneLoader;

        public PreloaderState(StateMachine<GameBootStrap> fsm, SceneLoader sceneLoader, Coroutines coroutines)
        {
            _fsm = fsm;
            _sceneLoader = sceneLoader;
            _coroutines = coroutines;
        }

        public override void Enter()
        {
            _coroutines.StartCoroutine(LoadSceneAsync());
        }

        public override void Update() { }

        public override void Exit() { }

        public IEnumerator LoadSceneAsync()
        {
            yield return _sceneLoader.LoadSceneAsync(TargetScene.NAME);

            _fsm.SetState(TargetScene.NAME);
        }
    }
}
