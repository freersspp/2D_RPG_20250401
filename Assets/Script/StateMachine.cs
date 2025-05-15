using UnityEngine;

namespace PPman
{
    /// <summary>
    /// 狀態機:預設狀態和狀態切換管理
    /// </summary>
    public class StateMachine
    {
        //宣告CurrentState為新狀態更新State
        private State CurrentState;

        /// <summary>
        /// 指定預設狀態
        /// </summary>
        /// <param name="defaultstate">要指定的預設狀態</param>
        public void Defaultstate(State defaultstate)
        {
            //當前狀態 指定為 預設狀態
            CurrentState = defaultstate;
            //進入 當前狀態
            CurrentState.Enter();
        }

        /// <summary>
        /// 更新狀態
        /// </summary>
        public void Updatestate()
        {
            //更新 當前狀態
            CurrentState.Update();
        }

        /// <summary>
        /// 切換狀態
        /// </summary>
        /// <param name="NewState">要切換狀態</param>
        public void Switchstate(State NewState)
        {
            //離開 當前狀態
            CurrentState.Exit();
            //當前狀態 指定為 新狀態
            CurrentState = NewState;
            //進入 當前狀態
            CurrentState.Enter();

        }
    }
}