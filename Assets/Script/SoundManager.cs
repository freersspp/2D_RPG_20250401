using UnityEngine;
namespace PPman
{
    [RequireComponent(typeof(AudioSource))]

    public class SoundManager : MonoBehaviour
    {
        private static SoundManager _instance;
        public static SoundManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = FindObjectOfType<SoundManager>();
                }
                return _instance;
            }
        }

        private AudioSource audio;
        [SerializeField, Header("所有音效")] private AudioClip[] allsound;

        /// <summary>
        /// 敵人_受傷
        /// 敵人_死亡
        /// 玩家_受傷
        /// 玩家_攻擊1
        /// 玩家_攻擊2
        /// 玩家_攻擊3
        /// 玩家_死亡
        /// 玩家_落地
        /// 玩家_走路
        /// 玩家_跳躍
        /// 道具_掉落
        /// 道具_獲得
        /// </summary>


        private void Awake()
        {
            audio = GetComponent<AudioSource>();

        }
        /// <summary>
        /// 撥放音效:固定音量
        /// </summary>
        /// <param name="soundType"></param>
        public void PlaySound(SoundType soundType)
        {
            audio.PlayOneShot(allsound[(int)soundType]);
        }

        /// <summary>
        /// 播放音效時用隨機的音量撥放
        /// </summary>
        /// <param name="soundType">音效類型</param>
        /// <param name="minVolume">最小聲</param>
        /// <param name="maxVolume">最大聲</param>
        public void PlaySound(SoundType soundType, float minVolume = 0.7f, float maxVolume = 1.2f)
        {
            float volume = Random.Range(minVolume, maxVolume);
            audio.PlayOneShot(allsound[(int)soundType], volume);
        }
    }
}