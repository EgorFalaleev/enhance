using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 5f;

    private PlayerInput playerInput;
    private Rigidbody2D body;

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
        Move(speed * Time.deltaTime);
    }

    private void OnEnable()
    {
        playerInput.Player.Enable();
    }

    private void OnDisable()
    {
        playerInput.Player.Disable();
    }

    private void Move(float moveSpeed)
    {
        // get move axes
        var horizontal = Mathf.RoundToInt(playerInput.Player.Move.ReadValue<Vector2>().x);
        var vertical = Mathf.RoundToInt(playerInput.Player.Move.ReadValue<Vector2>().y);

        // move player
        body.velocity = new Vector2(horizontal * moveSpeed, vertical * moveSpeed);
    }
}
