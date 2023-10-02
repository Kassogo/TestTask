using System;

namespace TestTask.Player.Model.Interface
{
    /// <summary>
    /// Интерфейс модели игрока.
    /// </summary>
    public interface IPlayerModel
    {
        public event Action OnDeath;
        /// <summary>
        /// Максимальное здоровье.
        /// </summary>
        public float MaxHealth { get; }
        /// <summary>
        /// Здоровье игрока.
        /// </summary>
        public float Health { get; set; }
        /// <summary>
        /// Скорость передвижения.
        /// </summary>
        public float Speed { get; }
    }
}
