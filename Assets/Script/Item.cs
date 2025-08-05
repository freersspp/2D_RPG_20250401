using Unity.VisualScripting;
using UnityEngine;
namespace PPman
{

    public class Item : MonoBehaviour
    {
        [SerializeField, Header("飛行速度"), Range(1, 20)] private float flyspeed = 7;
        private Transform player;
        private void Awake()
        {
            player = GameObject.Find("主角").transform;
        }

        private void Update()
        {
            Flytoplayer();
        }


        /// <summary>
        /// 道具飛向玩家
        /// </summary>
        private void Flytoplayer()
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, flyspeed * Time.deltaTime);
        }












    }
}