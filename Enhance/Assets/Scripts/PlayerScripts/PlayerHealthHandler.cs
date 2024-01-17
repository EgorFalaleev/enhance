using UnityEngine;

public class PlayerHealthHandler : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log($"collision with {collision.gameObject.name}");

        if (collision.gameObject.tag == Tags.ENEMY)
        {
            Destroy(gameObject);
            return;
        }
    }
}
