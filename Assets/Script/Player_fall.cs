using UnityEngine;
namespace PPman
{
    /// <summary>
    /// 玩家墜落
    /// </summary>

    public class Player_fall : State
    {
        public Player_fall(Player _player, StateMachine _stateMachine, string _name) : base(_player, _stateMachine, _name)
        {
        }
    }

}
