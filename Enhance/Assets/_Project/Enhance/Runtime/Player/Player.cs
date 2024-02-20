using Enhance.Runtime.UI;
using Enhance.Runtime.Weapon;
using UnityEngine;

namespace Enhance.Runtime.Player
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private GameObject _levelWindow;
        [SerializeField] private GameObject _weaponSpawner;

        public LevelUpSystem LevelSystem { get; private set; }

        void Start()
        {
            LevelSystem = new LevelUpSystem();
            _levelWindow.GetComponent<LevelUpUIController>().SetLevelUpSystem(LevelSystem);
            _weaponSpawner.GetComponent<WeaponSpawner>().SetLevelUpSystem(LevelSystem);
        }
    }
}
