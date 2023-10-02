using System;
using UnityEngine;
using TestTask.Initialization;
using TestTask.Update.Interface;
using TestTask.Damage.Interface;

namespace TestTask.Enemy.Controller.AttackEnemy
{
    using View.Interface;
    using Model.Interface;

    /// <summary>
    /// Контроллер атаки врага.
    /// </summary>
    public class AttackEnemyController : IInitializable<IEnemyModel>, IInitializable<GameObject>,
        IInitializable<IUpdater>, IInitializable<IEnemyView>, IDisposable, IInitializable
    {
        private Transform _enemy;
        private GameObject _player;
        private IDamageble _damagePlayer;
        private IUpdater _updater;
        private IEnemyModel _model;
        private IEnemyView _view;

        private Vector3 _directionToPlayer;
        private Vector3 _placeAttack;
        private float _lastAttackTime;

        public AttackEnemyController(Transform enemy)
        {
            _enemy = enemy;
        }

        public void Dispose()
        {
            _updater.OnUpdate -= ComeСloser;
        }

        public void Init(GameObject data)
        {
            _player = data;
            _damagePlayer = _player.GetComponent<IDamageble>();
        }

        public void Init(IEnemyModel data)
        {
            _model = data;
        }

        public void Init(IUpdater data)
        {
            _updater = data;
            _updater.OnUpdate += ComeСloser;
        }

        public void Init(IEnemyView data)
        {
            _view = data;
        }

        private void Attack()
        {
            if (_lastAttackTime + _model.Cooldown < Time.time)
            {
                _view.Attack();
                _damagePlayer.TakeDamage(_model.Damage);
                _lastAttackTime = Time.time;
            }
        }

        private void ComeСloser()
        {
            if (_player == null)
                return;

            _directionToPlayer = _player.transform.position - _enemy.position;
            if (_directionToPlayer.sqrMagnitude <= _model.DistanceAttack * _model.DistanceAttack)
            {
                _model.IsAttack = true;

                if (_placeAttack == _enemy.position)
                    _enemy.position += (Vector3.right * _placeAttack.x + Vector3.up * _placeAttack.y) * Time.deltaTime * _model.SpeedMove;
                else
                    Attack();
            }
            else
                _model.IsAttack = false;
        }
    }
}
