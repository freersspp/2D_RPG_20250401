using UnityEngine;
namespace PPman
{
    /// <summary>
    /// 玩家待機
    /// </summary>

    public class Player_idle : State
    {
        public Player_idle(Player _player, StateMachine _stateMachine, string _name) : base(_player, _stateMachine, _name)
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
            //當玩家的水平加速度(h)不等於0時, 切換到走路狀態
            if(h != 0)
            {
                statemachine.Switchstate(player.player_walk);
            }
        }
    }

}