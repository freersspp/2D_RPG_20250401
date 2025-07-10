using UnityEngine;
namespace PPman
{

    public class EnemyWalk : EnemyState
    {
        private float walktime;
        public EnemyWalk(Enemy _enemy, StateMachine _stateMachine, string _name) : base(_enemy, _stateMachine, _name)
        {

        }

        public override void Enter()
        {
            base.Enter();
            walktime = Random.Range(enemy.walktime.x, enemy.walktime.y);
            //Debug.Log($"遊蕩時間 : {walktime}");
            enemy.Ani.SetFloat("移動", 1);
        }

        public override void Exit()
        {
            base.Exit();
        }

        public override void Update()
        {
            base.Update();
            enemy.Setvelocity(enemy.transform.right * enemy.walkspeed);
            
            //如果確認前方有牆壁 或是 前方沒有地板了 就翻面
            if(enemy.IsWallFront() || !enemy.IsGroundFront())
            {
                enemy.Flip(enemy.transform.eulerAngles.y == 0 ? -1 : +1 );
            }
            //如果計時器時間到會切換回"idle"模式
            if(Timer >= walktime)
            {
                statemachine.Switchstate(enemy.enemyIdle);
            }

            //如果確認前方有玩家就進入追蹤狀態
            if (enemy.IsPlayerFront())
            {
                statemachine.Switchstate(enemy.enemyFollow);
            }

        }
    }
}