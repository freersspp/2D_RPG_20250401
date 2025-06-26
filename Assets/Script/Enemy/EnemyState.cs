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


    }
}