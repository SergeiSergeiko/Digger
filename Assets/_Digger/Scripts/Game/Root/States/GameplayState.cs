using _Digger.Scripts;
using _Digger.Scripts.Game.Gameplay.Root;
using Assets._Digger.Scripts.Game.FSM;
using UnityEngine;

namespace Assets._Digger.Scripts.Game.Root.States
{
    public class GameplayState : State
    {
        private StateMachine<GameBootStrap> _fsm;

        public GameplayState(StateMachine<GameBootStrap> fsm)
        {
            _fsm = fsm;
        }

        public override void Enter()
        {
            var gameplayEntryPoint = Object.FindAnyObjectByType<GameplayEntryPoint>();

            if (gameplayEntryPoint == null)
                Debug.LogError("gameplayEntryPoint is null");

            gameplayEntryPoint.Run();
            void handler()
            {
                TargetScene.NAME = Scenes.MAINMENU;
                _fsm.SetState(Scenes.PRELOADER);
                gameplayEntryPoint.GoToMainMenuButtonClicked -= handler;
            }
            gameplayEntryPoint.GoToMainMenuButtonClicked += handler;
        }

        public override void Exit() { }

        public override void Update() { }
    }
}