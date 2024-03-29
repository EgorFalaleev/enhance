using UnityEngine;

namespace Enhance.Data
{
    [CreateAssetMenu(fileName = "PlayerConfig", menuName = "ScriptableObjects/PlayerConfig")]
    public class PlayerConfigSO : ScriptableObject
    {
        [field: SerializeField] public int MaxHealth { get; private set; }
        [field: SerializeField] public float MoveSpeed { get; private set; }
        [field: SerializeField] public float DashingPower { get; private set; }
        [field: SerializeField] public float DashingTime { get; private set; }
        [field: SerializeField] public float DashingCooldown { get; private set; }
    }
}
