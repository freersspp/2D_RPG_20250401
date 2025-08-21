using System;
using UnityEngine;
using UnityEngine.UI;
namespace PPman
{
    /// <summary>
    /// 設定管理器:負責遊戲設定的相關處理
    /// </summary>
    public class SettingManager : MonoBehaviour
    {
        //設定按鈕
        private Button btnSetting;
        //設定面板
        private CanvasGroup group;
        //設定子按鈕
        private Button btnSave, btnLoad, btnBacktomenu, btnQuit;
        private bool isSettingOpen = false;

        private void Awake()
        {
            btnSetting = GameObject.Find("按鈕_設定").GetComponent<Button>();
            group = GetComponent<CanvasGroup>();

            //設定子按鈕
            //注意:這裡的按鈕名稱需要與Unity編輯器中的按鈕名稱一致
            //當用Find尋找物件時,可以用"XXXX/0000"來找標題是XXXX的子物件0000
            btnSave = transform.Find("群組_設定按鈕群組/按鈕_儲存檔案").GetComponent<Button>();
            btnLoad = transform.Find("群組_設定按鈕群組/按鈕_讀取檔案").GetComponent<Button>();
            btnBacktomenu = transform.Find("群組_設定按鈕群組/按鈕_讀取檔案").GetComponent<Button>();
            btnQuit = transform.Find("群組_設定按鈕群組/按鈕_讀取檔案").GetComponent<Button>();
            //設定按鈕點擊事件
            btnSetting.onClick.AddListener(OnSettingButtonClick);


        }

        private void OnSettingButtonClick()
        {
            isSettingOpen = !isSettingOpen;
            StartCoroutine(Fadesystem.Fade(group,isSettingOpen));
        }
    }
}
