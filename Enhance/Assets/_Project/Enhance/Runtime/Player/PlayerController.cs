using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Enhance.Runtime.Player
{
    public class PlayerController : MonoBehaviour
    {
        public event EventHandler OnDashStart;
        public event EventHandler OnDashEnd;

        [SerializeField] private float speed = 5f;

        private PlayerInput playerInput;
        private Rigidbody2D body;
        private int _horizontal;
        private int _vertical;
        private bool _isAlive;

        [Header("Dash properties")]
        [SerializeField] private float _dashingPower = 24f;
        [SerializeField] private float _dashingTime = 0.2f;
        [SerializeField] private float _dashingCooldown = 1f;
        [SerializeField] private TrailRenderer _trailRenderer;
        private bool _canDash = true;
        private bool _isDashing;

        private void Awake()
        {
            playerInput = new PlayerInput();
        }

        void Start()
        {
            body = GetComponent<Rigidbody2D>();
            _canDash = true;
            _isAlive = true;
            GetComponent<PlayerHealthHandler>().OnDie += PlayerController_OnDie;
        }

        void Update()
        {
            // cannot move while dashing
            if (_isDashing)
                return;

            if (!_isAlive)
                return;

            // get move axes
            _horizontal = Mathf.RoundToInt(playerInput.Player.Move.ReadValue<Vector2>().x);
            _vertical = Mathf.RoundToInt(playerInput.Player.Move.ReadValue<Vector2>().y);
        }

        private void FixedUpdate()
        {
            // cannot move while dashing
            if (_isDashing)
                return;

            if (!_isAlive)
                return;

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

        public void Dash(InputAction.CallbackContext context)
        {
            if (context.performed && _canDash)
            {
                StartCoroutine(Dash());
            }
        }

        public bool IsDashing()
        {
            return _isDashing;
        }

        private IEnumerator Dash()
        {
            _canDash = false;
            _isDashing = true;

            if (OnDashStart != null)
                OnDashStart(this, EventArgs.Empty);

            // calculate dash direction
            var direction = new Vector2(_horizontal, _vertical).normalized;
            body.velocity = direction * _dashingPower;

            _trailRenderer.emitting = true;

            yield return new WaitForSeconds(_dashingTime);
            _isDashing = false;
            _trailRenderer.emitting = false;

            if (OnDashEnd != null)
                OnDashEnd(this, EventArgs.Empty);

            yield return new WaitForSeconds(_dashingCooldown);
            _canDash = true;
        }

        private void PlayerController_OnDie(object sender, System.EventArgs e)
        {
            _isAlive = false;
        }
    }
}
