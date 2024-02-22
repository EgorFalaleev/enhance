using System.Collections.Generic;
using UnityEngine;

namespace Enhance.Runtime.Weapon
{
    public class WeaponSpawner : Spawner
    {
        private float _timer = 0f;
        private static float _maxSpawnOffset = 0f;
        private static List<float> _weaponToPlayerDistances = new List<float>(); 

        protected override void Start()
        {
            base.Start();
            SpawnRandomObject(_maxSpawnOffset);
        }

        protected override void Update()
        {
            base.Update();

            _timer += Time.deltaTime;

            if (_timer > _spawnerConfig.TimeTillNextObjectSpawn)
            {
                _timer = 0f;
                SpawnRandomObject(_maxSpawnOffset);
            }
        }

        public static void AddDistance(float distance)
        {
            _weaponToPlayerDistances.Add(distance);
            Debug.Log("added element. List: " + _weaponToPlayerDistances.Count);
            UpdateMaxOffset();
        }

        public static void RemoveDistance(float distance)
        {
            _weaponToPlayerDistances.Remove(distance);
            Debug.Log("removed element. List: "+ _weaponToPlayerDistances.Count);
            UpdateMaxOffset();
        }

        public void SetLevelUpSystem(LevelUpSystem levelUpSystem)
        {
            levelUpSystem.OnLevelChanged += LevelUpSystem_OnLevelChanged;
        }

        private void LevelUpSystem_OnLevelChanged(object sender, System.EventArgs e)
        {
            SpawnRandomObject(_maxSpawnOffset);
        }

        private static void UpdateMaxOffset()
        {
            if (_weaponToPlayerDistances.Count == 0)
                _maxSpawnOffset = 0f;
            else
            {
                _weaponToPlayerDistances.Sort();
                // max distance is always in the last element
                _maxSpawnOffset = _weaponToPlayerDistances[^1];
                Debug.Log(_maxSpawnOffset);
            }
        }
    }
}