namespace TestTask.Enemy.View.Interface
{
    /// <summary>
    /// Интерфейс для вьюшки врага.
    /// </summary>
    public interface IEnemyView 
    {
        /// <summary>
        /// Включение/выключение анимации врага.
        /// </summary>
        /// <param name="isMove"></param>
        public void Move(bool isMove);

        /// <summary>
        /// Поворот врага.
        /// </summary>
        /// <param name="isRight"></param>
        public void Rotate(bool isRight);

        /// <summary>
        /// Срабатывание анимации атаки.
        /// </summary>
        public void Attack();

        /// <summary>
        /// Уменьшение здоровья.
        /// </summary>
        public void DecreaseHealth();
    }
}
