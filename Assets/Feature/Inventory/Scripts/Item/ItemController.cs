using System;
using UnityEngine;

namespace TestTask.Inventory.Item.Controller
{
    using Model;
    using View;

    /// <summary>
    /// Контроллер предметов.
    /// </summary>
    public class ItemController : MonoBehaviour
    {
        public event Action<ItemModel> OnDelete;
        public ItemModel Item => _model;

        [SerializeField] private ItemView view;

        private ItemModel _model;
        public void Init(ItemModel model)
        {
            _model = model;
            view.LoadImage(Resources.Load<Sprite>(model.PathImage));
            view.ChangeQuantity(_model.Quantity);
            view.OnDelete += Delete;
        }

        public void ChangeCount()
        {
            view.ChangeQuantity(_model.Quantity);
        }

        private void Delete()
        {
            OnDelete?.Invoke(_model);
            view.OnDelete -= Delete;
        }
    }
}
