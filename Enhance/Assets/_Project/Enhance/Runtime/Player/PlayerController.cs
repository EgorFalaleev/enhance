using System;
using System.Collections;
using Enhance.Data;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Enhance.Runtime.Player
{
    public class PlayerController : MonoBehaviour
    {
        public event EventHandler OnDashStart;
        public event EventHandler OnDashEnd;

        [SerializeField] private PlayerConfigSO _playerConfig;

        private IInput _input;
        private int _inputHorizontal;
        private int _inputVertical;
        
        private Rigidbody2D body;
        private bool _isAlive;

        [Header("Dash properties")]
        [SerializeField] private TrailRenderer _trailRenderer;
        private bool _canDash = true;
        private bool _isDashing;

        private void Awake()
        {
            _input = new PlayerInputController();
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
            
            HandleInputs();
        }

        private void FixedUpdate()
        {
            // cannot move while dashing
            if (_isDashing)
                return;

            if (!_isAlive)
                return;
            
            Move(_playerConfig.MoveSpeed * Time.fixedDeltaTime);
        }

        private void HandleInputs()
        {
            _inputHorizontal = _input.Horizontal;
            _inputVertical = _input.Vertical;
        }

        private void Move(float speed)
        {
            var direction = new Vector2(_inputHorizontal, _inputVertical).normalized;
            body.velocity = direction * speed;
        }

        public void Dash(InputAction.CallbackContext context)
        {
            if (context.performed && _canDash)
            {
                StartCoroutine(Dash());
            }
        }

        private IEnumerator Dash()
        {
            _canDash = false;
            _isDashing = true;

            if (OnDashStart != null)
                OnDashStart(this, EventArgs.Empty);

            Move(_playerConfig.DashingPower);
            
            _trailRenderer.emitting = true;

            yield return new WaitForSeconds(_playerConfig.DashingTime);
            _isDashing = false;
            _trailRenderer.emitting = false;

            if (OnDashEnd != null)
                OnDashEnd(this, EventArgs.Empty);

            yield return new WaitForSeconds(_playerConfig.DashingCooldown);
            _canDash = true;
        }

        private void PlayerController_OnDie(object sender, System.EventArgs e)
        {
            _isAlive = false;
        }
    }
}
