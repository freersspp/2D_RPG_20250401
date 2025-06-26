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

            player.GetComponent<CapsuleCollider2D>().size = new Vector2(0.85f, 1.15f);
            player.GetComponent<CapsuleCollider2D>().offset = new Vector2(0f, -0.6f);
            player.Ani.SetFloat("蹲下移動", 0);
            player.Ani.SetBool("觸發蹲下", false);
        }

        public override void Exit()
        {
            base.Exit();
            player.Ani.SetBool("觸發蹲下", true);


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
            if (Input.GetKeyDown(KeyCode.W))
            {
                statemachine.Switchstate(player.player_idle);
            
            }

        }
    }



























}