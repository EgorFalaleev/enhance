using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponAttachController : MonoBehaviour
{
    private const float WEAPON_ATTACH_MODIFIER = 1.25f;
    private const float PLAYER_ATTACH_MODIFIER = 0.9f;

    private bool _isAttached = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // can attach only once
        if (!_isAttached)
        {
            // prevent enemy from collecting weapon
            if (collision.tag == "Enemy")
                return; 

            // calculate the direction of attachment
            var direction = transform.position - collision.transform.position;

            // attach to a collision GO
            transform.SetParent(collision.transform, false);
            transform.localPosition = collision.tag == "Weapon" ? direction.normalized * WEAPON_ATTACH_MODIFIER: direction.normalized * PLAYER_ATTACH_MODIFIER;

            // change scale to 1 if attached to another weapon to prevent getting smaller
            if (collision.tag == "Weapon")
                transform.localScale = Vector3.one;

            _isAttached = true;
        }
    }
}
