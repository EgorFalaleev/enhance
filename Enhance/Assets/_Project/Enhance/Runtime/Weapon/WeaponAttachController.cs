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
                if (collision.gameObject.GetComponent<WeaponAttachController>() != null &&
                    !collision.gameObject.GetComponent<WeaponAttachController>()._isAttached)
                    return;

                AttachToTransform(collision.transform);
            }
        }

        private void OnDisable()
        {
            if (_isAttached)
                DistanceToPlayerCalculator.RemoveDistance(_distanceToPlayer);
        }

        private void AttachToTransform(Transform destinationTransform)
        {
            // calculate the direction of attachment
            var direction = transform.position - destinationTransform.position;

            // attach to another gameobject
            _parent.SetParent(destinationTransform, false);
            _parent.localPosition = direction.normalized;

            _attachedObjectTransform = destinationTransform;

            _distanceToPlayer = Vector3.Distance(transform.position,
                GameObject.FindGameObjectWithTag(Tags.PLAYER).transform.position);
            DistanceToPlayerCalculator.AddDistance(_distanceToPlayer);

            _isAttached = true;

            // weapon can shoot now
            if (OnWeaponAttached != null)
                OnWeaponAttached(this, EventArgs.Empty);
        }

        private void DrawAttachmentLine(Vector3 from, Vector3 to)
        {
            _lineRenderer.positionCount = 2;

            _lineRenderer.SetPosition(0, from);
            _lineRenderer.SetPosition(1, to);
        }
    }
}