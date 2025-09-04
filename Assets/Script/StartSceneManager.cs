using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

namespace PPman
{
    /// <summary>
    /// 開始畫面管理器
    /// </summary>
    public class StartSceneManager : MonoBehaviour
    {
        [SerializeField]private AudioMixer audioMixer ;

        private const string volumeMain = "VolumeMain", volumeBGM = "VolumeBGM", volumeSFX = "VolumeSFX";

        private CanvasGroup groupsetting;
        private Button btnload, btnstart, btnsetting, btnquit, btnsettingBack;
        private Slider sliderMain, sliderBGM, sliderSfx;

        private void Awake()
        {
            #region 初始化取得物件
            groupsetting = GameObject.Find("群組_設定介面").GetComponent<CanvasGroup>();
            btnload = GameObject.Find("按鈕_讀取紀錄").GetComponent <Button>();
            btnstart = GameObject.Find("按鈕_開始新遊戲").GetComponent<Button>();
            btnsetting = GameObject.Find("按鈕_設定").GetComponent<Button>();
            btnquit = GameObject.Find("按鈕_離開遊戲").GetComponent<Button>();
            btnsettingBack = GameObject.Find("按鈕_設定介面返回").GetComponent<Button>();
            sliderMain = GameObject.Find("Slider_主音量").GetComponent<Slider>();
            sliderBGM = GameObject.Find("Slider_音樂").GetComponent<Slider>();
            sliderSfx = GameObject.Find("Slider_音效").GetComponent<Slider>();
            #endregion
            btnload.onClick.AddListener(LoadGame);
            btnstart.onClick.AddListener(StartGame);
            btnsetting.onClick.AddListener(Setting);
            btnsettingBack.onClick.AddListener(SettingBack);
            btnquit.onClick.AddListener(Quit);

            sliderMain.onValueChanged.AddListener((x) => SetVolume(volumeMain,x));
            sliderBGM.onValueChanged.AddListener((x) => SetVolume(volumeBGM, x));
            sliderSfx.onValueChanged.AddListener((x) => SetVolume(volumeSFX, x));

        }
        private void LoadGame()
        {
            LoadingManager.Instance.StartLoadingandLoadData("遊戲場景");
        }
        private void StartGame()
        {
            LoadingManager.Instance.StartLoading("遊戲場景");
        }
        private void Setting()
        {
            StartCoroutine(Fadesystem.Fade(groupsetting));
        }
        private void SettingBack()
        {
            StartCoroutine(Fadesystem.Fade(groupsetting , false));
        }
        private void Quit()
        {
            Application.Quit();
        }

        private void SetVolume(string par, float value)
        {
            audioMixer.SetFloat(par, value);
        }


    }
}