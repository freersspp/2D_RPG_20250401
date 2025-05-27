using UnityEngine;
namespace PPman
{
    /// <summary>
    /// 玩家攻擊
    /// </summary>

    public class Player_attack : State
    {
        public Player_attack(Player _player, StateMachine _stateMachine, string _name) : base(_player, _stateMachine, _name)
        {
        }
    }

}