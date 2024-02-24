using System;
using UnityEngine;

namespace Enhance.Runtime.Player
{
    public class PlayerInputController : IInput
    {
        private readonly PlayerInput _playerInput;
        
        // get move axes
        public int Horizontal => Mathf.RoundToInt(_playerInput.Player.Move.ReadValue<Vector2>().x);
        public int Vertical => Mathf.RoundToInt(_playerInput.Player.Move.ReadValue<Vector2>().y);

        public PlayerInputController()
        {
            _playerInput = new PlayerInput();
            
            _playerInput.Player.Enable();
        }
    }
}