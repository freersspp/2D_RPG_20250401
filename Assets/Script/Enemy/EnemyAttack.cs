using UnityEngine;
namespace PPman
{

    public class EnemyAttack : EnemyState
    {
        public EnemyAttack(Enemy _enemy, StateMachine _stateMachine, string _name) : base(_enemy, _stateMachine, _name)
        {

        }

        public override void Enter()
        {
            base.Enter();
            enemy.Ani.SetTrigger("觸發攻擊");
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