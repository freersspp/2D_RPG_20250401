using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace PPman
{
    /// <summary>
    /// 玩家:儲存玩家資料與基本功能
    /// </summary>
    public class Player : Character
    {
        //開頭加field:後, 尾巴加{ get; private set; }可以重新設定唯獨模式
        #region 變數
        [field: Header("基本資料")]
        [field: SerializeField, Range(0, 50)] public float moveSpeed { get; private set; } = 8.0f;
        [field: SerializeField, Range(0, 50)] public float Jumpforce { get; private set; } = 8.0f;
        [field: SerializeField, Range(0, 3)] public float 攻擊間段時間 { get; private set; } = 1;
        [field: SerializeField] public float[] 攻擊動畫時間 { get; private set; }




        public bool canmove { get; set; } = false;
        public bool canjump { get; set; } = false;
        public bool canattack { get; set; } = false;
        public bool cancrouch { get; set; } = false;

        [Header("檢查地板資料")]
        [SerializeField] private Vector3 CheckGroundSize = Vector3.one;
        [SerializeField] private Vector3 CheckGroundoffset;
        [SerializeField] private LayerMask Layercanjump;

        [Header("檢查頭頂資料")]
        [SerializeField] private Vector3 確認大小 = Vector3.one;
        [SerializeField] private Vector3 確認公差;
        [SerializeField] private LayerMask Layercanstandup;



        #endregion

        #region 狀態資料
        public StateMachine statemachine;
        public Player_idle player_idle { get; private set; }
        public Player_walk player_walk { get; private set; }
        public Player_jump player_jump { get; private set; }
        public Player_fall player_fall { get; private set; }
        public Player_attack player_attack { get; private set; }
        public Player_crouchWalk Player_crouchwalk { get; private set; }
        public Player_die player_Die { get; private set; }
        private WorktoUIpoint WorktoUIpointHP;
        [SerializeField] private Vector3 offsetHP;

        #endregion

        private CanvasGroup groupBlack;

        //用程式自動在腳色底下繪製一個地板偵測器
        private void OnDrawGizmos()
        {
            Gizmos.color = new Color(0.5f, 0.5f, 0.5f, 0.9f);
            Gizmos.DrawCube(transform.position + CheckGroundoffset, CheckGroundSize);
            Gizmos.DrawCube(transform.position + 確認公差, 確認大小);
        }

        

        protected override void Awake()
        {
            base.Awake();
            statemachine = new StateMachine();
            //this 為"類別",將Player帶入自己狀態
            player_idle = new Player_idle(this, statemachine, "待機");
            player_walk = new Player_walk(this, statemachine, "行走");
            player_jump = new Player_jump(this, statemachine, "跳躍");
            player_fall = new Player_fall(this, statemachine, "掉落");
            player_attack = new Player_attack(this, statemachine, "攻擊");
            Player_crouchwalk = new Player_crouchWalk(this, statemachine, "蹲下行走");
            player_Die = new Player_die(this, statemachine, "死亡");


            //狀態機 指定"預設狀態"為"待機"
            statemachine.Defaultstate(player_idle);

            ImgHP = GameObject.Find("圖片_血條").GetComponent<Image>();
            ImgHPeven = GameObject.Find("圖片_血條_效果").GetComponent<Image>();
            groupBlack = GameObject.Find("玩家死亡黑幕").GetComponent<CanvasGroup>();
            


            //TestcanControl();

        }
        private void Update()
        {
            //狀態機開始持續更新
            statemachine.Updatestate();

        }



        public bool Isgrounded()
        {
            return Physics2D.OverlapBox(transform.position + CheckGroundoffset, CheckGroundSize, 0, Layercanjump);
        }

        public bool CanStandUp()
        {
            return !Physics2D.OverlapBox(transform.position + 確認公差, 確認大小, 0, Layercanstandup);
        }

        //開啟控制模式
        private void TestcanControl()
        {
            canmove = true;
            canjump = true;
            cancrouch = true;
            canattack = true;
        }
        /// <summary>
        /// 切換控制玩家
        /// </summary>
        /// <param name="canControl">能不能控制</param>
        public void SwitchControl(bool canControl)
        {
            Rig.velocity = Vector3.zero;
            statemachine.Switchstate(player_idle);
            canmove = canControl;
            canjump = canControl;
            cancrouch = canControl;
            canattack = canControl;
        }

        protected override void Damage(float damage)
        {
            base.Damage(damage);
            CameraManager.Instance.startshakeCamera(0.8f, 3, 0.3f);
        }

        protected override void Dead()
        {
            base.Dead();
            statemachine.Switchstate(player_Die);
            StartCoroutine(DelayfadeinBlack());
            CameraManager.Instance.startshakeCamera(1.5f, 1, 0.2f);
        }

        private IEnumerator DelayfadeinBlack()
        {
            yield return new WaitForSeconds(1);
            StartCoroutine(Fadesystem.Fade(groupBlack));
        }
    }


}

