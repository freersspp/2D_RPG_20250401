using UnityEngine;
namespace PPman
{
    /// <summary>
    /// 玩家墜落
    /// </summary>

    public class Player_fall : PlayerState
    {
        public Player_fall(Player _player, StateMachine _stateMachine, string _name) : base(_player, _stateMachine, _name)
        {
        }

        public override void Enter()
        {
            base.Enter();
            player.Ani.SetFloat("跳躍", -1);
        }

        public override void Exit()
        {
            base.Exit();
            player.Ani.SetBool("是否在地板上", true);
            SoundManager.Instance.PlaySound(SoundType.PlayerFall, 0.6f, 1.3f);
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

            if (player.Isgrounded())
            {
                statemachine.Switchstate(player.player_idle);
            }
        }
    }

}
