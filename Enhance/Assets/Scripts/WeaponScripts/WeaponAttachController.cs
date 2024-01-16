using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponAttachController : MonoBehaviour
{
    private bool _isAttached = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // can attach only once
        if (!_isAttached)
        {
            // calculate the direction of attachment
            var direction = transform.position - collision.transform.position;

            // attach to a collision GO
            transform.SetParent(collision.transform, false);
            transform.localPosition = direction.normalized;

            // change scale to 1 if attached to another weapon to prevent getting smaller
            if (collision.tag == "Weapon")
                transform.localScale = Vector3.one;

            _isAttached = true;
        }
    }
}
