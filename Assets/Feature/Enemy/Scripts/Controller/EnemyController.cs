using System;
using System.Collections.Generic;
using UnityEngine;
using TestTask.Initialization;
using TestTask.Update.Interface;
using TestTask.Damage.Interface;

namespace TestTask.Enemy.Controller
{
    using View.Interface;
    using View;
    using Model.Interface;
    using HealthEnemy;
    using MoveEnemy;
    using AttackEnemy;

    /// <summary>
    /// Контроллер врага
    /// </summary>
    public class EnemyController : MonoBehaviour, IDamageble, IInitializable,
        IInitializable<IEnemyModel>, IInitializable<IUpdater>
    {
        [SerializeField] private EnemyView view;

        private IEnemyModel _enemyModel;
        private IUpdater _updater;
        private List<IInitializable> _initializables;
        private HealthEnemyController _healthController;

        private GameObject _player;

        private void Start()
        {
            _player = GameObject.FindGameObjectWithTag("Player");

            _healthController = new(gameObject);

            _initializables = new List<IInitializable>
            {
                new AttackEnemyController(gameObject.transform),
                new MoveEnemyController(gameObject.transform),
                _healthController
            };

            for (int i = 0; i < _initializables.Count; i++)
            {
                Initializable.Init<IEnemyModel>(_enemyModel, _initializables[i]);
                Initializable.Init<IUpdater>(_updater, _initializables[i]);
                Initializable.Init<GameObject>(_player, _initializables[i]);
                Initializable.Init<IEnemyView>(view, _initializables[i]);
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

        public void Init(IEnemyModel data)
        {
            _enemyModel = data;
        }

        public void Init(IUpdater data)
        {
            _updater = data;
        }
    }
}
