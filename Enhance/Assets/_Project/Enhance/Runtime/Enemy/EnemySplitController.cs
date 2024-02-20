using UnityEngine;

namespace Enhance.Runtime.Enemy
{
    public class EnemySplitController : Spawner
    {
        [SerializeField] private int _numberOfEnemiesToSpawn = 2;

        protected override void Start()
        {
            _spawnCenter = transform;
            GetComponent<EnemyHealthController>().OnDie += EnemySplitController_OnDie;
        }

        private void EnemySplitController_OnDie(object sender, System.EventArgs e)
        {
            for (int i = 0; i < _numberOfEnemiesToSpawn; i++)
            {
                SpawnSpecificObject(_spawnerConfig.PrefabsToSpawn[0]);
            }
        }
    }
}
