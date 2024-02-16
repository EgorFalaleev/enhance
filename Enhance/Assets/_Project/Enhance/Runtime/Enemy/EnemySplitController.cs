using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySplitController : Spawner
{
    [SerializeField] private int _numberOfEnemiesToSpawn = 2;

    void Start()
    {
        GetComponent<EnemyHealthController>().OnDie += EnemySplitController_OnDie;
    }

    private void EnemySplitController_OnDie(object sender, System.EventArgs e)
    {
        for (int i = 0; i < _numberOfEnemiesToSpawn; i++)
        {
            SpawnSpecificObject(_prefabsToSpawn[0]);
        }
    }
}
