using System.Collections;
using UnityEngine;
namespace PPman
{
    public class Fadesystem : MonoBehaviour
    {
        /// <summary>
        /// 淡入淡出
        /// </summary>
        /// <param name="group">畫布群組透明度</param>
        /// <param name="是否淡入">是否淡入</param>
        /// <returns></returns>
        

        public static IEnumerator Fade(CanvasGroup group, bool 是否淡入 = true)
        {
            //讓"增加值"來控制是否淡入淡出 增減值為0.1
            float 增加值 = 是否淡入 ? +0.1f : -0.1f;

            //用迴圈重複執行10次
            for (int i = 0; i < 10 ; i++)
            {
                //透明度隨時間遞增/遞減
                group.alpha += 增加值;

                //漸變時間設定為0.03秒
                yield return new WaitForSeconds(0.03f);

            }




        }
        
       

    }
}