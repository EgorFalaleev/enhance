using UnityEngine;

public class EnemyMovementController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 100f;

    private Transform _target;
    private Rigidbody2D _rb;
    private Vector3 _moveDirection;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _target = GameObject.FindGameObjectWithTag(Tags.PLAYER).transform;
    }

    void Update()
    {
        LookAtTarget(_target);

        // determine direction to move
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
        transform.right = target.position - transform.position;
    }
}
