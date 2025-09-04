using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
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
        private CanvasGroup GroupTip;
        private TMP_Text TextTip;

        private void Awake()
        {
            btnSetting = GameObject.Find("按鈕_設定").GetComponent<Button>();
            group = GetComponent<CanvasGroup>();

            //設定子按鈕
            //注意:這裡的按鈕名稱需要與Unity編輯器中的按鈕名稱一致
            //當用Find尋找物件時,可以用"XXXX/0000"來找標題是XXXX的子物件0000
            btnSave = transform.Find("群組_設定按鈕群組/按鈕_儲存紀錄").GetComponent<Button>();
            btnLoad = transform.Find("群組_設定按鈕群組/按鈕_讀取紀錄").GetComponent<Button>();
            btnBacktomenu = transform.Find("群組_設定按鈕群組/按鈕_返回主頁面").GetComponent<Button>();
            btnQuit = transform.Find("群組_設定按鈕群組/按鈕_返回遊戲").GetComponent<Button>();

            GroupTip = transform.Find("群組_提示介面").GetComponent<CanvasGroup>();
            TextTip = transform.Find("群組_提示介面/文字_提示文字").GetComponent<TMP_Text>();

            //設定按鈕點擊事件
            btnSetting.onClick.AddListener(OnSettingButtonClick);

            btnSave.onClick.AddListener(() => StartCoroutine(Save()));
            btnLoad.onClick.AddListener(() => StartCoroutine(Load()));
            btnBacktomenu.onClick.AddListener(BacktoMenu);
            btnQuit.onClick.AddListener(Quit);

        }

        private void OnSettingButtonClick()
        {
            isSettingOpen = !isSettingOpen;
            Time.timeScale = isSettingOpen ? 0 : 1; //暫停或恢復遊戲
            
            //點擊設定按鈕後設定為沒有選取按鈕, 避免跳躍後再次觸發
            EventSystem.current.SetSelectedGameObject(null, null);

            StartCoroutine(Fadesystem.FadeRealtime(group, isSettingOpen));
        }

        private IEnumerator Save()
        {
            TextTip.text = "存檔中......";
            SaveloadSystem.instance.SaveData();
            yield return StartCoroutine(Fadesystem.FadeRealtime(GroupTip));
            yield return new WaitForSecondsRealtime(0.5f);
            TextTip.text = "存檔完成";
            yield return new WaitForSecondsRealtime(0.5f);
            yield return StartCoroutine(Fadesystem.FadeRealtime(GroupTip, false));
            yield return StartCoroutine(Fadesystem.FadeRealtime(group, false));
            Time.timeScale = 1;
        }

        private IEnumerator Load()
        {
            TextTip.text = "讀檔中......";            
            yield return StartCoroutine(Fadesystem.FadeRealtime(GroupTip));
            yield return new WaitForSecondsRealtime(0.5f);
            TextTip.text = "讀檔完成";
            yield return new WaitForSecondsRealtime(0.5f);
            SaveloadSystem.instance.LoadData();
            yield return StartCoroutine(Fadesystem.FadeRealtime(GroupTip, false));
            yield return StartCoroutine(Fadesystem.FadeRealtime(group, false));
            Time.timeScale = 1;
        }

        private void BacktoMenu()
        {
            LoadingManager.Instance.StartLoading("開始畫面");
        }

        private void Quit()
        {
            Application.Quit();
            Debug.Log("退出遊戲");
        }
    }
}
