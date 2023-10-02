using System;
using UnityEngine;

namespace TestTask.Enemy.Model.Interface
{
    /// <summary>
    /// Интерфейс для модели врага.
    /// </summary>
    public interface IEnemyModel
    {
        /// <summary>
        /// Объект, что выпадает после смерти.
        /// </summary>
        public GameObject Loot { get; }

        /// <summary>
        /// Событие смерти врага.
        /// </summary>
        public event Action OnDeath;

        /// <summary>
        /// Урон врага.
        /// </summary>
        public float Damage { get; }

        /// <summary>
        /// Максимальное здоровье врага.
        /// </summary>
        public float MaxHealth { get; }

        /// <summary>
        /// Здоровье врага.
        /// </summary>
        public float Health { get; set; }

        /// <summary>
        /// Скорость движения врага.
        /// </summary>
        public float SpeedMove { get; }

        /// <summary>
        /// Пауза между атаками.
        /// </summary>
        public float Cooldown { get; }

        /// <summary>
        /// Атакует ли игрока.
        /// </summary>
        public bool IsAttack { get; set; }

        /// <summary>
        /// Дистанция, с которой враг начинает преследовать игрока.
        /// </summary>
        public float DistanceFollow { get; }

        /// <summary>
        /// Дистанция, с которой враг начинает атаковать игрока.
        /// </summary>
        public float DistanceAttack { get; }
    }
}
