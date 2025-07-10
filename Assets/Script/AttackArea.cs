using UnityEngine;
namespace PPman
{

    public class AttackArea : MonoBehaviour
    {
        [field: SerializeField, Header("§ðÀ»¤O"), Range(10, 100)] public float attack { get; private set; } = 20;
    }
}