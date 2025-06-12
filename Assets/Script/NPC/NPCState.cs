using UnityEngine;
namespace PPman
{
    /// <summary>
    /// NPC狀態
    /// </summary>
    public class NPCState : State
    {
        protected NPC npc;
        //建構子:實力化時會被呼叫, 名稱與類別相同
        public NPCState(NPC _NPC, StateMachine _stateMachine, string _name)
        {
            npc = _NPC;
            statemachine = _stateMachine;
            name = _name;
        }
    }
}