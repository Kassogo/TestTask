using System;
using UnityEngine;

namespace TestTask.Player.Model
{
    using Interface;
    /// <summary>
    /// SO для игрока.
    /// </summary>
    [CreateAssetMenu(fileName = "PlayerData", menuName = "Player/Model"), Serializable]
    public class PlayerModel : ScriptableObject, IPlayerModel
    {
        [SerializeField] private float maxHealth;
        [SerializeField] private float speed;
        [SerializeField] private float cooldown;
        [SerializeField] private float damage;

        private float _health;

        public event Action OnDeath;

        public float Speed => speed;

        public float Health
        {
            get
            {
                if (_health == 0)
                    _health = maxHealth;
                return _health;
            }
            set
            {
                _health = value;
                if (_health <= 0)
                    OnDeath?.Invoke();
            }
        }

        public float MaxHealth => maxHealth;
    }
}
