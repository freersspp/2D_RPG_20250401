using UnityEngine;
namespace PPman
{
    /// <summary>
    /// 玩家墜落
    /// </summary>

    public class Player_fall : State
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
        }

        public override void Update()
        {
            base.Update();
            if (player.Isgrounded())
            {
                statemachine.Switchstate(player.player_idle);
            }
        }
    }

}
