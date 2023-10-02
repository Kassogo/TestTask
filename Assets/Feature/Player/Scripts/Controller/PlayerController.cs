using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.InputSystem;
using TestTask.Initialization;
using TestTask.Update.Interface;
using TestTask.Damage.Interface;
using TestTask.Inventory.Item.Model;
using TestTask.Inventory.Take;
using TestTask.Inventory.Controller.Interface;

namespace TestTask.Player.Controller
{
    using View;
    using View.Interface;
    using Model;
    using Model.Interface;
    using ShootPlayer;
    using MovePlayer;
    using HealthPlayer;

    /// <summary>
    /// Контроллер игрока.
    /// </summary>
    [RequireComponent(typeof(PlayerInput), typeof(PlayerView))]
    public class PlayerController : MonoBehaviour, IDamageble, IInitializable, ITakeItem,
        IInitializable<IPlayerModel>, IInitializable<IInventoryController>, IInitializable<IUpdater>
    {
        [SerializeField] private WeaponModel weaponModel;
        [SerializeField] private Transform shootPosition;
        [SerializeField] private PlayerInput input;
        [SerializeField] private PlayerView view;
        [SerializeField] private Rigidbody2D rigidbody;

        private HealthPlayerController _healthController;
        private IInventoryController _inventoryController;

        private IPlayerModel _playerModel;
        private IUpdater _updater;
        private List<IInitializable> _initializables;

        public void Init(IPlayerModel data)
        {
            _playerModel = data;
        }

        public void Init(IUpdater data)
        {
            _updater = data;
        }

        public void Init(IInventoryController data)
        {
            _inventoryController = data;
        }

        private void Start()
        {
            _healthController = new();

            _initializables = new List<IInitializable>
            {
                new MovePlayerController(),
                new ShootPlayerController(shootPosition),
                _healthController
            };

            for (int i = 0; i < _initializables.Count; i++)
            {
                Initializable.Init<IPlayerModel>(_playerModel, _initializables[i]);
                Initializable.Init<IUpdater>(_updater, _initializables[i]);
                Initializable.Init<IWeaponModel>(weaponModel, _initializables[i]);
                Initializable.Init<GameObject>(gameObject, _initializables[i]);
                Initializable.Init<InputActionMap>(input.currentActionMap, _initializables[i]);
                Initializable.Init<IPlayerView>(view, _initializables[i]);
                Initializable.Init<IInventoryController>(_inventoryController, _initializables[i]);
                Initializable.Init<Rigidbody2D>(rigidbody, _initializables[i]);
            }
        }

        private void OnDisable()
        {
            IDisposable disposable;
            for (int i = 0; i < _initializables.Count; i++)
            {
                if (_initializables[i] is IDisposable)
                {
                    disposable = _initializables[i] as IDisposable;
                    disposable.Dispose();
                }
            }
        }

        public void TakeDamage(float damage)
        {
            _healthController.Damage(damage);
        }

        public void TakeItem(ItemModel model)
        {
            _inventoryController.AddItem(model);
        }
    }
}
