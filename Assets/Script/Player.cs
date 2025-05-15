using UnityEngine;
namespace PPman
{
    /// <summary>
    /// 玩家:儲存玩家資料與基本功能
    /// </summary>
    public class Player : MonoBehaviour
    {
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

        //用程式自動在腳色底下繪製一個地板偵測器
        private void OnDrawGizmos()
        {
            Gizmos.color = new Color(0.5f, 0.5f, 0.5f, 0.9f);
            Gizmos.DrawCube(transform.position + CheckGroundoffset, CheckGroundSize);
        }

    }


}

