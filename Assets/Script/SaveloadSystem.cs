using UnityEngine;
namespace PPman
{

    /// <summary>
    /// 存讀檔系統
    /// </summary>
    public class SaveloadSystem : MonoBehaviour
    {

        #region 單例模式
        private static SaveloadSystem _instance;
        public static SaveloadSystem instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = FindAnyObjectByType<SaveloadSystem>();
                }
                return _instance;
            }
        }
        #endregion

        [SerializeField]
        private PlayerData PlayerData;
        //儲存檔案名: 在這邊列舉數目等同於玩家可以儲存資料的筆數
        private const string DataName = "遊戲儲存資料";

        private Transform playertransform;
        private Player player;        
        private Knight _knight;


        private void Awake()
        {
            playertransform = GameObject.Find(GameManager.PlayerName).transform;
            player = GameObject.Find(GameManager.PlayerName).GetComponent<Player>();
            _knight = GameObject.Find(GameManager.npc_騎士).GetComponent<Knight>();
        }

        private void Start()
        {
            //測試用
            //SaveData();
        }
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Y))
            {
                SaveData();
            }
            if (Input.GetKeyDown(KeyCode.U))
            {
                LoadData();
            }
        }
        /// <summary>
        /// 將玩家資料儲存到本機端
        /// </summary>
        public void SaveData()
        {
            PlayerData.Position = playertransform.position;
            PlayerData.Rotation = playertransform.eulerAngles;
            PlayerData.hpmax = player.hpmaxdata;
            PlayerData.hp = player.hpdata;
            PlayerData.MissionCount = _knight.已取得任務道具數量;

            //將PlayerData轉檔為json模式, 容量小且讀取快速
            var json = JsonUtility.ToJson(PlayerData);
            Debug.Log(json);

            //將轉為json的文字資料儲存到本機, 名稱為"遊戲儲存資料"
            PlayerPrefs.SetString(DataName, json);
        }

        /// <summary>
        /// 從本機端讀取玩家資料並更新到遊戲物件上
        /// </summary>
        public void LoadData()
        {
            //1. 從本機端讀檔案
            var json = PlayerPrefs.GetString(DataName);

            //2. 從json 轉回 PlayerData
            PlayerData = JsonUtility.FromJson<PlayerData>(json);

            //3. 將PlayerData轉到物件上
            playertransform.position = PlayerData.Position;
            playertransform.eulerAngles = PlayerData.Rotation;
            _knight.LoadCount(PlayerData.MissionCount);
            player.LoadHPUpdateUI(PlayerData.hpmax, PlayerData.hp);
        }
    }
}