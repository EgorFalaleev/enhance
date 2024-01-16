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
            transform.localPosition = direction;

            _isAttached = true;
        }
    }
}
