using System;
using UnityEngine;

namespace Enhance.Runtime.Weapon
{
    public class WeaponAttachController : MonoBehaviour
    {
        public event EventHandler OnDie;
        public bool IsAttached { get { return _isAttached;} }

        private const float WEAPON_ATTACH_MODIFIER = 1.25f;
        private const float PLAYER_ATTACH_MODIFIER = 0.9f;

        private bool _isAttached = false;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            // enemy contact with weapon destroys it
            if (collision.CompareTag(Tags.ENEMY) || collision.CompareTag(Tags.ENEMY_PROJECTILE))
            {
                if (OnDie != null)
                    OnDie(this, EventArgs.Empty);

                Destroy(gameObject);
                return;
            }

            // can attach only once 
            if (!_isAttached)
            {
                // calculate the direction of attachment
                var direction = transform.position - collision.transform.position;

                // attach to a collision GO
                transform.SetParent(collision.transform, false);
                transform.localPosition = collision.tag == Tags.WEAPON ? direction.normalized * WEAPON_ATTACH_MODIFIER: direction.normalized * PLAYER_ATTACH_MODIFIER;

                // change scale to 1 if attached to another weapon to prevent getting smaller
                if (collision.tag == Tags.WEAPON)
                    transform.localScale = Vector3.one;

                _isAttached = true;

                // weapon can shoot now
                GetComponent<WeaponShooter>().IsWeaponAttached = true;
            }
        }

    }
}
