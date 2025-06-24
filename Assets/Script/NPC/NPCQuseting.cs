using UnityEngine;
namespace PPman
{

    public class NPCQuseting : NPCState
    {
        public NPCQuseting(NPC _NPC, StateMachine _stateMachine, string _name) : base(_NPC, _stateMachine, _name)
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
            if(npc.playerinarea && Input.GetKeyDown(KeyCode.F))
            {
                npc.flowchart.SendFungusMessage("任務中");
            }
        }
    }
}
