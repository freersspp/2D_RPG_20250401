using UnityEngine;
namespace PPman
{

    public class EnemyIdle : EnemyState
    {
        private float idletime;
        public EnemyIdle(Enemy _enemy, StateMachine _stateMachine, string _name) : base(_enemy, _stateMachine, _name)
        {

        }

        public override void Enter()
        {
            base.Enter();
            idletime = Random.Range(enemy.idletime.x, enemy.idletime.y);
            enemy.Ani.SetFloat("移動", 0);
            enemy.Setvelocity(Vector3.zero);
            //Debug.Log($"待機時間 : {idletime}");
        }

        public override void Exit()
        {
            base.Exit();
        }

        public override void Update()
        {
            base.Update();

            //如果計時器時間到的話自動切換到"敵人遊走"狀態
            if (Timer >= idletime)
            {
                statemachine.Switchstate(enemy.enemyWalk);
            }
            //如果 前方有牆壁 或是 前方沒地板 就跳出
            if(enemy.IsWallFront() || !enemy.IsGroundFront())
            {
                return;
            }

            //如果確認前方有玩家就進入追蹤狀態
            if (enemy.IsPlayerFront())
            {
                statemachine.Switchstate(enemy.enemyFollow);
            }
        }
    }
}