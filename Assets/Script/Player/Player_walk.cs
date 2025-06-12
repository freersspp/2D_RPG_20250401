using UnityEngine;
namespace PPman
{
    /// <summary>
    /// 玩家走路
    /// </summary>

    public class Player_walk : PlayGround
    {
        public Player_walk(Player _player, StateMachine _stateMachine, string _name) : base(_player, _stateMachine, _name)
        {
        }

        public override void Enter()
        {
            base.Enter();
        }

        public override void Exit()
        {
            base.Exit();
        }

        public override void Update()
        {
            base.Update();
            //設定玩家水平加速度
            player.Setvelocity(new Vector2(h * player.moveSpeed, player.Rig.velocity.y));
            //設定動畫
            player.Ani.SetFloat("移動", Mathf.Abs(h));
            //腳色角度
            player.Flip(h);
            //當玩家的水平加速度(h)等於0時,切換到idle狀態
            if(h ==0)
            {
                statemachine.Switchstate(player.player_idle);
            }
        }
    }

}
