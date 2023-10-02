namespace TestTask.Damage.Interface
{
    /// <summary>
    /// Интерфейс для получения урона.
    /// </summary>
    public interface IDamageble
    {
        /// <summary>
        /// Метод для получения урона.
        /// </summary>
        /// <param name="damage">урон</param>
        public void TakeDamage(float damage);
    }
}
