using UnityEngine;
namespace PPman
{
    /// <summary>
    /// 玩家待機
    /// </summary>

    public class Player_idle : PlayGround
    {
        public Player_idle(Player _player, StateMachine _stateMachine, string _name) : base(_player, _stateMachine, _name)
        {

        }

        public override void Enter()
        {
            base.Enter();
            player.Ani.SetBool("是否在地板上", true);
            player.Ani.SetFloat("蹲下移動", 0);
            player.Ani.SetFloat("移動", 0);
            player.GetComponent<CapsuleCollider2D>().size = new Vector2(0.75f,2.3f);
            player.GetComponent<CapsuleCollider2D>().offset = new Vector2(0f, 0f);
            //player.Rig.constraints = UnityEngine.RigidbodyConstraints2D.FreezeAll;

        }

        public override void Exit()
        {
            base.Exit();
            player.Rig.constraints = UnityEngine.RigidbodyConstraints2D.FreezeRotation;
        }

        public override void Update()
        {
            base.Update();
            //當玩家的水平加速度(h)不等於0時, 切換到走路狀態
            if(h != 0 && player.canmove)
            {
                statemachine.Switchstate(player.player_walk);
            }
        }
    }

}