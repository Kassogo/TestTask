using UnityEngine;

namespace TestTask.Player.View.Interface
{
    /// <summary>
    /// Интерфейс вьюшки игрока.
    /// </summary>
    public interface IPlayerView
    {
        /// <summary>
        /// Поворот оружия к цели.
        /// </summary>
        /// <param name="target"></param>
        public void RotateWeapon(Vector3 target);
        /// <summary>
        /// Возвращение оружия в обычное состояние.
        /// </summary>
        public void StopRotateWeapon();

        /// <summary>
        /// Уменьшение здоровья.
        /// </summary>
        public void DecreaseHealth();
    }
}
