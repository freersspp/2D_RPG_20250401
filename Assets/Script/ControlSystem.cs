using UnityEngine;

public class ControlSystem : MonoBehaviour
{

    [Header("基本資料")]
    [SerializeField, Range(0, 50)] private float moveSpeed = 8.0f;
    [SerializeField, Range(0, 50)] float Jumpforce = 3.0f;
    [SerializeField] float Att = 3.0f;
    [SerializeField] private Animator Ani;
    [SerializeField] private Rigidbody2D Rig;


    private void Update()
    {
        //設定浮點數h為水平移動的變量
        float h = Input.GetAxis("Horizontal");
        Debug.Log("水平值 :" + h);

        //利用h變量乘上移動速度獲得現在腳色的移動速度
        Rig.velocity = new Vector2(h * moveSpeed, Rig.velocity.y);
        
        // Mathf.Abs代表給數字帶上絕對值
        Ani.SetFloat("移動", Mathf.Abs(h));


        //讓2D腳色顯示面向前面還是後面
        //設定angle 角度判斷角度(h) 改變腳色面對方向(Y軸數值)
        float angle = h > 0 ? 0 : 180;
        transform.eulerAngles = new Vector3(0, angle, 0);   
               
    }


}


