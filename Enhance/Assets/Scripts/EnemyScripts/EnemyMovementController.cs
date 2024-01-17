using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class EnemyMovementController : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private float moveSpeed = 100f;

    private Rigidbody2D _rb;
    private Vector3 _moveDirection;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        LookAtTarget(_target);

        var direction = _target.position - transform.position;
        _moveDirection = direction.normalized;
    }

    private void FixedUpdate()
    {
        MoveTowardsTarget(_moveDirection, moveSpeed * Time.fixedDeltaTime);
    }

    private void MoveTowardsTarget(Vector3 direction, float speed)
    {
        _rb.velocity = direction * speed;
    }

    private void LookAtTarget(Transform target)
    {
        //transform.LookAt(target.position);
        transform.right = target.position - transform.position;
    }
}
