using UnityEngine;

namespace PPman
{
    /// <summary>
    /// 狀態: 包含進入狀態, 更新狀態, 離開狀態
    /// </summary>
    public class State
    {
        private string name;
        //protected 為限定存取：只有子屬關係才可以存取
        protected Player player;
        protected StateMachine statemachine;
        public void Enter()
        {
            Debug.Log($"<color=green>進入:{name}</color>");
        }

        public void Update()
        {
            Debug.Log($"<color=orange>更新:{name}</color>");
        }

        public void Exit()
        {
            Debug.Log($"<color=blue>離開:{name}</color>");
        }

    }
}