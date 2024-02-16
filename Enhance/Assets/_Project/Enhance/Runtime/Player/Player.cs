using Enhance.Runtime.UI;
using Enhance.Runtime.Weapon;
using UnityEngine;

namespace Enhance.Runtime.Player
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private GameObject _levelWindow;
        [SerializeField] private GameObject _weaponSpawner;

        public LevelUpSystem _levelUpSystem;

        void Start()
        {
            _levelUpSystem = new LevelUpSystem();
            _levelWindow.GetComponent<LevelUpUIController>().SetLevelUpSystem(_levelUpSystem);
            _weaponSpawner.GetComponent<WeaponSpawner>().SetLevelUpSystem(_levelUpSystem);
        }
    }
}
