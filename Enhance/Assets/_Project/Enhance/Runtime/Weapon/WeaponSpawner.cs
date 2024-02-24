using System.Collections.Generic;
using UnityEngine;

namespace Enhance.Runtime.Weapon
{
    public class WeaponSpawner : Spawner
    {
        private float _timer = 0f;

        protected override void Start()
        {
            base.Start();
            SpawnRandomObject(DistanceToPlayerCalculator.MaxDistance);
        }

        protected override void Update()
        {
            base.Update();

            _timer += Time.deltaTime;

            if (_timer > _spawnerConfig.TimeTillNextObjectSpawn)
            {
                _timer = 0f;
                SpawnRandomObject(DistanceToPlayerCalculator.MaxDistance);
            }
        }

        public void SetLevelUpSystem(LevelUpSystem levelUpSystem)
        {
            levelUpSystem.OnLevelChanged += LevelUpSystem_OnLevelChanged;
        }

        private void LevelUpSystem_OnLevelChanged(object sender, System.EventArgs e)
        {
            SpawnRandomObject(DistanceToPlayerCalculator.MaxDistance);
        }
    }

    public static class DistanceToPlayerCalculator
    {
        public static float MaxDistance { get; private set; }
        private static List<float> _weaponToPlayerDistances = new List<float>();

        public static void AddDistance(float distance)
        {
            _weaponToPlayerDistances.Add(distance);
            UpdateMaxOffset();
        }

        public static void RemoveDistance(float distance)
        {
            _weaponToPlayerDistances.Remove(distance);
            UpdateMaxOffset();
        }

        private static void UpdateMaxOffset()
        {
            if (_weaponToPlayerDistances.Count == 0)
                MaxDistance = 0f;
            else
            {
                _weaponToPlayerDistances.Sort();
                // max distance is always the last element in the list
                MaxDistance = _weaponToPlayerDistances[^1];
            }
        }
    }
}