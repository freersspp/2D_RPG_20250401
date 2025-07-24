using Cinemachine;
using System.Collections;
using UnityEngine;
namespace PPman
{
    //同步重新命名: 一單詞在多個地方重複使用可以用Ctrl+RR一次性全部單詞一起修改


    public class CameraManager : MonoBehaviour
    {
        #region 單例模式
        //使用時機:
        //1. 此類別只有一個存在(場景上僅有一個)
        //2. 需要讓其他類別讀取

        //保存此類別變數
        private static CameraManager _instance;
        //讓外部讀取的唯獨屬性
        public static CameraManager Instance
        {
            get
            {
                //如果變數是空的就透過"FindObjectOfType"尋找哪個物件有掛"CameraManager"
                if (_instance == null)
                {
                    _instance = FindObjectOfType<CameraManager>();
                }
                //回傳變數
                return _instance;
            }
            #endregion
        }

        private CinemachineVirtualCamera virtualCamera;
        private CinemachineBasicMultiChannelPerlin perlin;

        private float defaultAmplitude, defaultFrequency;

        private void Awake()
        {
            //獲得虛擬攝影機元件
            virtualCamera = GetComponent<CinemachineVirtualCamera>();
            //獲得柏林函數元件
            perlin = virtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

            //獲得預設值的強度和頻率
            defaultAmplitude = perlin.m_AmplitudeGain;
            defaultFrequency = perlin.m_FrequencyGain;

        }

        /// <summary>
        /// 晃動攝影機
        /// </summary>
        /// <param name="amplitude">強度</param>
        /// <param name="frequency">頻率</param>
        /// <param name="time">晃動時間</param>
        public void startshakeCamera(float amplitude, float frequency, float time)
        {
            StartCoroutine(shakeCamera(amplitude, frequency, time));
        }

        /// <summary>
        /// 晃動攝影機
        /// </summary>
        /// <param name="amplitude">強度</param>
        /// <param name="frequency">頻率</param>
        /// <param name="time">晃動時間</param>
        /// <returns></returns>
        private IEnumerator shakeCamera(float amplitude, float frequency, float time)
        {
            //更新強度和頻率
            perlin.m_AmplitudeGain = amplitude;
            perlin.m_FrequencyGain = frequency;

            yield return new WaitForSeconds(time);

            //恢復預設強度與頻率
            perlin.m_AmplitudeGain = defaultAmplitude;
            perlin.m_FrequencyGain = defaultFrequency;

        }


    }
}