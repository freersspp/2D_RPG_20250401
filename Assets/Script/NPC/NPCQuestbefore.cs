using UnityEngine;
namespace PPman
{

    public class NPCQuestbefore : NPCState
    {
        public NPCQuestbefore(NPC _NPC, StateMachine _stateMachine, string _name) : base(_NPC, _stateMachine, _name)
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

            //如果玩家在範圍內 並且 按下"F"鍵就傳訊息給NPC對話系統
            if(npc.playerinarea && Input.GetKeyDown(KeyCode.F))
            {
                npc.flowchart.SendFungusMessage("任務前");
            }
            if( Timer > 1)
            {
                statemachine.Switchstate(npc.npcQuseting);
            }
        }
    }
}

