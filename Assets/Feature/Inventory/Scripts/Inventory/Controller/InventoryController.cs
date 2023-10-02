using System.IO;
using UnityEngine;

namespace TestTask.Inventory.Controller
{
    using Interface;
    using Model;
    using Item.Model;
    using View;
    using View.Interface;

    /// <summary>
    /// Контроллер инвентаря.
    /// </summary>
    public class InventoryController : MonoBehaviour, IInventoryController
    {
        public InventoryModel InventoryModel => _inventory;

        [SerializeField] private ItemModel startItem;
        private IInventoryView _view;

        private string _filePath;
        private InventoryModel _inventory = new();

        public void Init()
        {
            _view = GetComponent<InventoryView>();
            _filePath = Application.persistentDataPath + "/InventoryData.json";
            _view.OnDelete += DeleteItem;

            if (!LoadInvenotry())
            {
                _inventory.items = new();
                AddItem(startItem);
                return;
            }

            foreach (ItemModel itemModel in _inventory.items)
            {
                _view.AddItem(itemModel, true);
            }
        }

        public bool DeleteItem(string name, int count)
        {
            for (int i = 0; i < _inventory.items.Count; i++)
            {
                if (_inventory.items[i].Name == name && _inventory.items[i].Quantity >= count)
                {
                    _inventory.items[i].Quantity -= count;
                    _view.ChangeCount();
                    if (_inventory.items[i].Quantity == 0)
                        DeleteItem(_inventory.items[i]);
                    return true;
                }
            }
            return false;
        }

        public void DeleteItem(ItemModel item)
        {
            for (int i = 0; i < _inventory.items.Count; i++)
            {
                if (_inventory.items[i] == item)
                {
                    _inventory.items.RemoveAt(i);
                    _view.DeleteItem(item.Name);
                }
            }
        }

        public void AddItem(ItemModel item)
        {
            for (int i = 0; i < _inventory.items.Count; i++)
            {
                if (_inventory.items[i].Name == item.Name)
                {
                    _inventory.items[i].Quantity = item.Quantity + _inventory.items[i].Quantity;
                    _view.AddItem(item, false);
                    return;
                }
            }
            _inventory.items.Add(item);
            _view.AddItem(item, true);
        }

        private void OnDestroy()
        {
            _view.OnDelete -= DeleteItem;
        }

        private void SaveInventory()
        {
            string inventoryData = JsonUtility.ToJson(_inventory);
            File.WriteAllText(_filePath, inventoryData);
        }

        private bool LoadInvenotry()
        {
            if (!File.Exists(_filePath))
                return false;
            string inventoryData = File.ReadAllText(_filePath);
            _inventory = JsonUtility.FromJson<InventoryModel>(inventoryData);
            return true;
        }

        public void SaveData(bool isSave)
        {
            if (isSave)
                SaveInventory();
            _inventory = null;
        }
    }
}
