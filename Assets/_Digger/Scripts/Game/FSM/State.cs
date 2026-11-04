namespace Assets._Digger.Scripts.Game.FSM
{
    public abstract class State
    {
        public abstract void Enter();
        public abstract void Update();
        public abstract void Exit();
    }
}