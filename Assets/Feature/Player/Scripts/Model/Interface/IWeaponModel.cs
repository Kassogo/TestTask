using UnityEngine;

namespace TestTask.Player.Model.Interface
{
    /// <summary>
    /// Интерфейс модели оружия.
    /// </summary>
    public interface IWeaponModel
    {
        /// <summary>
        /// Префаб пули.
        /// </summary>
        public GameObject Bullet { get; }
        /// <summary>
        /// Пауза между выстрелами.
        /// </summary>
        public float Cooldown { get; }
        /// <summary>
        /// Дистанция для прицеливания.
        /// </summary>
        public float DistanceCanShoot { get; }

        /// <summary>
        /// Слой на котором находится цель.
        /// </summary>
        public LayerMask LayerTarget { get; }
        /// <summary>
        /// Необходимый для выстрела предмет.
        /// </summary>
        public string NeedItemName { get; }
    }
}
