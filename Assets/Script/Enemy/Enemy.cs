using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

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
        [SerializeField] private GameObject prefabhp;
        private Transform groupEnemyHP;



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

        public StateMachine stateMachine { get; private set; }
        public EnemyIdle enemyIdle { get; private set; }
        public EnemyFollow enemyFollow { get; private set; }
        public EnemyAttack enemyAttack { get; private set; }
        public EnemyWalk enemyWalk { get; private set; }
        public EnemyDie enemyDie { get; private set; }
        public Transform player { get; private set; }
        private CanvasGroup groupHP;
        private WorktoUIpoint WorktoUIpointHP;
        [SerializeField] private Vector3 offsetHP;

        [field: Header("掉落道具")]
        [field: SerializeField, Range(0, 1)]
        public float dropProbability { get; private set; } = 0.9f;
        [field: SerializeField] public GameObject prefabDrop;

        /// <summary>
        /// 生成掉落物
        /// </summary>
        public void spawnDrop()
        {
            GameObject tempdrop = Instantiate(prefabDrop, transform.position, Quaternion.identity);
            tempdrop.GetComponent<Rigidbody2D>().velocity = new Vector2(UnityEngine.Random.Range(-1.5f, 1.5f), 5);
        }


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
            groupEnemyHP = GameObject.Find("群組_敵人血條_全部").transform;
            //生成"群組_敵人血條_全部", 並將"群組_敵人血條_全部"當成父物件
            Transform enemyhp = Instantiate(prefabhp, groupEnemyHP).transform;
            groupHP = enemyhp.GetComponent<CanvasGroup>();
            WorktoUIpointHP = enemyhp.GetComponent<WorktoUIpoint>();

            //Find("名稱")透過名稱尋找子物件
            ImgHPeven = enemyhp.Find("圖片_血條_效果").GetComponent<Image>();
            ImgHP = enemyhp.Find("圖片_血條").GetComponent<Image>();

        }
        private void Update()
        {
            stateMachine.Updatestate();
            WorktoUIpointHP.UpdatePosition(transform, offsetHP);
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

        protected override void Damage(float damage)
        {
            base.Damage(damage);
            StartCoroutine(Fadesystem.Fade(groupHP));
            CameraManager.Instance.startshakeCamera(0.8f, 3, 0.3f);
        }

        protected override void Dead()
        {
            base.Dead();
            stateMachine.Switchstate(enemyDie);
            StartCoroutine(Delayfadeout());
            CameraManager.Instance.startshakeCamera(1.5f, 1, 0.2f);
        }

        private IEnumerator Delayfadeout()
        {
            yield return new WaitForSeconds(0.3f);
            StartCoroutine(Fadesystem.Fade(groupHP, false));
        }

    }
}