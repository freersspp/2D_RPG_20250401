using UnityEngine;
namespace PPman
{
    //enum 列舉：下拉選單(預設為單選)
    //快速完成：enum + Tab 兩下
    /// <summary>
    /// 敵人_受傷
    /// 敵人_攻擊
    /// 敵人_死亡
    /// 玩家_受傷
    /// 玩家_攻擊1
    /// 玩家_攻擊2
    /// 玩家_攻擊3
    /// 玩家_死亡
    /// 玩家_落地
    /// 玩家_走路
    /// 玩家_跳躍
    /// 道具_掉落
    /// 道具_獲得
    /// </summary>
    public enum SoundType
    {
        EnemyHurt, EnemyAtt, EnemyDead, PlayerHurt, PlayerAtt1, PlayerAtt2, PlayerAtt3,
        PlayerDead, PlayerFall, PlayerWalk, PlayerJump, ItemDrop, ItemGet
    }

    
}