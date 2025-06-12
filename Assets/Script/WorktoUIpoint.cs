using UnityEngine;
namespace PPman
{
    /// <summary>
    /// 世界座標(物件座標)轉為介面座標
    /// </summary>
    public class WorktoUIpoint : MonoBehaviour
    {
        private RectTransform Rect;

        private void Awake()
        {
            Rect = GetComponent<RectTransform>();
        }

        /// <summary>
        /// 更新介面座標
        /// </summary>
        /// <param name="target">目標物件</param>
        /// <param name="offset">位移</param>
        public void UpdatePosition(Transform target, Vector3 offset)
        {
            //計算目標座標與位移 : 目標座標+位移
            Vector3 point = target.position + offset ;
            //介面座標:透過主攝影機將世界座標轉為介面座標
            Vector3 uipoint = Camera.main.WorldToScreenPoint(point);
            //更新此介面座標
            Rect.position = uipoint;
        }

    }
}