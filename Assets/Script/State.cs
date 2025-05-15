using UnityEngine;

namespace PPman
{
    /// <summary>
    /// 狀態: 包含進入狀態, 更新狀態, 離開狀態
    /// </summary>
    public class State
    {
        private string name;
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