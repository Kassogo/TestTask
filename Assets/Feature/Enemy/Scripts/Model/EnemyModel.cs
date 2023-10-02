using System;
using UnityEngine;

namespace TestTask.Enemy.Model
{
    using Interface;

    /// <summary>
    /// Модель врага.
    /// </summary>
    [CreateAssetMenu(fileName = "EnemyData", menuName = "Enemy/Model"), Serializable]
    public class EnemyModel : ScriptableObject, IEnemyModel
    {
        [SerializeField] private float damage;
        [SerializeField] private float maxHealth;
        [SerializeField] private float speedMove;
        [SerializeField] private float cooldown;
        [SerializeField] private float distanceFollow;
        [SerializeField] private float distanceAttack;
        [SerializeField] private GameObject loot;

        private bool _isAttack;
        private float _health;

        public event Action OnDeath;

        public float Damage => damage;

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
                    OnDeath.Invoke();
            }
        }

        public float SpeedMove => speedMove;

        public float Cooldown => cooldown;

        public bool IsAttack { get => _isAttack; set => _isAttack = value; }

        public float DistanceFollow => distanceFollow;

        public float DistanceAttack => distanceAttack;

        public float MaxHealth => maxHealth;

        public GameObject Loot => loot;
    }
}
