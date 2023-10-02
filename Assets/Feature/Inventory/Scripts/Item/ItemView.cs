using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace TestTask.Inventory.Item.View
{
    /// <summary>
    /// Вьюшка предмета.
    /// </summary>
    public class ItemView : MonoBehaviour
    {
        /// <summary>
        /// Удаление объекта.
        /// </summary>
        public event Action OnDelete;

        [SerializeField] private TextMeshProUGUI textCount;
        [SerializeField] private Image image;
        [SerializeField] private Button deleteButton;

        /// <summary>
        /// Изменение количества отображаемого предмета.
        /// </summary>
        /// <param name="count"></param>
        public void ChangeQuantity(int count)
        {
            if (count == 1)
            {
                textCount.text = "";
                return;
            }
            textCount.text = count.ToString();
        }

        /// <summary>
        /// Загрузка спрайта.
        /// </summary>
        /// <param name="sprite"></param>
        public void LoadImage(Sprite sprite)
        {
            image.sprite = sprite;
        }

        private void Awake()
        {
            deleteButton.onClick.AddListener(Delete);
        }

        private void OnDestroy()
        {
            deleteButton.onClick.RemoveAllListeners();
        }

        private void Delete()
        {
            OnDelete?.Invoke();
        }
    }
}
