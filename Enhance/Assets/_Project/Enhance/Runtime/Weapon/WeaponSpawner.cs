using UnityEngine;

namespace Enhance.Runtime.Weapon
{
    public class WeaponSpawner : Spawner
    {
        [SerializeField] private float _timeTillNextWeaponSpawn = 5f;

        private float _timer = 0f;

        protected override void Start()
        {
            base.Start();
            SpawnRandomObject();
        }

        protected override void Update()
        {
            base.Update();

            _timer += Time.deltaTime;

            if (_timer > _timeTillNextWeaponSpawn)
            {
                _timer = 0f;
                SpawnRandomObject();
            }
        }

        public void SetLevelUpSystem(LevelUpSystem levelUpSystem)
        {
            levelUpSystem.OnLevelChanged += LevelUpSystem_OnLevelChanged;
        }

        private void LevelUpSystem_OnLevelChanged(object sender, System.EventArgs e)
        {
            SpawnRandomObject();
        }
    }
}
