using System;
using System.Collections.Generic;
using UnityEngine;

namespace TestTask.Inventory.View
{
    using Interface;
    using Item.Model;
    using Item.Controller;

    /// <summary>
    /// Вьюшка инвентаря.
    /// </summary>
    public class InventoryView : MonoBehaviour, IInventoryView
    {
        public event Action<ItemModel> OnDelete;

        [SerializeField] private GameObject itemPrefab;
        [SerializeField] private Transform contentTransform;

        private List<ItemController> _itemControllers = new();

        public void AddItem(ItemModel item, bool isNew)
        {
            if (isNew)
            {
                GameObject itemIcon = Instantiate(itemPrefab, contentTransform);
                ItemController itemController = itemIcon.GetComponent<ItemController>();
                itemController.Init(item);
                _itemControllers.Add(itemController);
                itemController.OnDelete += Delete;
            }
            else
            {
                ChangeCount();
            }
        }

        public void ChangeCount()
        {
            for (int i = 0; i < _itemControllers.Count; i++)
            {
                _itemControllers[i].ChangeCount();
            }
        }

        public void DeleteItem(string name)
        {
            for (int i = 0; i < _itemControllers.Count; i++)
            {
                if(_itemControllers[i].Item.Name == name)
                {
                    _itemControllers[i].OnDelete -= Delete;
                    Destroy(_itemControllers[i].gameObject);
                }
            }
        }

        private void Delete(ItemModel itemModel)
        {
            for (int i = 0; i < _itemControllers.Count; i++)
            {
                if (_itemControllers[i].Item == itemModel)
                {
                    _itemControllers[i].OnDelete -= Delete;
                }
            }
            OnDelete?.Invoke(itemModel);
        }
    }
}
