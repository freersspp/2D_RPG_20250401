using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

namespace PPman
{
    /// <summary>
    /// 載入管理器:負責遊戲載入時的相關處理
    /// </summary>
    public class LoadingManager : MonoBehaviour
    {
        private CanvasGroup group;
        private TMP_Text textPercent;
        private Image imgLoadingbar;

        private void Awake()
        {
            group = GetComponent<CanvasGroup>();
            textPercent = transform.Find("文字_載入系統_百分比").GetComponent<TMP_Text>();
            imgLoadingbar = transform.Find("圖片_載入系統_進度條").GetComponent<Image>();
        }

        private IEnumerator Loading(string sceneName)
        {
            // 非同步載入設定 ao = 場景管理器 的 非同步 載入(場景名稱);
            AsyncOperation ao = SceneManager.LoadSceneAsync(sceneName);
            // 確保載入場景時不會自動啟用
            ao.allowSceneActivation = false;

            //當場景尚未載入成功持續進行
            while (!ao.isDone)
            {
                // 更新載入進度條和文字
                textPercent.text = $"{(ao.progress / 0.9f * 100).ToString("F2")}%";
                imgLoadingbar.fillAmount = ao.progress / 0.9f;

                //當載入接近90%後, 允許場景切換
                if (ao.progress >= 0.9f)
                {
                    ao.allowSceneActivation = true;
                }
                // 等待下一幀
                yield return null;


            }

        }

    }



}
