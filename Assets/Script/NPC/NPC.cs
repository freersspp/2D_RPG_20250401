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
        public bool playerinarea { get; private set; }
        [SerializeField] private Vector3 offsetinteraction;
        private CanvasGroup groupInteraction;
        private WorktoUIpoint uiInteraction;
        public bool isTalkbefore { get; set; }

        public int 已取得任務道具數量 { get; protected set; }
        public int 任務道具需求數量 { get; set; } = 5;
        protected virtual void Awake()
        {
            flowchart = GetComponent<Flowchart>();
            groupInteraction = GameObject.Find("群組_互動介面").GetComponent<CanvasGroup>();
            uiInteraction = GameObject.Find("群組_互動介面").GetComponent<WorktoUIpoint>();
            stateMachine = new StateMachine();
            npcQuestbefore = new NPCQuestbefore(this, stateMachine, "NPC任務進行前");
            npcQuseting = new NPCQuseting(this, stateMachine, "NPC任務進行中");
            npcQusetfinish = new NPCQusetfinish(this, stateMachine, "NPC任務完成");
            stateMachine.Defaultstate(npcQuestbefore);
        }
        protected virtual void Update()
        {
            stateMachine.Updatestate();
            if (playerinarea)
            {
                uiInteraction.UpdatePosition(transform, offsetinteraction);
            }
#if UNITY_EDITOR
            Test_任務道具數量增加();
#endif
        }



        private void OnTriggerEnter2D(Collider2D collision)
        {
            //如果碰到物件標籤為"玩家"就把狀態設定為"已進入"
            if (collision.CompareTag("Player"))
            {
                playerinarea = true;
                StopAllCoroutines();
                switchinteractionUI(playerinarea);

            }
        }
        //Exit 離開時執行一次
        private void OnTriggerExit2D(Collider2D collision)
        {
            //如果碰到物件標籤為"Player"就把狀態設定為"已出去"
            if (collision.CompareTag("Player"))
            {
                playerinarea = false;
                StopAllCoroutines();
                switchinteractionUI(playerinarea);
            }
        }
        public void switchinteractionUI(bool fadein)
        {
            StopAllCoroutines();
            StartCoroutine(Fadesystem.Fade(groupInteraction, fadein));
        }

        public void GetItem()
        {
            已取得任務道具數量++;
            Debug.Log($"{name} 道具增加: {已取得任務道具數量}");
        }

#if UNITY_EDITOR
        private void Test_任務道具數量增加()
        {
            if (Input.GetKeyDown(KeyCode.Keypad1))
            {
                已取得任務道具數量++;
                Debug.Log($"<color=green>道具數量:{已取得任務道具數量}</color>");
            }
        }
#endif
    }

}