using System;

namespace TestTask.Update.Interface
{
    /// <summary>
    /// Интерфейс для обновления вызова метода каждый фрейм.
    /// </summary>
    public interface IUpdater
    {
        /// <summary>
        /// Событие происходящие каждый фрейм.
        /// </summary>
        public event Action OnUpdate;

        public void Update();
    }
}
