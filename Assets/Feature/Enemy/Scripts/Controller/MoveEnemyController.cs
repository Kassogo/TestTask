using System;
using UnityEngine;
using TestTask.Initialization;
using TestTask.Update.Interface;

namespace TestTask.Enemy.Controller.MoveEnemy
{
    using View.Interface;
    using Model.Interface;

    /// <summary>
    /// Контроллер ходьбы врага.
    /// </summary>
    public class MoveEnemyController : IInitializable<IEnemyModel>, IInitializable<IEnemyView>,
        IInitializable<GameObject>, IInitializable<IUpdater>, IDisposable, IInitializable
    {
        private Transform _enemy;
        private GameObject _player;
        private IUpdater _updater;
        private IEnemyModel _model;
        private IEnemyView _view;
        private Vector2 _directionToPlayer;

        public MoveEnemyController(Transform enemy)
        {
            _enemy = enemy;
        }

        public void Dispose()
        {
            _updater.OnUpdate -= Move;
        }

        public void Init(GameObject data)
        {
            _player = data;
        }

        public void Init(IEnemyModel data)
        {
            _model = data;
        }

        public void Init(IUpdater data)
        {
            _updater = data;
            _updater.OnUpdate += Move;
        }

        public void Init(IEnemyView data)
        {
            _view = data;
        }

        private void Move()
        {
            if (_player == null)
                return;

            if (_model.IsAttack)
            {
                _view.Move(false);
                return;
            }

            _directionToPlayer = _player.transform.position - _enemy.position;
            _view.Rotate(_directionToPlayer.x > 0 ? true : false);

            if (_directionToPlayer.sqrMagnitude <= _model.DistanceFollow * _model.DistanceFollow)
            {
                _view.Move(true);

                _enemy.position += (Vector3.right * _directionToPlayer.x + Vector3.up * _directionToPlayer.y)
                * Time.deltaTime * _model.SpeedMove;
            }
        }
    }
}
