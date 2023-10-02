using System;

namespace TestTask.Inventory.View.Interface
{
    using Item.Model;

    /// <summary>
    /// Интерфейс вьюшки инвентаря.
    /// </summary>
    public interface IInventoryView
    {
        /// <summary>
        /// Событие удаления.
        /// </summary>
        public event Action<ItemModel> OnDelete;

        /// <summary>
        /// Добавить объект.
        /// </summary>
        /// <param name="item"></param>
        /// <param name="isNew"></param>
        public void AddItem(ItemModel item, bool isNew);

        /// <summary>
        /// Поменять количество в отображаемых предметах.
        /// </summary>
        public void ChangeCount();

        /// <summary>
        /// Удаление объекта.
        /// </summary>
        /// <param name="name"></param>
        public void DeleteItem(string name);
    }
}
