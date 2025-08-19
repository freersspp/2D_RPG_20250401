using UnityEngine;
namespace PPman
{
    /// <summary>
    /// 玩家資料：存讀檔需要的相關資料
    /// 玩家座標, 血量, 任務道具獲得數量
    /// </summary>


    //系統的序列化:允許類別顯示在面板上
    [System.Serializable]
    public class PlayerData 
    {
        public Vector3 Position;
        public Vector3 Rotation;
        public float hpmax;
        public float hp;
        public int MissionCount;
    }
}