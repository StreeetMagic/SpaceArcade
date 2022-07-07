using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Player
{
    [RequireComponent(typeof(Rigidbody2D))]

    public class Movement : MonoBehaviour
    {
        private Rigidbody2D _rigidbody2D;
        PlayerInputActions _playerUinputActions;

        private void OnEnable()
        {
            _playerUinputActions.Player.Enable();
        }

        private void OnDisable()
        {
            _playerUinputActions.Player.Disable();
        }

        private void Awake()
        {
            _playerUinputActions = new PlayerInputActions();
            _rigidbody2D = GetComponent<Rigidbody2D>();
            _playerUinputActions.Player.Move.performed += Move;


        }

        private void Move(InputAction.CallbackContext context)
        {
            Vector2 inputVector2 = context.ReadValue<Vector2>();
            _rigidbody2D.AddForce(inputVector2, ForceMode2D.Impulse);
        }
    }

}
