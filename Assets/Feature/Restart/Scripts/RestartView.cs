using System;
using UnityEngine.UI;
using UnityEngine;

namespace TestTask.Restart.View
{
    /// <summary>
    /// Вьюшка для контроллера рестарта игры.
    /// </summary>
    public class RestartView : MonoBehaviour
    {
        /// <summary>
        /// Событие нажатия на кнопку перезагрузки.
        /// </summary>
        public event Action OnRestart;

        [SerializeField] private Button restartMenu;

        /// <summary>
        /// Открытие окна перезагрузки игры.
        /// </summary>
        public void OpenRestartMenu()
        {
            restartMenu.gameObject.SetActive(true);
            restartMenu.onClick.AddListener(Restart);
        }

        private void Restart()
        {
            restartMenu.onClick.RemoveListener(Restart);
            OnRestart.Invoke();
        }
    }
}
