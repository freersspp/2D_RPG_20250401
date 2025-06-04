using UnityEngine;
namespace PPman
{
    /// <summary>
    /// 玩家:儲存玩家資料與基本功能
    /// </summary>
    public class Player : MonoBehaviour
    {
        //開頭加field:後, 尾巴加{ get; private set; }可以重新設定唯獨模式
        #region 變數
        [field: Header("基本資料")]
        [field: SerializeField, Range(0, 50)] public float moveSpeed { get; private set; } = 8.0f;
        [field: SerializeField, Range(0, 50)] public float Jumpforce { get; private set; } = 8.0f;
        [field: SerializeField, Range(0, 3)] public float 攻擊間段時間 { get; private set; } = 1;
        [field: SerializeField] public float[] 攻擊動畫時間 { get; private set; }


        //利用字尾{ get; private set; }讓該參數外部可以讀取但是無法修改(保護資料,僅限讀取)
        public Animator Ani { get; private set; }
        public Rigidbody2D Rig { get; private set; }

        [Header("檢查地板資料")]
        [SerializeField] private Vector3 CheckGroundSize = Vector3.one;
        [SerializeField] private Vector3 CheckGroundoffset;
        [SerializeField] private LayerMask Layercanjump;
        #endregion

        #region 狀態資料
        public StateMachine statemachine;
        public Player_idle player_idle { get; private set; }
        public Player_walk player_walk { get; private set; }
        public Player_jump player_jump { get; private set; }
        public Player_fall player_fall { get; private set; }
        public Player_attack player_attack { get; private set; }
        public Player_crouch Player_crouch { get; private set; }
        #endregion

        //用程式自動在腳色底下繪製一個地板偵測器
        private void OnDrawGizmos()
        {
            Gizmos.color = new Color(0.5f, 0.5f, 0.5f, 0.9f);
            Gizmos.DrawCube(transform.position + CheckGroundoffset, CheckGroundSize);
        }

        private void Awake()
        {
            Ani = GetComponent<Animator>();
            Rig = GetComponent<Rigidbody2D>();

            statemachine = new StateMachine();
            //this 為"類別",將Player帶入自己狀態
            player_idle = new Player_idle(this, statemachine, "待機");
            player_walk = new Player_walk(this, statemachine, "行走");
            player_jump = new Player_jump(this, statemachine, "跳躍");
            player_fall = new Player_fall(this, statemachine, "掉落");
            player_attack = new Player_attack(this, statemachine, "攻擊");
            Player_crouch = new Player_crouch(this, statemachine, "蹲下");

            //狀態機 指定"預設狀態"為"待機"
            statemachine.Defaultstate(player_idle);

        }
        private void Update()
        {
            //狀態機開始持續更新
            statemachine.Updatestate();

        }

        /// <summary>
        /// 設定水平加速度
        /// </summary>
        /// <param name="velocity">水平加速度</param>
        public void Setvelocity(Vector3 velocity)
        {
            Rig.velocity = velocity;
        }
        /// <summary>
        /// 設定腳色角度
        /// </summary>
        /// <param name="h">腳色角度</param>
        public void Flip(float h)
        {
            //如果h值 < 0.1就跳出迴圈
            if (Mathf.Abs(h) < 0.1)
            {
                return;
            }
            //讓2D腳色顯示面向前面還是後面
            //設定angle 角度判斷角度(h) 改變腳色面對方向(Y軸數值)
            float angle = h > 0 ? 0 : 180;
            transform.eulerAngles = new Vector3(0, angle, 0);
        }

        public bool Isgrounded()
        {
            return Physics2D.OverlapBox(transform.position + CheckGroundoffset, CheckGroundSize, 0, Layercanjump);
        }


    }


}

