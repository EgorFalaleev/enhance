using System;
using UnityEngine;

public class PlayerHealthHandler : DamageableObject
{
    [SerializeField] private GameStatsController _gameStatsController;
    [SerializeField] private GameOverScreen _gameOverScreen;

    private void Start()
    {
        Time.timeScale = 1f;

        OnDie += PlayerHealthHandler_OnDie;

        _gameStatsController.ResetStats();
    }

    private void PlayerHealthHandler_OnDie(object sender, EventArgs e)
    {
        _gameStatsController.Level = GetComponent<Player>()._levelUpSystem.GetLevel();
        _gameStatsController.SetHighScore(_gameStatsController.EnemiesKilled);
        // need to find something better than that
        _gameOverScreen.SetupGameOverScreen(_gameStatsController.Level, _gameStatsController.EnemiesKilled, _gameStatsController.GetHighScore());
        
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<PlayerController>().enabled = false;
        Time.timeScale = 0f;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(Tags.ENEMY_PROJECTILE))
        {
            ReceiveDamage(collision.gameObject.GetComponent<Bullet>().GetDamage());
        }
        // bumping into enemy always deals 1 damage
        else if (collision.gameObject.CompareTag(Tags.ENEMY))
        {
            ReceiveDamage(1);
        }
    }

    public int GetHealth()
    {
        return _health;
    }
}