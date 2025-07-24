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
        private void Awake()
        {
            audio = GetComponent<AudioSource>();
        }







    }
}