using Unity.VisualScripting;
using UnityEngine;
namespace PPman
{

    public class Item : MonoBehaviour
    {
        [SerializeField, Header("飛行速度"), Range(1, 20)] private float flyspeed = 7;
        [SerializeField, Header("吃掉距離"), Range(0, 1)] private float eatdistance = 0.5f;
        [SerializeField, Header("延遲時間")] private float dalaytime = 1.2f;
        private Transform player;
        bool active;
        private void Awake()
        {
            player = GameObject.Find("主角").transform;
            Invoke(nameof(Active), dalaytime);
        }

        

        private void Update()
        {
            if(!active)
            {
                return;
            }
            
            Flytoplayer();
            EatItem();
        }


        private void Active()
        {
            active = true;
        }
        

        /// <summary>
        /// 道具飛向玩家
        /// </summary>
        private void Flytoplayer()
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, flyspeed * Time.deltaTime);
        }

        private void EatItem()
        {
            float distance = Vector2.Distance(transform.position, player.position);
            if (distance < eatdistance)
            {
                GetItem();
                Destroy(gameObject);
            }
        }

        protected virtual void GetItem()
        {

        }










    }
}