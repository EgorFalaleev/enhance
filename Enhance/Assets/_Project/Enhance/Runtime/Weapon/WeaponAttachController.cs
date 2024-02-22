using System;
using Enhance.Data;
using UnityEngine;

namespace Enhance.Runtime.Weapon
{
    public class WeaponAttachController : MonoBehaviour
    {
        [SerializeField] private WeaponConfigSO _weaponConfig;

        public event EventHandler OnWeaponAttached;

        private bool _isAttached;
        private Transform _parent;
        private Transform _attachedObjectTransform;
        private LineRenderer _lineRenderer;
        private float _distanceToPlayer;

        private void Start()
        {
            _parent = transform.parent.gameObject.transform;
            _lineRenderer = GetComponent<LineRenderer>();
        }

        private void Update()
        {
            if (_isAttached)
            {
                DrawAttachmentLine(transform.position, _attachedObjectTransform.position);
            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            // can attach only once 
            if (!_isAttached)
            {
                // calculate the direction of attachment
                var direction = transform.position - collision.transform.position;

                // attach to a collision GO
                _parent.SetParent(collision.transform, false);
                _parent.localPosition = direction.normalized;

                _attachedObjectTransform = collision.transform;

                _distanceToPlayer = Vector3.Distance(transform.position,
                    GameObject.FindGameObjectWithTag(Tags.PLAYER).transform.position);
                WeaponSpawner.AddDistance(_distanceToPlayer);

                _isAttached = true;

                // weapon can shoot now
                if (OnWeaponAttached != null)
                    OnWeaponAttached(this, EventArgs.Empty);
            }
        }

        private void OnDisable()
        {
            if (_isAttached)
                WeaponSpawner.RemoveDistance(_distanceToPlayer);
        }

        private void DrawAttachmentLine(Vector3 from, Vector3 to)
        {
            _lineRenderer.positionCount = 2;

            _lineRenderer.SetPosition(0, from);
            _lineRenderer.SetPosition(1, to);
        }
    }
}