using UnityEngine;
namespace PPman
{
    /// <summary>
    /// 玩家跳躍
    /// </summary>

    public class Player_jump : State
    {
        public Player_jump(Player _player, StateMachine _stateMachine, string _name) : base(_player, _stateMachine, _name)
        {
        }

        public override void Enter()
        {
            base.Enter();
            player.Setvelocity(new Vector2(player.Rig.velocity.x, player.Jumpforce));
            player.Ani.SetBool("是否在地板上", false);
            player.Ani.SetFloat("跳躍", 1);

        }

        public override void Exit()
        {
            base.Exit();
        }

        public override void Update()
        {
            base.Update();

           if(player.Rig.velocity.y < 0)
            {
                statemachine.Switchstate(player.player_fall);
            }
            

        }
    }

}