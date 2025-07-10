using UnityEngine;
namespace PPman
{

    public class EnemyFollow : EnemyState
    {
        public EnemyFollow(Enemy _enemy, StateMachine _stateMachine, string _name) : base(_enemy, _stateMachine, _name)
        {

        }

        public override void Enter()
        {
            base.Enter();
            enemy.Ani.SetFloat("移動", 1);
        }

        public override void Exit()
        {
            base.Exit();
        }

        public override void Update()
        {
            base.Update();
            enemy.Setvelocity(enemy.transform.right * enemy.followspeed);

            //如果 前方有牆壁 或是 沒地板 就跳出
            if(enemy.IsWallFront() || !enemy.IsGroundFront())
            {
                statemachine.Switchstate(enemy.enemyIdle);
            }

            //根據玩家座標來決定跟隨方向
            float direction = enemy.player.position.x > enemy.transform.position.x ? 1 : -1;
            enemy.Flip(direction);

            //如果跟玩家距離小於攻擊距離時時, 切換到攻擊狀態
            if(Vector2.Distance(enemy.player.position, enemy.transform.position) <= enemy.attackdistance)
            {
                statemachine.Switchstate(enemy.enemyAttack);
                
            }
        }
    }
}