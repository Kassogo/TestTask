using UnityEngine;

namespace TestTask.CloseGame
{
    /// <summary>
    /// Скрипт для закрытия игры.
    /// </summary>
    public class CloseController : MonoBehaviour
    {
        /// <summary>
        /// Выход из игры
        /// </summary>
        public void Close()
        {
            Application.Quit();
        }
    }
}
