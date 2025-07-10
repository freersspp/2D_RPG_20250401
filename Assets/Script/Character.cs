using UnityEngine;
namespace PPman
{

    public class Character : MonoBehaviour
    {
        //利用字尾{ get; private set; }讓該參數外部可以讀取但是無法修改(保護資料,僅限讀取)
        public Animator Ani { get; private set; }
        public Rigidbody2D Rig { get; private set; }
        [SerializeField, Range(0, 1000)] protected float hpmax = 100;
        [SerializeField, Header("會讓自己受傷的物件標籤")] private string DamageObjectTag;

        protected float hp;

        protected virtual void Awake()
        {
            Ani = GetComponent<Animator>();
            Rig = GetComponent<Rigidbody2D>();
            hp = hpmax;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            //如果 血量 <= 0 就跳出
            if(hp <= 0)
            {
                return;
            }

            //如果碰到的物件標籤是"DamageObjectTag"才會受傷
            if (collision.CompareTag(DamageObjectTag))
            {
                Damage(collision.GetComponent<AttackArea>().attack);
            }
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
        /// <summary>
        /// 受傷扣血
        /// </summary>
        /// <param name="damage">傷害值</param>
        private void Damage(float damage)
        {
            hp -= damage;
            Debug.Log($"<color=blue>{name} 受傷 , 血量: {hp}</color>");
            if (hp <= 0)
            {
                Dead();
            }
        }
        protected virtual void Dead()
        {
            Debug.Log($"<color=green>{name}死亡!</color>");
        }



    }
}
