using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
