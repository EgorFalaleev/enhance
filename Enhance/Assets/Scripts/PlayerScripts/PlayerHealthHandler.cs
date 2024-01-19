using UnityEngine;

public class PlayerHealthHandler : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(Tags.ENEMY) || collision.gameObject.CompareTag(Tags.ENEMY_PROJECTILE))
        {
            Destroy(gameObject);
            return;
        }
    }
}
