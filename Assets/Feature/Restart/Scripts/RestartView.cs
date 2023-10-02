using System;
using UnityEngine.UI;
using UnityEngine;

namespace TestTask.Restart.View
{
    /// <summary>
    /// ������ ��� ����������� �������� ����.
    /// </summary>
    public class RestartView : MonoBehaviour
    {
        /// <summary>
        /// ������� ������� �� ������ ������������.
        /// </summary>
        public event Action OnRestart;

        [SerializeField] private Button restartMenu;

        /// <summary>
        /// �������� ���� ������������ ����.
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
