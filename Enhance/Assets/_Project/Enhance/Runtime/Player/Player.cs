using Enhance.Runtime.UI;
using Enhance.Runtime.Weapon;
using UnityEngine;

namespace Enhance.Runtime.Player
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private GameObject _levelWindow;
        [SerializeField] private WeaponSpawner _weaponSpawner;

        public LevelUpSystem LevelSystem { get; private set; }

        private void Start()
        {
            LevelSystem = new LevelUpSystem();
            _levelWindow.GetComponent<LevelUpUIController>().SetLevelUpSystem(LevelSystem);
            _weaponSpawner.SetLevelUpSystem(LevelSystem);
            GameStatsController.Instance.SetupLevelUpSystem(LevelSystem);
        }
    }
}
