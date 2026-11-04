using _Digger.Scripts;
using Assets._Digger.Scripts.Game.FSM;
using Assets._Digger.Scripts.Game.MainMenu.Root;
using UnityEngine;

namespace Assets._Digger.Scripts.Game.Root.States
{
    public class MainMenuState : State
    {
        private StateMachine<GameBootStrap> _fsm;

        public MainMenuState(StateMachine<GameBootStrap> fsm)
        {
            _fsm = fsm;
        }

        public override void Enter()
        {
            var mainMenuEntryPoint = Object.FindAnyObjectByType<MainMenuEntryPoint>();

            if (mainMenuEntryPoint == null)
                Debug.LogError("mainMenuEntryPoint is null");

            mainMenuEntryPoint.Run();
            void handler()
            {
                TargetScene.NAME = Scenes.GAMEPLAY;
                _fsm.SetState(Scenes.PRELOADER);
                mainMenuEntryPoint.GoToGameplayButtonClicked -= handler;
            }
            mainMenuEntryPoint.GoToGameplayButtonClicked += handler;
        }

        public override void Exit() { }

        public override void Update() { }
    }
}