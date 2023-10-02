using System;
using UnityEngine;
using UnityEngine.InputSystem;
using TestTask.Initialization;

namespace TestTask.Player.Controller.MovePlayer
{
    using Model.Interface;

    /// <summary>
    /// Контроллер для ходьбы.
    /// </summary>
    public class MovePlayerController : IInitializable<IPlayerModel>, IInitializable<Rigidbody2D>,
        IInitializable<InputActionMap>, IDisposable, IInitializable
    {
        private InputAction _inputAction;
        private IPlayerModel _model;

        private Vector3 _newPosition;
        private Rigidbody2D _playerRigidbody;

        public void Init(Rigidbody2D data)
        {
            _playerRigidbody = data;
        }

        public void Init(IPlayerModel data)
        {
            _model = data;
        }

        public void Init(InputActionMap data)
        {
            foreach (InputAction action in data)
            {
                if (action.name == "Move")
                {
                    _inputAction = action;
                    break;
                }
            }
            _inputAction.performed += Move;
            _inputAction.canceled += Move;
        }

        public void Dispose()
        {
            _inputAction.performed -= Move;
            _inputAction.canceled -= Move;
        }

        private void Move(InputAction.CallbackContext context)
        {
            _newPosition = context.ReadValue<Vector2>();
            _playerRigidbody.velocity = _newPosition;
        }

    }
}

