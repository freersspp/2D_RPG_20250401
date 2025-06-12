using UnityEngine;
namespace PPman
{
    /// <summary>
    /// 玩家攻擊
    /// </summary>

    public class Player_attack : PlayerState
    {
        public Player_attack(Player _player, StateMachine _stateMachine, string _name) : base(_player, _stateMachine, _name)
        {


        }
        /// <summary>
        /// 攻擊段數
        /// </summary>
        private int 攻擊段數;
        /// <summary>
        /// 最大攻擊段數
        /// </summary>
        private float 最大攻擊段數 = 4;
        private float 攻擊結束時間;
        public override void Enter()
        {
            base.Enter();
            //如果一段時間沒攻擊, 恢復到第一段攻擊
            if(Time.time > 攻擊結束時間+ player.攻擊間段時間)
            {
                攻擊段數 = 0;
            }

            //攻擊段數增加
            攻擊段數++;
            //當前攻擊段數超過最大段數時恢復到1
            if (攻擊段數 > 最大攻擊段數)
            {
                攻擊段數 = 1;
            }
            player.Ani.SetFloat("攻擊段數", 攻擊段數);
            player.Ani.SetTrigger("觸發攻擊");
                 
                        
        }

        public override void Exit()
        {
            base.Exit();
            
            //紀錄攻擊結束時間
            攻擊結束時間 = Time.time;
            //Debug.Log($"<color=red>攻擊結束時間:{ 攻擊結束時間}</color>");

        }

        public override void Update()
        {
            base.Update();
            //Debug.Log($"<color=blue>計時器 : {Timer}</color>");

            //限制攻擊完不會播移動動畫
            player.Ani.SetFloat("移動", 0);
            //利用計時器讓腳色離開攻擊狀態(時間設定0.7秒)
            if(Timer >= player.攻擊動畫時間[攻擊段數 - 1])
            {
                statemachine.Switchstate(player.player_idle);
            }
        }
    }

}