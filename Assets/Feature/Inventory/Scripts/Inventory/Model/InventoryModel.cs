using System;
using System.Collections.Generic;

namespace TestTask.Inventory.Model
{
    using Item.Model;
    /// <summary>
    /// Модель инвентаря.
    /// </summary>
    [Serializable]
    public class InventoryModel
    {
        /// <summary>
        /// Список предметов.
        /// </summary>
        public List<ItemModel> items = new();
    }
}
