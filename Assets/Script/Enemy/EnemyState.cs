using UnityEngine;
namespace PPman
{

    public class EnemyState : State
    {
        protected Enemy enemy;

        public EnemyState(Enemy _enemy, StateMachine _stateMachine, string _name)
        {
            enemy = _enemy;
            statemachine = _stateMachine;
            name = _name;

        }

        public override void Enter()
        {
            base.Enter();
            Debug.Log($"<color=red>進入:{name}</color>");
        }

        public override void Exit()
        {
            base.Exit();
        }

        public override void Update()
        {
            base.Update();
            
        }
    }
}