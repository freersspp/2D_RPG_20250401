using UnityEngine;
namespace PPman
{
    /// <summary>
    /// NPC���A
    /// </summary>
    public class NPCState : State
    {
        protected NPC npc;
        //�غc�l:��O�Ʈɷ|�Q�I�s, �W�ٻP���O�ۦP
        public NPCState(NPC _NPC, StateMachine _stateMachine, string _name)
        {
            npc = _NPC;
            statemachine = _stateMachine;
            name = _name;
        }
    }
}