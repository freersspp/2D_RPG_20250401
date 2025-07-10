using UnityEngine;
namespace PPman
{

    public class Player_die : PlayerState
    {
        public Player_die(Player _player, StateMachine _stateMachine, string _name) : base(_player, _stateMachine, _name)
        {
        }

        public override void Enter()
        {
            base.Enter();
            player.Ani.SetTrigger("觸發死亡");
            player.Setvelocity(Vector3.right * 0 + Vector3.up * player.Rig.velocity.y);
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