using UnityEngine;
namespace PPman
{

    public class Enemy : Character
    {

        [field: SerializeField] public Vector2 idletime { get; private set; } = new Vector2(1, 3);
        [field: SerializeField] public Vector2 walktime { get; private set; } = new Vector2(2, 5);
        [field: SerializeField, Range(1, 5)] public float walkspeed { get; private set; } = 1.5f;
        [field: SerializeField, Range(3, 8)] public float followspeed { get; private set; } = 4f;
        [field: SerializeField, Range(1, 3)] public float attackdistance { get; private set; } = 1f;
        [field: SerializeField] public float attacktime { get; private set; } = 1.5f;

        #region 確認周遭環境資料
        /// <summary>
        /// 確認前方有沒有牆壁
        /// </summary>
        [field: SerializeField] private Vector3 checkwall = Vector3.one;
        [field: SerializeField] private Vector3 checkwalloffset;
        [field: SerializeField] private LayerMask layerwall;

        /// <summary>
        /// 確認前方有沒有地板
        /// </summary>
        [field: SerializeField] private Vector3 checkground = Vector3.one;
        [field: SerializeField] private Vector3 checkgroundoffset;
        [field: SerializeField] private LayerMask layerground;


        /// <summary>
        /// 確認前方有沒有玩家
        /// </summary>
        [field: SerializeField] private Vector3 checkplayer = Vector3.one;
        [field: SerializeField] private Vector3 checkplayeroffset;
        [field: SerializeField] private LayerMask layerplayer;
        #endregion

        public StateMachine stateMachine {  get; private set; }
        public EnemyIdle enemyIdle { get; private set; }
        public EnemyFollow enemyFollow { get; private set; }
        public EnemyAttack enemyAttack { get; private set; }
        public EnemyWalk enemyWalk { get; private set; }
        public EnemyDie enemyDie { get; private set; }
        public Transform player { get; private set; }
        



        private void OnDrawGizmos()
        {
            Gizmos.color = new Color(0.5f, 0.5f, 0.5f, 0.9f);
            Gizmos.DrawCube(transform.position + transform.TransformDirection(checkwalloffset), checkwall);

            Gizmos.color = new Color(0.5f, 0.5f, 0.5f, 0.9f);
            Gizmos.DrawCube(transform.position + transform.TransformDirection(checkgroundoffset), checkground);

            Gizmos.color = new Color(0.5f, 0.5f, 0.5f, 0.9f); ;
            Gizmos.DrawCube(transform.position + transform.TransformDirection(checkplayeroffset), checkplayer);

        }

        protected override void Awake()
        {
            base.Awake();
            player = GameObject.Find("主角").transform;
            stateMachine = new StateMachine();
            enemyIdle = new EnemyIdle(this, stateMachine, "敵人待機");
            enemyFollow = new EnemyFollow(this, stateMachine, "敵人追蹤");
            enemyAttack = new EnemyAttack(this, stateMachine, "敵人攻擊");
            enemyWalk = new EnemyWalk(this, stateMachine, "敵人遊走");
            enemyDie = new EnemyDie(this, stateMachine, "敵人死亡");

            stateMachine.Defaultstate(enemyIdle);
        }
        private void Update()
        {
             stateMachine.Updatestate();
            //Debug.Log($"前方是否有牆壁:{IsWallFront()}");
            //Debug.Log($"前方是否有地板:{IsGroundFront()}");
        }
        /// <summary>
        /// 確認前方有沒有牆壁
        /// </summary>
        /// <returns>IsWallFront</returns>
        public bool IsWallFront()
        {
            return Physics2D.OverlapBox(transform.position + transform.TransformDirection(checkwalloffset), checkwall, 0, layerwall);
        }
        /// <summary>
        /// 確認前方有沒有地板
        /// </summary>
        /// <returns>IsGroundFront</returns>
        public bool IsGroundFront()
        {
            return Physics2D.OverlapBox(transform.position + transform.TransformDirection(checkgroundoffset), checkground, 0, layerground);
        }
        /// <summary>
        /// 確認前方有沒有玩家
        /// </summary>
        /// <returns></returns>
        public bool IsPlayerFront()
        {
            return Physics2D.OverlapBox(transform.position + transform.TransformDirection(checkplayeroffset), checkplayer, 0, layerplayer);
        }

        protected override void Dead()
        {
            base.Dead();
            stateMachine.Switchstate(enemyDie);
        }

    }
}