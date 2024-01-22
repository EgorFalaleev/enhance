using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public LevelUpSystem _levelUpSystem;

    void Start()
    {
        _levelUpSystem = new LevelUpSystem();
        GameObject.Find("LevelWindow").GetComponent<LevelUpUIController>().SetLevelUpSystem(_levelUpSystem);
    }
}
