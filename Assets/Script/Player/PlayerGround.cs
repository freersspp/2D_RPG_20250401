using UnityEngine;

namespace PPman
{
    public class PlayGround : PlayerState
    {
        public PlayGround(Player _player, StateMachine _stateMachine, string _name) : base(_player, _stateMachine, _name)
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

            if (player.canjump && player.Isgrounded() && Input.GetKeyDown(KeyCode.Space) && player.CanStandUp())
            {
                statemachine.Switchstate(player.player_jump);
            }
            if (player.canattack && player.Isgrounded() && Input.GetKeyDown(KeyCode.Mouse0))
            {
                statemachine.Switchstate(player.player_attack);              
            }

            if (player.cancrouch && player.Isgrounded() && Input.GetKeyDown(KeyCode.S))
            {
                statemachine.Switchstate(player.Player_crouchwalk);
            }
            
        }
    }
}
