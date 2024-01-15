using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private Vector3 _offset = new Vector3(0, 2, -10);
    [SerializeField] private float _smoothTime = 0.25f;

    private Vector3 _currentVelocity;

    private void LateUpdate()
    {
        // move camera smoothly towards player
        transform.position = Vector3.SmoothDamp(transform.position, _target.position + _offset, ref _currentVelocity, _smoothTime);
    }
}
