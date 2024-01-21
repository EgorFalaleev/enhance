using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSpawner : Spawner
{
    [SerializeField] private float _timeTillNextWeaponSpawn = 5f;

    private float _timer = 0f;

    void Start()
    {
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
}
