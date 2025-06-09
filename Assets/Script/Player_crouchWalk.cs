using UnityEngine;
namespace PPman
{
    public class Player_crouchWalk : PlayGround
    {
        public Player_crouchWalk(Player _player, StateMachine _stateMachine, string _name) : base(_player, _stateMachine, _name)
        {
        }

        public override void Enter()
        {
            base.Enter();

            player.Ani.SetFloat("蹲下移動", 0);
            player.Ani.SetTrigger("觸發蹲下");


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
            player.Ani.SetFloat("蹲下移動", Mathf.Abs(h));
            //腳色角度 
            player.Flip(h);
        }
    }



























}