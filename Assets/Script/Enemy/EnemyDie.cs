using UnityEngine;
namespace PPman
{

    public class EnemyDie : EnemyState
    {
        public EnemyDie(Enemy _enemy, StateMachine _stateMachine, string _name) : base(_enemy, _stateMachine, _name)
        {

        }

        public override void Enter()
        {
            base.Enter();
            enemy.Ani.SetTrigger("觸發死亡");
            enemy.Setvelocity(Vector3.zero);
            //如果隨機值 小於等於 掉落機率 就生成掉落物
            if(Random.value <= enemy.dropProbability)
            {
                enemy.spawnDrop();
            }

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