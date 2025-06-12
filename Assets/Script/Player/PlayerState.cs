using UnityEngine;
namespace PPman
{
    public class PlayerState : State
    {
        protected Player player;

        //建構子:實力化時會被呼叫, 名稱與類別相同
        public PlayerState(Player _player, StateMachine _stateMachine, string _name)
        {
            player = _player;
            statemachine = _stateMachine;
            name = _name;
        }

    }
}
