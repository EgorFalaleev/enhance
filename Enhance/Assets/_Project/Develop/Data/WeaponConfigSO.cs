using UnityEngine;

[CreateAssetMenu(fileName = "WeaponConfig", menuName = "ScriptableObjects/WeaponConfig")]
public class WeaponConfigSO : ScriptableObject
{
    [SerializeField] private int _maxHealth;
    [SerializeField] private float _lifeTime;
}
