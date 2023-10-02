using System;
using UnityEngine;
using TestTask.Initialization;

namespace TestTask.Enemy.Controller.HealthEnemy
{
    using View.Interface;
    using Model.Interface;

    /// <summary>
    /// Контроллер здоровья врага.
    /// </summary>
    public class HealthEnemyController : IInitializable<IEnemyModel>, IInitializable<IEnemyView>,
        IDisposable, IInitializable
    {
        private IEnemyModel _model;
        private IEnemyView _view;
        private GameObject _enemy;

        public HealthEnemyController(GameObject enemy)
        {
            _enemy = enemy;
        }

        public void Damage(float damage)
        {
            _model.Health -= damage;
            _view.DecreaseHealth();
        }

        public void Dispose()
        {
            _model.OnDeath -= Death;
        }

        public void Init(IEnemyModel data)
        {
            _model = data;
            _model.OnDeath += Death;
        }

        public void Init(IEnemyView data)
        {
            _view = data;
            _view.DecreaseHealth();
        }

        private void Death()
        {
            GameObject.Instantiate(_model.Loot, _enemy.transform.position, Quaternion.identity);
            GameObject.Destroy(_enemy);
        }
    }
}
