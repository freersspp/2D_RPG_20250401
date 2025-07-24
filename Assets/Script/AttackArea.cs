using UnityEngine;
namespace PPman
{

    public class AttackArea : MonoBehaviour
    {
        [field: SerializeField, Header("攻擊力"), Range(10, 100)] public float attack { get; private set; } = 30
            ;
    }
}