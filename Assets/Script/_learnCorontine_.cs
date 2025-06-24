using System.Collections;
using UnityEngine;
namespace PPman
{
    /// <summary>
    /// 學習偕同程序:Coroutine
    /// 作用:讓時間等待
    /// 條件:
    /// 1. 引用System.Collections;
    /// 2. 宣告傳回 LearnCoroutine 的方法
    /// 3. 方法內使用關鍵字yield return 等待時間
    /// 4. 使用StartCoroutine啟動
    /// </summary>
    public class LearnCoroutine : MonoBehaviour
    {
        private void Awake()
        {
            StartCoroutine(Test());
        }
        private IEnumerator Test()
        {
            Debug.Log("1");
            yield return new WaitForSeconds(1);
            Debug.Log("2");
            yield return new WaitForSeconds(2);
            Debug.Log("3");
            yield return new WaitForSeconds(3);

        }






    }
}