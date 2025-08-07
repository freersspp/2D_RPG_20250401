using UnityEngine;
namespace PPman
{
    /// <summary>
    /// 敵人生成
    /// </summary>
    public class SpawnEnemy : MonoBehaviour
    {
        [Header("生成資料")]
        [SerializeField] private GameObject prefabEnemy;
        [SerializeField, Range(3, 5)] private float respawntime;
        private GameObject objectEnemy;
        private Enemy Enemy;

        private void Awake()
        {
            objectEnemy = Instantiate(prefabEnemy, transform);

            objectEnemy.transform.localPosition = Vector3.zero;
            objectEnemy.transform.localEulerAngles = new Vector3(0, Random.value >= 0.5f ? 180 : 0, 0);

            Enemy = objectEnemy.GetComponent<Enemy>();

            Enemy.onDead += Respawn;
        }

        private void Respawn()
        {
            Invoke(nameof(delayrespawn), respawntime);
        }

        private void delayrespawn()
        {
            Enemy.Respawn();
            objectEnemy.transform.localPosition = Vector3.zero;
        }
    }
}