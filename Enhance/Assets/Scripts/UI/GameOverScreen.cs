using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameOverScreen : MonoBehaviour
{
    [SerializeField] private TMP_Text _levelNumberText;
    [SerializeField] private TMP_Text _enemiesKilledNumberText;

    public void SetupGameOverScreen(int level, int enemiesKilled)
    {
        gameObject.SetActive(true);

        _levelNumberText.text = "Level: " + level.ToString();
        _enemiesKilledNumberText.text = "Enemies killed: " + enemiesKilled.ToString();
    }
}
