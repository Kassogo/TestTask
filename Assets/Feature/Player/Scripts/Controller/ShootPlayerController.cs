using System;
using UnityEngine;
using UnityEngine.InputSystem;
using TestTask.Initialization;
using TestTask.Inventory.Controller.Interface;
using TestTask.Update.Interface;

namespace TestTask.Player.Controller.ShootPlayer
{
    using Model.Interface;
    using View.Interface;

    /// <summary>
    /// Контроллер для стрельбы.
    /// </summary>
    public class ShootPlayerController : IInitializable<IWeaponModel>, IInitializable<IUpdater>, IInitializable<GameObject>,
        IInitializable<InputActionMap>, IInitializable<IPlayerView>, IInitializable<IInventoryController>, IDisposable, IInitializable
    {
        private Transform _shootPosition;

        private InputAction _inputAction;
        private IPlayerView _view;
        private IWeaponModel _model;
        private IUpdater _updater;
        private IInventoryController _inventory;

        private float _lastShootTime;
        private Collider2D _hit;
        private GameObject _player;
        private GameObject _bullet;

        private bool _isAttack;

        public ShootPlayerController(Transform shootPosition)
        {
            _shootPosition = shootPosition;
        }

        #region Init
        public void Init(IPlayerView data)
        {
            _view = data;
        }

        public void Init(GameObject data)
        {
            _player = data;
        }

        public void Init(IWeaponModel data)
        {
            _model = data;
        }

        public void Init(IUpdater data)
        {
            _updater = data;
            _updater.OnUpdate += CheckTarget;
        }

        public void Init(InputActionMap data)
        {
            foreach (InputAction action in data)
            {
                if (action.name == "Shoot")
                {
                    _inputAction = action;
                    break;
                }
            }
            _inputAction.performed += Shoot;
        }

        public void Init(IInventoryController data)
        {
            _inventory = data;
        }
        #endregion

        public void Dispose()
        {
            _inputAction.performed -= Shoot;
            _updater.OnUpdate -= CheckTarget;
        }

        private void Shoot(InputAction.CallbackContext context)
        {
            if (!_isAttack)
                return;

            if (_lastShootTime + _model.Cooldown < Time.time && _inventory.DeleteItem(_model.NeedItemName, 1))
            {
                _bullet = GameObject.Instantiate(_model.Bullet, _shootPosition.position, _shootPosition.rotation);
                _lastShootTime = Time.time;
            }
        }

        private void CheckTarget()
        {
            _hit = Physics2D.OverlapCircle(_player.transform.position, _model.DistanceCanShoot, _model.LayerTarget);
            if (_hit)
            {
                _isAttack = true;
                _view.RotateWeapon(_hit.transform.position);
            }
            else
            {
                _isAttack = false;
                _view.StopRotateWeapon();
            }
        }
    }
}
