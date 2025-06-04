using UnityEngine;
namespace PPman
{
    public class Player_crouch : PlayGround
    {
        public Player_crouch(Player _player, StateMachine _stateMachine, string _name) : base(_player, _stateMachine, _name)
        {
        }

        public override void Enter()
        {
            base.Enter();
            player.Ani.SetBool("是否在地板上", false);
            player.Ani.SetTrigger("蹲下");
            
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