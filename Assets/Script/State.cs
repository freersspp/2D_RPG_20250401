using UnityEngine;

namespace PPman
{
    /// <summary>
    /// 狀態: 包含進入狀態, 更新狀態, 離開狀態
    /// </summary>
    /// 

    public class State
    {
        private string name;
        //protected 為限定存取：只有子屬關係才可以存取
        protected Player player;
        protected StateMachine statemachine;
        protected float h;
        protected float Timer;

        //建構子:實力化時會被呼叫, 名稱與類別相同
        public State(Player _player,StateMachine _stateMachine, string _name)
        {
            player = _player;
            statemachine = _stateMachine;
            name = _name;   
        }
        //virtual 虛擬:允許子類別覆寫(override)
        public virtual void Enter()
        {
            Debug.Log($"<color=green>進入:{name}</color>");
            //計時器歸零
            Timer = 0f;
        }

        public virtual void Update()
        {
            //Debug.Log($"<color=orange>更新:{name}</color>");
            h = Input.GetAxis("Horizontal");
            Timer += Time.deltaTime;
        }

        public virtual void Exit()
        {
            //Debug.Log($"<color=blue>離開:{name}</color>");
        }

    }
}