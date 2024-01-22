using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExperienceItem : MonoBehaviour
{
    [SerializeField] private int _experienceAmount = 20;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // add player exp when collected
        if (collision.CompareTag(Tags.PLAYER))
        {
            collision.GetComponent<Player>()._levelUpSystem.AddExperience(_experienceAmount);
            Destroy(gameObject);
        }
    }
}
