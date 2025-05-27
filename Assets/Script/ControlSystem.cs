using UnityEngine;

public class ControlSystem : MonoBehaviour
{
    [Header("基本資料")]
    [SerializeField, Range(0, 50)] private float moveSpeed = 8.0f;
    [SerializeField, Range(0, 50)] float Jumpforce = 8.0f;
    [SerializeField] float Att = 3.0f;
    private Animator Ani;
    private Rigidbody2D Rig;
    
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
    private void Update()
    {
        //設定浮點數h為水平移動的變量
        float h = Input.GetAxis("Horizontal");

        //利用h變量乘上移動速度獲得現在腳色的移動速度
        Rig.velocity = new Vector2(h * moveSpeed, Rig.velocity.y);
        
        // Mathf.Abs代表給數字帶上絕對值
        Ani.SetFloat("移動", Mathf.Abs(h));
        //利用地板偵測器檢查腳色是否有碰到地板
        bool isground = Physics2D.OverlapBox(transform.position + CheckGroundoffset, CheckGroundSize, 0, Layercanjump);

        Debug.Log($"<color=green>是否碰到底板 : {isground}</color>");
        //如果腳色在地板 和 按下空白鍵後人物跳躍
        if (isground && Input.GetKeyDown(KeyCode.Space))
        {
            Rig.velocity = new Vector2(0, Jumpforce);
        }
        Ani.SetBool("是否在地板上", isground);
        Ani.SetFloat("跳躍", Rig.velocity.y);

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


}


