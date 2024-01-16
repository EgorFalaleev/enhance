using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 5f;

    private PlayerInput playerInput;
    private Rigidbody2D body;
    private int _horizontal;
    private int _vertical;

    private void Awake()
    {
        playerInput = new PlayerInput();
    }

    void Start()
    {
        body = GetComponent<Rigidbody2D>();   
    }

    void Update()
    {
        // get move axes
        _horizontal = Mathf.RoundToInt(playerInput.Player.Move.ReadValue<Vector2>().x);
        _vertical = Mathf.RoundToInt(playerInput.Player.Move.ReadValue<Vector2>().y);
    }

    private void FixedUpdate()
    {
        // move player
        var direction = new Vector2(_horizontal, _vertical).normalized;
        body.velocity = direction * speed * Time.fixedDeltaTime;
    }

    private void OnEnable()
    {
        playerInput.Player.Enable();
    }

    private void OnDisable()
    {
        playerInput.Player.Disable();
    }
}
