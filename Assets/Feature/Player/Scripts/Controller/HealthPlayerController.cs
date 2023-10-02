using System;
using TestTask.Initialization;
using UnityEngine;

namespace TestTask.Player.Controller.HealthPlayer
{
    using Model.Interface;
    using View.Interface;

    /// <summary>
    /// Контроллер для здоровья игрока.
    /// </summary>
    public class HealthPlayerController : IInitializable<IPlayerModel>,
        IInitializable<IPlayerView>, IInitializable<GameObject>, IDisposable, IInitializable
    {
        private IPlayerModel _playerModel;
        private IPlayerView _view;
        private GameObject _player;

        public void Damage(float damage)
        {
            _playerModel.Health -= damage;
            _view.DecreaseHealth();
        }

        public void Dispose()
        {
            _playerModel.OnDeath -= Death;
        }

        public void Init(IPlayerModel data)
        {
            _playerModel = data;
            _playerModel.OnDeath += Death;
        }

        public void Init(IPlayerView data)
        {
            _view = data;
            _view.DecreaseHealth();
        }

        public void Init(GameObject data)
        {
            _player = data;
        }

        private void Death()
        {
            GameObject.Destroy(_player);
        }
    }
}
