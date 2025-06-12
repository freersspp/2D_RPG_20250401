using Fungus;
using UnityEngine;
namespace PPman
{
    public class NPC : MonoBehaviour
    {
        public StateMachine stateMachine;
        public NPCQuestbefore npcQuestbefore { get; private set; }
        public NPCQuseting npcQuseting { get; private set; }
        public NPCQusetfinish npcQusetfinish { get; private set; }
        public Flowchart flowchart { get; private set; }    
        private void Awake()
        {
            flowchart = GetComponent<Flowchart>();
            stateMachine = new StateMachine();
            npcQuestbefore = new NPCQuestbefore(this, stateMachine, "NPC任務進行前");
            npcQuseting = new NPCQuseting(this, stateMachine, "NPC任務進行中");
            npcQusetfinish = new NPCQusetfinish(this, stateMachine, "NPC任務完成");
            stateMachine.Defaultstate(npcQuestbefore);
        }
        private void Update()
        {
            stateMachine.Updatestate();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            Debug.Log(collision.name);
        }
    }
}