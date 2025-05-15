using UnityEngine;
namespace PPman
{
    /// <summary>
    /// 玩家:儲存玩家資料與基本功能
    /// </summary>
    public class Player : MonoBehaviour
    {
        #region 變數
        [Header("基本資料")]
        [SerializeField, Range(0, 50)] private float moveSpeed = 8.0f;
        [SerializeField, Range(0, 50)] float Jumpforce = 8.0f;
        [SerializeField] float Att = 3.0f;
        [SerializeField] private Animator Ani;
        [SerializeField] private Rigidbody2D Rig;
        
        [Header("檢查地板資料")]
        [SerializeField] private Vector3 CheckGroundSize = Vector3.one;
        [SerializeField] private Vector3 CheckGroundoffset;
        [SerializeField] private LayerMask Layercanjump;
        #endregion

        #region 狀態資料
        public StateMachine statemachine;
        public Player_idle player_idle;
        public Player_walk player_walk;
        public Player_jump player_jump;
        public Player_fall player_fall;
        public Player_attack player_attack; 
        #endregion

        //用程式自動在腳色底下繪製一個地板偵測器
        private void OnDrawGizmos()
        {
            Gizmos.color = new Color(0.5f, 0.5f, 0.5f, 0.9f);
            Gizmos.DrawCube(transform.position + CheckGroundoffset, CheckGroundSize);
        }

        private void Awake()
        {
            statemachine = new StateMachine();
            player_idle = new Player_idle();
            player_walk = new Player_walk();
            player_jump = new Player_jump();
            player_fall = new Player_fall();
            player_attack = new Player_attack();

            //狀態機 指定"預設狀態"為"待機"
            statemachine.Defaultstate(player_idle);

        }
        private void Update()
        {
            //狀態機開始持續更新
            statemachine.Updatestate();

        }




    }


}

