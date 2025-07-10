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
            enemy.Ani.SetFloat("移動", 0);
            enemy.Rig.constraints = RigidbodyConstraints2D.FreezeAll;
        }

        public override void Exit()
        {
            base.Exit();
            enemy.Rig.constraints = RigidbodyConstraints2D.FreezeRotation;
        }

        public override void Update()
        {
            base.Update();

            


            //添加敵人攻擊後的冷卻時間
            if(Timer >= enemy.attacktime)
            {
                statemachine.Switchstate(enemy.enemyFollow);
            }
        }
    }
}